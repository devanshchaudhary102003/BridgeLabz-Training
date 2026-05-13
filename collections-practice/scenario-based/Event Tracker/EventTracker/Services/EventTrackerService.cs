using System;
using System.Reflection;
using System.Text.Json;
using EventTracker.Attributes;
using EventTracker.Models;

namespace EventTracker.Services;

public class EventTrackerService
{
    public void ScanAndGenerateLogs(object targetObject)
    {
        Type type = targetObject.GetType();
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        for(int i = 0; i < methods.Length; i++)
        {
            MethodInfo method = methods[i];
            AuditTrialAttribute auditAttr = (AuditTrialAttribute)Attribute.GetCustomAttribute(method,typeof(AuditTrialAttribute));

            if(auditAttr != null)
            {
                AuditLogEntry entry = new AuditLogEntry();
                entry.EventName = auditAttr.EventName;
                entry.ClassName = type.Name;
                entry.MethodName = method.Name;
                entry.TimestampUtc = DateTime.UtcNow;


                // Basic metadata
                    entry.Metadata["machine"] = Environment.MachineName;
                    entry.Metadata["os"] = Environment.OSVersion.ToString();
                    entry.Metadata["user"] = Environment.UserName;

                string json = JsonSerializer.Serialize(entry, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true
                });

                Console.WriteLine("-------------- AUDIT LOG (JSON) --------------");
                Console.WriteLine(json);
                Console.WriteLine("-----------------------------------------------");
            }
        }
    }
}