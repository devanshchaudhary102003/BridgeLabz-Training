using System;
using System.IO;
using System.Collections.Generic;

class WordFrequencyCounter
{
    static void Main(string[] args)
    {
        string filePath = "input1.txt";

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            // ----------- READ FILE LINE BY LINE -----------
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // Convert line to lowercase
                    line = line.ToLower();

                    // Split into words (remove punctuation)
                    string[] words = line.Split(
                        new char[] { ' ', '\t', ',', '.', ';', ':', '!', '?', '"', '(', ')', '[', ']' },
                        StringSplitOptions.RemoveEmptyEntries
                    );

                    // Count words
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (wordCount.ContainsKey(words[i]))
                        {
                            wordCount[words[i]]++;
                        }
                        else
                        {
                            wordCount[words[i]] = 1;
                        }
                    }
                }
            }

            // ----------- SORT WORDS BY FREQUENCY -----------
            List<KeyValuePair<string, int>> sortedWords =
                new List<KeyValuePair<string, int>>(wordCount);

            sortedWords.Sort((a, b) => b.Value.CompareTo(a.Value));

            // ----------- DISPLAY TOP 5 -----------
            Console.WriteLine("Top 5 most frequent words:\n");

            int limit = Math.Min(5, sortedWords.Count);

            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine(
                    (i + 1) + ". " +
                    sortedWords[i].Key + " -> " +
                    sortedWords[i].Value + " times"
                );
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("File I/O Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}
