using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ReflectionTimingDemo
{
    // Example target class (replace this with your own class)
    public class DemoClass
    {
        public void Hello()
        {
            for (int i = 0; i < 1000000; i++) { }
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public void Wait(int ms)
        {
            Thread.Sleep(ms);
        }
    }

    class MethodExecutionTiming
    {
        static void Main()
        {
            Type targetType = typeof(DemoClass);   // change this to your class
            object instance = Activator.CreateInstance(targetType);

            Console.WriteLine("Timing methods for class: " + targetType.Name);
            Console.WriteLine(new string('-', 60));

            var methods = targetType
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName) // skip property getters/setters
                .ToList();

            foreach (var method in methods)
            {
                try
                {
                    // skip generic/open methods
                    if (method.ContainsGenericParameters)
                    {
                        Console.WriteLine(method.Name + " -> Skipped (generic method)");
                        Console.WriteLine(new string('-', 60));
                        continue;
                    }

                    object[] args = BuildSampleArguments(method);

                    Stopwatch sw = Stopwatch.StartNew();
                    object result = method.Invoke(instance, args);
                    sw.Stop();

                    Console.WriteLine("Method: " + method.Name);
                    Console.WriteLine("Time  : " + sw.ElapsedMilliseconds + " ms");

                    if (method.ReturnType != typeof(void))
                        Console.WriteLine("Return: " + (result != null ? result.ToString() : "null"));

                    Console.WriteLine(new string('-', 60));
                }
                catch (TargetInvocationException ex)
                {
                    // C# 5-safe: no ?. operator
                    string msg = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;

                    Console.WriteLine(method.Name + " -> Error: " + msg);
                    Console.WriteLine(new string('-', 60));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(method.Name + " -> Skipped/Error: " + ex.Message);
                    Console.WriteLine(new string('-', 60));
                }
            }

            Console.WriteLine("Done. Press Enter to exit.");
            Console.ReadLine();
        }

        static object[] BuildSampleArguments(MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            object[] args = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                Type pType = parameters[i].ParameterType;
                args[i] = GetDefaultSampleValue(pType);
            }

            return args;
        }

        static object GetDefaultSampleValue(Type t)
        {
            if (t == typeof(int)) return 50;          // small int (also good for Sleep)
            if (t == typeof(double)) return 10.5;
            if (t == typeof(float)) return 5.5f;
            if (t == typeof(long)) return 100L;
            if (t == typeof(bool)) return true;
            if (t == typeof(string)) return "sample";
            if (t == typeof(char)) return 'A';

            if (t.IsEnum) return Enum.GetValues(t).GetValue(0);

            if (t.IsValueType) return Activator.CreateInstance(t);

            try
            {
                return Activator.CreateInstance(t);
            }
            catch
            {
                return null;
            }
        }
    }
}
