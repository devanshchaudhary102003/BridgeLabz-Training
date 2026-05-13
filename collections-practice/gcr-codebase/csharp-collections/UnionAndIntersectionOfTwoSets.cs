using System;
using System.Collections.Generic;
class UnionAndIntersectionOfTwoSets
{
    static void Main(string[] args)
    {
        HashSet<int> set1 = new HashSet<int>{1,2,3};
        HashSet<int> set2 = new HashSet<int>{3,4,5};

        HashSet<int> Union = new HashSet<int>(set1);
        Union.UnionWith(set2);

        HashSet<int> Intersect = new HashSet<int>(set1);
        Intersect.IntersectWith(set2);

        Console.WriteLine("Union: {"+string.Join(",",Union)+"}");
        Console.WriteLine("Intersect: {"+string.Join(",",Intersect)+"}");
    }
}