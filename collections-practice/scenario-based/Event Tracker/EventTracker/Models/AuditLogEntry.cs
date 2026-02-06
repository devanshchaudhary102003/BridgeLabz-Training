using System;

using System.Collections.Generic;

namespace EventTracker.Models;

public class AuditLogEntry
{
        public string EventName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public DateTime TimestampUtc { get; set; }
        public Dictionary<string, object> Metadata { get; set; }

    public AuditLogEntry()
    {
        Metadata = new Dictionary<string, object>();
    }
}