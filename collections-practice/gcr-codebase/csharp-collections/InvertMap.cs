using System;
using System.Collections.Generic;
class InvertMap
{
    static void Main(string[] args)
    {
        // Input Dictionary<K, V>
        Dictionary<string,int> input = new Dictionary<string, int>();
        input["A"] = 1;
        input["B"] = 2;
        input["C"] = 1;

        // Output Dictionary<V, List<K>>
        Dictionary<int, List<string>> inverted = new Dictionary<int, List<string>>();

        // Convert Dictionary to arrays so we can use for loop
        string[] keys = new string[input.Count];
        int[] values = new int[input.Count];

        int index = 0;

        foreach(var pair in input)
        {
            keys[index] = pair.Key;
            values[index] = pair.Value;
            index++;
        }

        for(int i = 0; i < keys.Length; i++)
        {
            int value = values[i];
            string key = keys[i];

            if (!inverted.ContainsKey(value))
            {
                inverted[value] = new List<string>();
            }
            inverted[value].Add(key);
        }

        foreach(var pair in inverted)
        {
            Console.Write(pair.Key+" = [");
            for(int i = 0; i < pair.Value.Count; i++)
            {
                Console.Write(pair.Value[i]+" ");
            }
            Console.WriteLine("]");
        }
    }
}