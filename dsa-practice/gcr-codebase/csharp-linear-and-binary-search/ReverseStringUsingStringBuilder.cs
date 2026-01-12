using System;
using System.Text;
class ReverseStringUsingStringBuilder
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String: ");
        String str = Console.ReadLine();

        StringBuilder sb = new StringBuilder(str);

        int i = 0;
        int j  = sb.Length-1;

        while(i < j)
        {
            char temp = sb[i];
            sb[i] = sb[j];
            sb[j] = temp;

            i++;
            j--;
        }

        Console.WriteLine("Reversed String: "+sb.ToString());
    }
}