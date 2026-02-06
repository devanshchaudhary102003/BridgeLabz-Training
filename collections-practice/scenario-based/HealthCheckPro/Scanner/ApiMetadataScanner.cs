using System;
using System.Reflection;
using HealthCheckPro.Attributes;


namespace HealthCheckPro.Scanner;

public class ApiMetadataScanner
{
    public static void ScanControllers()
    {
        //Assembly is NOT your class
        //Assembly is a class provided by .NET, inside the System.Reflection namespace.
        Assembly assembly = Assembly.GetExecutingAssembly();
        //Assembly → .NET built-in class
        //GetExecutingAssembly() → returns the currently running .exe / .dll
        //Assembly → Controllers → Methods → Attributes
        //GetExecutingAssembly() → Give me this project’s compiled code, so I can inspect all classes using reflection.”

        foreach(Type type in assembly.GetTypes())
        {
            //assembly.GetTypes() -> returns all classes/structs/interfaces inside your project.
            if(!type.Name.EndsWith("Controller"))
                continue;

            Console.WriteLine("\nController: "+type.Name);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach(MethodInfo method in methods)
            {
                object publicApi = method.GetCustomAttribute(typeof(PublicAPIAttribute));
                object authApi = method.GetCustomAttribute(typeof(AuthAPIAttribute));

                Console.WriteLine(" Method: "+method.Name);

                if(publicApi == null && authApi == null)
                {
                    Console.WriteLine("Missng API annotations");
                }

                if(publicApi != null)
                {
                    PublicAPIAttribute p = (PublicAPIAttribute)publicApi;
                    Console.WriteLine(" Public API: "+p.Description);
                }

                if(authApi != null)
                {
                    AuthAPIAttribute a = (AuthAPIAttribute)authApi;
                    Console.WriteLine(" Auth API: "+a.Role);
                }
            }
        }
        
    }
}
