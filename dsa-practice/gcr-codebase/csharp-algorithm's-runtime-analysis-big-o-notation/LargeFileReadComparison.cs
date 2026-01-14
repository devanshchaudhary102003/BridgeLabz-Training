using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace LargeFileReadComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "largefile.txt";   // Assume large file exists

            Console.WriteLine("Large File Reading Performance Comparison\n");

            ReadUsingStreamReader(filePath);
            Console.WriteLine("----------------------------------");
            ReadUsingFileStream(filePath);

            Console.ReadLine();
        }

        static void ReadUsingStreamReader(string path)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (StreamReader reader = new StreamReader(path))
            {
                while (reader.Read() != -1)
                {
                    // Reading character by character
                }
            }

            stopwatch.Stop();
            Console.WriteLine("StreamReader Time: " + stopwatch.ElapsedMilliseconds + " ms");
        }

        static void ReadUsingFileStream(string path)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[8192];   // 8 KB buffer
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Bytes read efficiently
                }
            }

            stopwatch.Stop();
            Console.WriteLine("FileStream Time: " + stopwatch.ElapsedMilliseconds + " ms");
        }
    }
}
