using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RoleAllowedAttribute : Attribute
{
    public string Role { get; }

    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

[RoleAllowed("ADMIN")]
public class AdminService
{
    public void DeleteUser()
    {
        Console.WriteLine(" User deleted successfully!");
    }

    [RoleAllowed("ADMIN")]
    public void ViewLogs()
    {
        Console.WriteLine(" Viewing system logs...");
    }
}

public static class RoleValidator
{
    public static void InvokeIfAllowed(object obj, string methodName, string currentUserRole)
    {
        Type type = obj.GetType();
        MethodInfo method = type.GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine(" Method not found!");
            return;
        }

        // Class-level role
        RoleAllowedAttribute classRole =
            type.GetCustomAttribute<RoleAllowedAttribute>();

        // Method-level role
        RoleAllowedAttribute methodRole =
            method.GetCustomAttribute<RoleAllowedAttribute>();

        // Method role overrides class role
        string requiredRole = methodRole?.Role ?? classRole?.Role;

        if (requiredRole != null && requiredRole != currentUserRole)
        {
            Console.WriteLine("Access Denied!");
            return;
        }

        method.Invoke(obj, null);
    }
}

class ImplementRoleBased
{
    static void Main(string[] args)
    {
        AdminService service = new AdminService();

        string currentUserRole = "USER";

        Console.WriteLine("Current User Role: " + currentUserRole);
        Console.WriteLine("--------------------------------");

        RoleValidator.InvokeIfAllowed(service, "DeleteUser", currentUserRole);
        RoleValidator.InvokeIfAllowed(service, "ViewLogs", currentUserRole);
    }
}
