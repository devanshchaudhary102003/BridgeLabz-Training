using System;
using System.Reflection;

// 1) Define a custom attribute: TaskInfo
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class TaskInfoAttribute : Attribute
{
    public int Priority { get; }
    public string AssignedTo { get; }

    public TaskInfoAttribute(int priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

// 2) Apply the attribute to a method in TaskManager
public class TaskManager
{
    [TaskInfo(1, "Devansh")]
    public void CompleteDailyReport()
    {
        Console.WriteLine("Daily report completed.");
    }

    public void Cleanup()
    {
        Console.WriteLine("Cleanup done.");
    }
}
class CustomAttribute
{
    static void Main(string[] args)
    {
        Type type = typeof(TaskManager);

        Console.WriteLine("Class Name: " + type.Name);
        Console.WriteLine("---- Task Info Details ----");

        // 3) Retrieve attribute details using Reflection
        MethodInfo[] methods =
            type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

        foreach (MethodInfo method in methods)
        {
            TaskInfoAttribute info =
                (TaskInfoAttribute)Attribute.GetCustomAttribute(method, typeof(TaskInfoAttribute));

            if (info != null)
            {
                Console.WriteLine(
                    "Method: " + method.Name +
                    ", Priority: " + info.Priority +
                    ", Assigned To: " + info.AssignedTo
                );
            }
            else
            {
                Console.WriteLine("Method: " + method.Name + " has no TaskInfo attribute");
            }
        }

        // Optional execution
        Console.WriteLine("\nExecuting method:");
        TaskManager manager = new TaskManager();
        manager.CompleteDailyReport();
    }
}