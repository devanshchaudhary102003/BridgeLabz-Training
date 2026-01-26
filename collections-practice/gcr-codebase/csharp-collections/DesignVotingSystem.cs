using System;
using System.Collections.Generic;

class VotingSystem
{
    // Store vote counts
    private Dictionary<string, int> voteCount =
        new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

    // Maintain order of votes (LinkedHashMap behavior)
    private List<string> voteOrder = new List<string>();

    public void CastVote(string candidate)
    {
        if (string.IsNullOrWhiteSpace(candidate))
        {
            Console.WriteLine("Invalid candidate name.");
            return;
        }

        candidate = candidate.Trim();

        // Maintain insertion order
        voteOrder.Add(candidate);

        // Count votes
        if (voteCount.ContainsKey(candidate))
        {
            voteCount[candidate] = voteCount[candidate] + 1;
        }
        else
        {
            voteCount[candidate] = 1;
        }

        Console.WriteLine("Vote cast for: " + candidate);
    }

    public void DisplayResultsSorted()
    {
        // Sorted output
        SortedDictionary<string, int> sorted =
            new SortedDictionary<string, int>(voteCount, StringComparer.OrdinalIgnoreCase);

        Console.WriteLine("\n--- Results (Sorted by Candidate Name) ---");

        foreach (KeyValuePair<string, int> pair in sorted)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }

    public void DisplayVoteOrder()
    {
        Console.WriteLine("\n--- Vote Order (Insertion Order) ---");

        for (int i = 0; i < voteOrder.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + voteOrder[i]);
        }
    }
}

class DesignVotingSystem
{
    static void Main()
    {
        VotingSystem votingSystem = new VotingSystem();

        while (true)
        {
            Console.WriteLine("\n1) Cast Vote");
            Console.WriteLine("2) Show Results (Sorted)");
            Console.WriteLine("3) Show Vote Order");
            Console.WriteLine("4) Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter candidate name: ");
                string candidate = Console.ReadLine();
                votingSystem.CastVote(candidate);
            }
            else if (choice == "2")
            {
                votingSystem.DisplayResultsSorted();
            }
            else if (choice == "3")
            {
                votingSystem.DisplayVoteOrder();
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
