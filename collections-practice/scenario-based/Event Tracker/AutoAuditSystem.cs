using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;

// =====================================================
// 1) [AuditTrail] Attribute
// =====================================================
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class AuditTrailAttribute : Attribute
{
    public string EventName { get; private set; }
    public string Category { get; private set; }
    public string Severity { get; private set; }

    public AuditTrailAttribute(string eventName)
    {
        EventName = eventName;
        Category = "GENERAL";
        Severity = "INFO";
    }

    public string GetEventName() { return EventName; }
    public string GetCategory() { return Category; }
    public string GetSeverity() { return Severity; }

    public void SetCategory(string category) { Category = category; }
    public void SetSeverity(string severity) { Severity = severity; }
}

// =====================================================
// 2) AuditContext (metadata: actor/ip/session + extra)
// =====================================================
public class AuditContext
{
    public string Actor { get; private set; }
    public string Ip { get; private set; }
    public string SessionId { get; private set; }

    public Dictionary<string, object> Extra { get; private set; }

    public AuditContext(string actor, string ip, string sessionId)
    {
        Actor = actor;
        Ip = ip;
        SessionId = sessionId;
        Extra = new Dictionary<string, object>();
    }

    public AuditContext Put(string key, object value)
    {
        Extra[key] = value;
        return this;
    }
}

// =====================================================
// 3) JsonUtil (simple JSON builder, no external libs)
// =====================================================
public static class JsonUtil
{
    public static string ToJson(object obj)
    {
        return SerializeValue(obj);
    }

    private static string SerializeValue(object value)
    {
        if (value == null) return "null";

        if (value is string) return Quote(Escape((string)value));
        if (value is char) return Quote(Escape(value.ToString()));
        if (value is bool) return ((bool)value) ? "true" : "false";

        if (IsNumber(value))
            return Convert.ToString(value, CultureInfo.InvariantCulture);

        if (value is IDictionary)
            return SerializeDictionary((IDictionary)value);

        if (value is IEnumerable && !(value is string))
            return SerializeArray((IEnumerable)value);

        return Quote(Escape(value.ToString()));
    }

    private static bool IsNumber(object value)
    {
        return value is byte || value is sbyte ||
               value is short || value is ushort ||
               value is int || value is uint ||
               value is long || value is ulong ||
               value is float || value is double ||
               value is decimal;
    }

    private static string SerializeDictionary(IDictionary dict)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        bool first = true;

        foreach (DictionaryEntry entry in dict)
        {
            if (!first) sb.Append(",");
            first = false;

            sb.Append(Quote(Escape(Convert.ToString(entry.Key))));
            sb.Append(":");
            sb.Append(SerializeValue(entry.Value));
        }

        sb.Append("}");
        return sb.ToString();
    }

    private static string SerializeArray(IEnumerable items)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        bool first = true;

        foreach (object item in items)
        {
            if (!first) sb.Append(",");
            first = false;

            sb.Append(SerializeValue(item));
        }

        sb.Append("]");
        return sb.ToString();
    }

    private static string Quote(string s)
    {
        return "\"" + s + "\"";
    }

    private static string Escape(string s)
    {
        if (s == null) return "";

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '\\') sb.Append("\\\\");
            else if (c == '"') sb.Append("\\\"");
            else if (c == '\n') sb.Append("\\n");
            else if (c == '\r') sb.Append("\\r");
            else if (c == '\t') sb.Append("\\t");
            else if (c < 32) sb.Append("\\u" + ((int)c).ToString("x4"));
            else sb.Append(c);
        }
        return sb.ToString();
    }
}

// =====================================================
// 4) EventTracker (scan + invoke + JSON audit log)
// =====================================================
public static class EventTracker
{
    public static List<MethodInfo> FindAuditedMethods(Type type)
    {
        List<MethodInfo> audited = new List<MethodInfo>();

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        for (int i = 0; i < methods.Length; i++)
        {
            MethodInfo m = methods[i];
            object[] attrs = m.GetCustomAttributes(typeof(AuditTrailAttribute), false);
            if (attrs != null && attrs.Length > 0)
                audited.Add(m);
        }

        return audited;
    }

    public static string InvokeWithAudit(object target, MethodInfo method, AuditContext ctx, params object[] args)
    {
        Dictionary<string, object> log = new Dictionary<string, object>();

        object[] attrs = method.GetCustomAttributes(typeof(AuditTrailAttribute), false);
        AuditTrailAttribute at = (AuditTrailAttribute)attrs[0];

        string timestamp = DateTime.UtcNow.ToString("o");

        Stopwatch sw = new Stopwatch();
        sw.Start();

        log["timestamp"] = timestamp;
        log["event"] = at.GetEventName();
        log["category"] = at.GetCategory();
        log["severity"] = at.GetSeverity();
        log["class"] = target.GetType().FullName;
        log["method"] = method.Name;

        Dictionary<string, object> actor = new Dictionary<string, object>();
        actor["user"] = ctx != null ? ctx.Actor : null;
        actor["ip"] = ctx != null ? ctx.Ip : null;
        actor["sessionId"] = ctx != null ? ctx.SessionId : null;
        actor["extra"] = ctx != null ? ctx.Extra : null;
        log["actor"] = actor;

        List<object> paramList = new List<object>();
        if (args != null)
        {
            for (int i = 0; i < args.Length; i++)
                paramList.Add(SafeValue(args[i]));
        }
        log["params"] = paramList;

        try
        {
            object result = method.Invoke(target, args);

            sw.Stop();
            log["status"] = "SUCCESS";
            log["durationMs"] = sw.ElapsedMilliseconds;
            log["result"] = SafeValue(result);
        }
        catch (TargetInvocationException tie)
        {
            sw.Stop();
            Exception real = tie.InnerException != null ? tie.InnerException : tie;

            log["status"] = "ERROR";
            log["durationMs"] = sw.ElapsedMilliseconds;
            log["error"] = real.GetType().FullName;
            log["message"] = real.Message;
        }
        catch (Exception ex)
        {
            sw.Stop();
            log["status"] = "ERROR";
            log["durationMs"] = sw.ElapsedMilliseconds;
            log["error"] = ex.GetType().FullName;
            log["message"] = ex.Message;
        }

        return JsonUtil.ToJson(log);
    }

    private static object SafeValue(object o)
    {
        if (o == null) return null;

        if (o is string) return o;
        if (o is bool) return o;
        if (IsNumber(o)) return o;

        if (o is IDictionary) return o;
        if (o is IEnumerable && !(o is string)) return o;

        return o.ToString();
    }

    private static bool IsNumber(object value)
    {
        return value is byte || value is sbyte ||
               value is short || value is ushort ||
               value is int || value is uint ||
               value is long || value is ulong ||
               value is float || value is double ||
               value is decimal;
    }
}

// =====================================================
// 5) Example business class with audited methods
// =====================================================
public class UserActions
{
    [AuditTrail("USER_LOGIN")]
    public bool Login(string username, string password)
    {
        if (password == null || password.Length < 4)
            throw new ArgumentException("Weak password");

        return true;
    }

    [AuditTrail("FILE_UPLOAD")]
    public string UploadFile(string filename, long sizeBytes)
    {
        return "UPLOAD_OK:" + filename + ":" + sizeBytes.ToString(CultureInfo.InvariantCulture);
    }

    [AuditTrail("FILE_DELETE")]
    private void DeleteFile(string filename)
    {
        if (filename == null || filename.Trim().Length == 0)
            throw new ArgumentException("Filename required");
    }

    public void HelperMethod()
    {
        Console.WriteLine("Helper method not audited");
    }
}

// =====================================================
// 6) Main (demo run)
// =====================================================
public class AutoAuditSystem
{
    public static void Main(string[] args)
    {
        UserActions actions = new UserActions();

        AuditContext ctx = new AuditContext("devansh", "10.0.0.5", "S-ABC-123");
        ctx.Put("device", "Windows");
        ctx.Put("appVersion", "1.0.7");

        List<MethodInfo> audited = EventTracker.FindAuditedMethods(typeof(UserActions));

        Console.WriteLine("Audited methods found: " + audited.Count);
        for (int i = 0; i < audited.Count; i++)
        {
            Console.WriteLine(" - " + audited[i].Name);
        }

        for (int i = 0; i < audited.Count; i++)
        {
            MethodInfo m = audited[i];
            string jsonLog;

            if (m.Name == "Login")
                jsonLog = EventTracker.InvokeWithAudit(actions, m, ctx, "devansh", "1234");
            else if (m.Name == "UploadFile")
                jsonLog = EventTracker.InvokeWithAudit(actions, m, ctx, "report.pdf", 4500L);
            else if (m.Name == "DeleteFile")
                jsonLog = EventTracker.InvokeWithAudit(actions, m, ctx, "old.txt");
            else
                jsonLog = EventTracker.InvokeWithAudit(actions, m, ctx);

            Console.WriteLine();
            Console.WriteLine("JSON LOG:");
            Console.WriteLine(jsonLog);
        }

        // Error case for DeleteFile
        MethodInfo deleteMethod = null;
        for (int i = 0; i < audited.Count; i++)
        {
            if (audited[i].Name == "DeleteFile")
            {
                deleteMethod = audited[i];
                break;
            }
        }

        if (deleteMethod != null)
        {
            Console.WriteLine();
            Console.WriteLine("ERROR CASE LOG:");
            Console.WriteLine(EventTracker.InvokeWithAudit(actions, deleteMethod, ctx, "   "));
        }
    }
}
