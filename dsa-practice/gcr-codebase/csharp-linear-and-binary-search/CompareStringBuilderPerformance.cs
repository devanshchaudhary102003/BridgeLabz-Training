using System;
using System.Diagnostics;
using System.Text;
class CompareStringBuilderPerformance
{
    static void Main(string[] args)
    {
        int n = 1000000;

        Stopwatch sw1 = Stopwatch.StartNew();
        string str = "";
        for(int i = 0; i < n; i++)
        {
            str = str + "A";   
        }
        sw1.Stop();

        Stopwatch sw2 = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < n; i++)
        {
            sb.Append("A");
        }
        sw2.Stop();

        Console.WriteLine("String Time: "+sw1.ElapsedMilliseconds+" ms. ");
        Console.WriteLine("StringBuilder Time: "+sw2.ElapsedMilliseconds+" ms. ");
    }
}