using System;
using System.Collections.Generic;
class SymmetricDifference
{
    static void Main(string[] args)
    {
        HashSet<int> set1 = new HashSet<int>{1,2,3};
        HashSet<int> set2 = new HashSet<int>{3,4,5};

        HashSet<int> SymmetricDifference = new HashSet<int>(set1);
        SymmetricDifference.SymmetricExceptWith(set2);

        Console.WriteLine("Symmetric Difference: {"+string.Join(",",SymmetricDifference)+"}");
    }
}
