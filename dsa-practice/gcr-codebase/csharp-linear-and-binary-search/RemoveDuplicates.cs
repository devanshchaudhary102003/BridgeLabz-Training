using System;
using System.Text;
class RemoveDuplicates
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a String: ");
        String str = Console.ReadLine();

        StringBuilder sb = new StringBuilder(str);

        for(int i = 0; i < sb.Length; i++)
        {
            for(int j = i + 1; j < sb.Length;)
            {
                if(sb[i] == sb[j])
                {
                    sb.Remove(j,1);
                }
                else
                {
                    j++;
                }
            }
        }
        Console.WriteLine("String After Remove Duplicates: "+sb.ToString());
    }
}