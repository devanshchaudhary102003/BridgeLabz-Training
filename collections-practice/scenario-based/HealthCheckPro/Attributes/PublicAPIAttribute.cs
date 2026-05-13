using System;
namespace HealthCheckPro.Attributes;


[AttributeUsage(AttributeTargets.Method)]
public class PublicAPIAttribute : Attribute
{
    public string Description;

    public PublicAPIAttribute(string description)
    {
        Description = description;
    }
}