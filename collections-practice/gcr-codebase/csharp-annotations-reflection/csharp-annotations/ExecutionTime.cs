using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

[AttributeUsage(AttributeTargets.Method)]
public class LogExecutionTimeAttribute : Attribute
{
}

public class DemoClass
{
    [LogExecutionTime]
    public void FastMethod()
    {
        for (int i = 0; i < 100000; i++) { }
    }

    [LogExecutionTime]
    public void MediumMethod()
    {
        for (int i = 0; i < 5000000; i++) { }
    }

    [LogExecutionTime]
    public void SlowMethod()
    {
        Thread.Sleep(500);
    }

    public void NormalMethod()
    {
        Thread.Sleep(200);
    }
}

public static class MethodExecutor
{
    public static void ExecuteLoggedMethods(object obj)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        Type type = obj.GetType();

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

        foreach (MethodInfo method in methods)
        {
            if (method.GetCustomAttribute<LogExecutionTimeAttribute>() == null)
                continue;

            if (method.GetParameters().Length != 0)
            {
                Console.WriteLine($"Skipping {method.Name} (has parameters).");
                continue;
            }

            Console.WriteLine($"\nExecuting: {type.Name}.{method.Name}");

            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                method.Invoke(obj, null);
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine($"Method threw an exception: {ex.InnerException?.Message ?? ex.Message}");
            }
            finally
            {
                sw.Stop();
                Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}

class ExecutionTime
{
    public static void Main()
    {
        DemoClass demo = new DemoClass();

        Console.WriteLine("Timing methods with [LogExecutionTime]...\n");
        MethodExecutor.ExecuteLoggedMethods(demo);

        Console.WriteLine("\nDone.");
        Console.ReadLine();
    }
}
