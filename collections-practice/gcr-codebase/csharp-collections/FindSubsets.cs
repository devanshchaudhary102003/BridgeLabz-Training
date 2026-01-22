using System;
using System.Collections.Generic;
class FindSubsets
{
    static void Main(string[] args)
    {
        HashSet<int> set1 = new HashSet<int>{2,3};
        HashSet<int> set2 = new HashSet<int>{1,2,3,4};

        bool result = set1.IsSubsetOf(set2);
        Console.WriteLine(result);
    }
}