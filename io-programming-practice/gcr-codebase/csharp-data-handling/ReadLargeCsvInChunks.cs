using System;
using System.IO;

class ReadLargeCsvInChunks
{
    static void Main(string[] args)
    {
        string filePath = "large.csv";   // change path
        int chunkSize = 100;

        long processed = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            // If CSV has a header, read and discard it:
            // string header = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                int linesInThisChunk = 0;

                while (linesInThisChunk < chunkSize && !reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;

                    // Skip empty lines (optional)
                    if (line.Length == 0) continue;

                    // TODO: process line here (parse CSV columns if needed)
                    // Example:
                    // string[] cols = line.Split(',');

                    processed++;
                    linesInThisChunk++;
                }

                Console.WriteLine("Records processed so far: " + processed);
            }
        }

        Console.WriteLine("Done. Total records processed: " + processed);
    }
}
