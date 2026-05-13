using System;
using System.Reflection;

// ===================== 1) Repeatable Attribute =====================
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class BugReportAttribute : Attribute
{
    public string Description { get; }

    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

// ===================== 2) Class Using the Attribute =====================
public class Calculator
{
    [BugReport("Fails when dividing by zero")]
    [BugReport("Incorrect rounding for large numbers")]
    public int Divide(int a, int b)
    {
        return a / b;
    }
}

// ===================== 3) Retrieve & Print Bug Reports =====================
class RepeatableAttribute
{
    static void Main()
    {
        Type type = typeof(Calculator);
        MethodInfo method = type.GetMethod("Divide");

        var bugReports = method.GetCustomAttributes<BugReportAttribute>();

        Console.WriteLine("Bug reports for method: " + method.Name);

        foreach (var bug in bugReports)
        {
            Console.WriteLine("- " + bug.Description);
        }
    }
}
