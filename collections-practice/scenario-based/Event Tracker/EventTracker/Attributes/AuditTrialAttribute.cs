using System;
namespace EventTracker.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AuditTrialAttribute : Attribute
{
    public string EventName;
    public AuditTrialAttribute(string eventName)
    {
        EventName = eventName;
    }
}