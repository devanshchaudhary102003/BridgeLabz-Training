using System;
using EventTracker.Actions;
using EventTracker.Services;

namespace EventTracker;

class Program
{
    static void Main(string[] args)
    {
        UserAction actions = new UserAction();

        actions.Login("Devansh");
        actions.FileUpload("Devansh","medicl.pdf");
        actions.FileDelete("Devansh","medical.pdf");
        actions.NormalMethod();

        Console.WriteLine();
        Console.WriteLine("Now scanning audited methods using Reflection...");
        Console.WriteLine();

        //Reflection scan + JSON Logs
        EventTrackerService tracker = new EventTrackerService();
        tracker.ScanAndGenerateLogs(actions);
    }
}