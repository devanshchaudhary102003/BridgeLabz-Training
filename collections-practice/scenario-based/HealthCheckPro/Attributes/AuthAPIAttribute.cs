//A namespace is used to organize code and avoid name conflicts.
using System;
namespace HealthCheckPro.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AuthAPIAttribute : Attribute
{
    public string Role;

    public AuthAPIAttribute(string role)
    {
        Role = role;
    }
}