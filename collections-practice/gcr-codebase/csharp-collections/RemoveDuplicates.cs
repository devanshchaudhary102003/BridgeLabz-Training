using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
class RemoveDuplicates
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>{3, 1, 2, 2, 3, 4};
        list.Sort();

        List<int> result = new List<int>();
        result.Add(list[0]);
        for(int i = 1; i < list.Count; i++)
        {
            if(list[i] != list[i - 1])
            {
                result.Add(list[i]);
            }
        }

        Console.WriteLine(string.Join(" ",result));
    }
}