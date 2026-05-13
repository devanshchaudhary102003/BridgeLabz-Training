using System;
using System.Collections;
class SuppressWarnings
{
    static void Main(string[] args)
    {

        // Disable warning for obsolete types (ArrayList)
        #pragma warning disable CS0618

        ArrayList list = new ArrayList();
        list.Add("Hello");
        list.Add(100);
        list.Add(3.14);

        string text = (string)list[0];
        int number = (int)list[1];

        Console.WriteLine(list);
        Console.WriteLine(number);

        // Re-enable the warning
        #pragma warning restore CS0618
    }
}