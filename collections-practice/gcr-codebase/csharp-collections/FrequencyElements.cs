using System;
using System.Collections.Generic;
class FrequencyElements
{
    static void Main(string[] args)
    {
        string[] input = {"apple", "banana", "apple", "orange"};
        Dictionary<string,int> frequency = new Dictionary<string, int>();

        for(int i = 0; i < input.Length; i++)
        {
            if (frequency.ContainsKey(input[i]))
            {
                frequency[input[i]]++;
            }
            else
            {
                frequency[input[i]] = 1;
            }
        }

        // Display result using for loop
        string[] keys = new string[frequency.Count];
        frequency.Keys.CopyTo(keys,0);// We cannot access dictionary keys using index directly

        for(int i = 0; i < keys.Length; i++)
        {
            Console.WriteLine(keys[i]+" : "+frequency[keys[i]]);
        }

    }
}