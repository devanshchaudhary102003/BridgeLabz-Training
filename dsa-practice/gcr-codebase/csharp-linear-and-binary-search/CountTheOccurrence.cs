using System;
using System.IO;
using System.Diagnostics;
class CountTheOccurrence
{
    static void Main(string[] args)
    {
        string FilePath = "sample.txt";
        string WordToCount = "C#";

        if (!File.Exists(FilePath))
        {
            Console.WriteLine("File Not Found: "+FilePath);
            return;
        }

        int count = 0;

        try
        {
            using (StreamReader sr = new StreamReader(FilePath))
            {
                string Line;

                while((Line = sr.ReadLine()) != null)
                {
                   string[] words =  Line.Split(new char[] { ' ','.',',','!','?',';',':','\t'},StringSplitOptions.RemoveEmptyEntries);

                   for(int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Equals(WordToCount, StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine("The word '"+WordToCount+" ' appears "+count+" time(s) in the file.");
        }

        catch(Exception e)
        {
            Console.WriteLine("An error occurred while reading the file: ");
            Console.WriteLine(e.Message);
        }
    }
}