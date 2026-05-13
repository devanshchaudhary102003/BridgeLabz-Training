using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

// 1) CacheResult Attribute
[AttributeUsage(AttributeTargets.Method)]
public sealed class CacheResultAttribute : Attribute { }

// 2) Cache Engine (Dictionary-based)
public static class CacheEngine
{
    // Thread-safe dictionary for caching
    private static readonly ConcurrentDictionary<string, object> _cache =
        new ConcurrentDictionary<string, object>();

    public static T InvokeCached<T>(object target, string methodName, params object[] args)
    {
        if (target == null) throw new ArgumentNullException(nameof(target));
        if (methodName == null) throw new ArgumentNullException(nameof(methodName));
        args ??= Array.Empty<object>();

        Type type = target.GetType();

        MethodInfo method = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(m => m.Name == methodName && m.GetParameters().Length == args.Length);

        if (method == null)
            throw new MissingMethodException(type.FullName, methodName);

        bool isCacheEnabled = method.GetCustomAttribute<CacheResultAttribute>() != null;

        // If [CacheResult] is not applied, just invoke normally
        if (!isCacheEnabled)
            return (T)method.Invoke(target, args);

        // Build a stable cache key for (type + method + args)
        string key = BuildKey(type, method, args);

        // Return cached if exists, else compute + store
        object value = _cache.GetOrAdd(key, _ =>
        {
            object result = method.Invoke(target, args);
            return result;
        });

        return (T)value;
    }

    private static string BuildKey(Type type, MethodInfo method, object[] args)
    {
        var sb = new StringBuilder();
        sb.Append(type.FullName).Append("|").Append(method.Name).Append("|");

        for (int i = 0; i < args.Length; i++)
        {
            object a = args[i];
            // Include type + value to reduce collisions
            sb.Append(a?.GetType().FullName ?? "null")
              .Append(":")
              .Append(a?.ToString() ?? "null");

            if (i < args.Length - 1) sb.Append(",");
        }
        return sb.ToString();
    }
}

// 3) Example "Expensive" class
public class ExpensiveCalculator
{
    // Apply CacheResult here
    [CacheResult]
    public long SlowFibonacci(int n)
    {
        // Intentionally slow (recursive) to show caching benefit
        if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
        if (n <= 1) return n;
        return SlowFibonacci(n - 1) + SlowFibonacci(n - 2);
    }

    // Not cached (no attribute)
    public int Add(int a, int b) => a + b;
}

// 4) Demo
public class PImplementCustomCaching
{
    static void Main(string[] args)
    {
        var calc = new ExpensiveCalculator();

        int input = 40;

        Console.WriteLine("Calling SlowFibonacci(" + input + ") twice...\n");

        var sw1 = Stopwatch.StartNew();
        long r1 = CacheEngine.InvokeCached<long>(calc, nameof(ExpensiveCalculator.SlowFibonacci), input);
        sw1.Stop();

        var sw2 = Stopwatch.StartNew();
        long r2 = CacheEngine.InvokeCached<long>(calc, nameof(ExpensiveCalculator.SlowFibonacci), input);
        sw2.Stop();

        Console.WriteLine($"Result1: {r1}, Time1: {sw1.ElapsedMilliseconds} ms");
        Console.WriteLine($"Result2: {r2}, Time2: {sw2.ElapsedMilliseconds} ms");
        Console.WriteLine("\nSecond call should be much faster because it is cached.");

        // Show non-cached method
        Console.WriteLine("\nCalling Add(2,3) twice (not cached)...");
        Console.WriteLine(CacheEngine.InvokeCached<int>(calc, nameof(ExpensiveCalculator.Add), 2, 3));
        Console.WriteLine(CacheEngine.InvokeCached<int>(calc, nameof(ExpensiveCalculator.Add), 2, 3));
    }
}
