using System;
using System.Collections.Generic;

/* ========== POLICY CLASS ========== */

class InsurancePolicy : IComparable<InsurancePolicy>
{
    public string PolicyNumber;
    public string CoverageType;
    public DateTime ExpiryDate;

    public InsurancePolicy(string number, string coverage, DateTime expiry)
    {
        PolicyNumber = number;
        CoverageType = coverage;
        ExpiryDate = expiry;
    }

    // Needed for SortedSet
    public int CompareTo(InsurancePolicy other)
    {
        if (other == null) return 1;

        int dateCompare = ExpiryDate.CompareTo(other.ExpiryDate);
        if (dateCompare != 0)
            return dateCompare;

        return string.Compare(PolicyNumber, other.PolicyNumber, StringComparison.OrdinalIgnoreCase);
    }

    // Needed for HashSet uniqueness
    public override bool Equals(object obj)
    {
        return obj is InsurancePolicy p &&
               string.Equals(PolicyNumber, p.PolicyNumber, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return PolicyNumber.ToLower().GetHashCode();
    }

    public override string ToString()
    {
        return PolicyNumber + " | " + CoverageType + " | " + ExpiryDate.ToShortDateString();
    }
}

/* ========== MAIN ========== */

class InsurancePolicyManagementSystem
{
    static void Main()
    {
        HashSet<InsurancePolicy> uniquePolicies = new HashSet<InsurancePolicy>();
        List<InsurancePolicy> insertionOrder = new List<InsurancePolicy>();
        SortedSet<InsurancePolicy> sortedByExpiry = new SortedSet<InsurancePolicy>();

        AddPolicy(uniquePolicies, insertionOrder, sortedByExpiry,
            new InsurancePolicy("P101", "Health", DateTime.Today.AddDays(20)));

        AddPolicy(uniquePolicies, insertionOrder, sortedByExpiry,
            new InsurancePolicy("P102", "Vehicle", DateTime.Today.AddDays(60)));

        AddPolicy(uniquePolicies, insertionOrder, sortedByExpiry,
            new InsurancePolicy("P103", "Health", DateTime.Today.AddDays(10)));

        // Duplicate
        AddPolicy(uniquePolicies, insertionOrder, sortedByExpiry,
            new InsurancePolicy("P101", "Health", DateTime.Today.AddDays(20)));

        Console.WriteLine("All Unique Policies:");
        foreach (var p in uniquePolicies)
            Console.WriteLine(p);

        Console.WriteLine("\nPolicies Expiring Within 30 Days:");
        DateTime today = DateTime.Today;
        DateTime limit = today.AddDays(30);

        foreach (var p in sortedByExpiry)
        {
            if (p.ExpiryDate >= today && p.ExpiryDate <= limit)
                Console.WriteLine(p);
        }

        Console.WriteLine("\nPolicies with Health Coverage:");
        foreach (var p in uniquePolicies)
        {
            if (p.CoverageType == "Health")
                Console.WriteLine(p);
        }

        Console.WriteLine("\nInsertion Order:");
        foreach (var p in insertionOrder)
            Console.WriteLine(p);
    }

    static void AddPolicy(HashSet<InsurancePolicy> set,List<InsurancePolicy> order,SortedSet<InsurancePolicy> sorted,InsurancePolicy policy)
    {
        if (set.Add(policy))
        {
            order.Add(policy);
            sorted.Add(policy);
        }
        else
        {
            Console.WriteLine("Duplicate policy detected: " + policy.PolicyNumber);
        }
    }
}
