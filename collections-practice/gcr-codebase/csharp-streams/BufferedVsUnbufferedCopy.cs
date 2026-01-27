using System;
using System.Diagnostics;
using System.IO;

class BufferedStreamsCopyDemo
{
    private const int ChunkSize = 4096; // 4 KB

    static void Main()
    {
        string sourcePath = "source_bigfile.bin";
        string unbufferedDest = "dest_unbuffered.bin";
        string bufferedDest = "dest_buffered.bin";

        try
        {
            // 1) Create source file if not exists (example: 100MB)
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found. Creating a sample 100MB source file...");
                CreateSampleFile(sourcePath, 100); // 100 MB
                Console.WriteLine("Source file created: " + sourcePath);
            }
            else
            {
                Console.WriteLine("Source file already exists: " + sourcePath);
            }

            Console.WriteLine("Source size: " + new FileInfo(sourcePath).Length + " bytes");
            Console.WriteLine("Chunk size: " + ChunkSize + " bytes");
            Console.WriteLine();

            // 2) Unbuffered copy
            long unbufferedMs = CopyUnbuffered(sourcePath, unbufferedDest);
            Console.WriteLine("Unbuffered copy time: " + unbufferedMs + " ms");

            // 3) Buffered copy
            long bufferedMs = CopyBuffered(sourcePath, bufferedDest);
            Console.WriteLine("Buffered copy time:   " + bufferedMs + " ms");

            Console.WriteLine();

            // 4) Compare
            if (bufferedMs > 0)
            {
                double ratio = (double)unbufferedMs / (double)bufferedMs;
                Console.WriteLine("Speed ratio (Unbuffered / Buffered): " + ratio);
            }

            Console.WriteLine();
            Console.WriteLine("Verify sizes:");
            Console.WriteLine("Source:     " + new FileInfo(sourcePath).Length + " bytes");
            Console.WriteLine("Unbuffered: " + new FileInfo(unbufferedDest).Length + " bytes");
            Console.WriteLine("Buffered:   " + new FileInfo(bufferedDest).Length + " bytes");
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O Error: " + ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Access Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }

    // Creates a sample file of given size in MB
    static void CreateSampleFile(string path, int sizeInMB)
    {
        long totalBytes = (long)sizeInMB * 1024 * 1024;
        byte[] buffer = new byte[ChunkSize];

        // Fill buffer with some data (pattern)
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (byte)(i % 256);
        }

        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            long written = 0;

            while (written < totalBytes)
            {
                int toWrite = (int)Math.Min(buffer.Length, totalBytes - written);
                fs.Write(buffer, 0, toWrite);
                written += toWrite;
            }

            fs.Flush();
        }
    }

    static long CopyUnbuffered(string sourcePath, string destPath)
    {
        Stopwatch sw = Stopwatch.StartNew();

        using (FileStream input = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
        using (FileStream output = new FileStream(destPath, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[ChunkSize];
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }

            output.Flush();
        }

        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    static long CopyBuffered(string sourcePath, string destPath)
    {
        Stopwatch sw = Stopwatch.StartNew();

        using (FileStream inputFs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
        using (FileStream outputFs = new FileStream(destPath, FileMode.Create, FileAccess.Write))
        using (BufferedStream input = new BufferedStream(inputFs, ChunkSize))
        using (BufferedStream output = new BufferedStream(outputFs, ChunkSize))
        {
            byte[] buffer = new byte[ChunkSize];
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }

            output.Flush();
        }

        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}
