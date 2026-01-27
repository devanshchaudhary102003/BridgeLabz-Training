using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class PipedStreamDemo
{
    static void Main(string[] args)
    {
        try
        {
            // Create pipe server for writing
            using (AnonymousPipeServerStream pipeServer =
                   new AnonymousPipeServerStream(PipeDirection.Out,
                                                  HandleInheritability.Inheritable))
            {
                // Create pipe client for reading
                using (AnonymousPipeClientStream pipeClient =
                       new AnonymousPipeClientStream(PipeDirection.In,
                                                     pipeServer.GetClientHandleAsString()))
                {
                    // Writer thread
                    Thread writerThread = new Thread(() => WriteData(pipeServer));

                    // Reader thread
                    Thread readerThread = new Thread(() => ReadData(pipeClient));

                    writerThread.Start();
                    readerThread.Start();

                    writerThread.Join();
                    readerThread.Join();
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Pipe I/O Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }

    // Writer thread method
    static void WriteData(AnonymousPipeServerStream pipe)
    {
        try
        {
            using (StreamWriter writer =
                   new StreamWriter(pipe, Encoding.UTF8))
            {
                writer.AutoFlush = true;

                for (int i = 1; i <= 5; i++)
                {
                    string message = "Message " + i;
                    writer.WriteLine(message);
                    Console.WriteLine("Writer sent: " + message);
                    Thread.Sleep(500);
                }
            } // Closing writer signals end of data
        }
        catch (IOException ex)
        {
            Console.WriteLine("Writer Error: " + ex.Message);
        }
    }

    // Reader thread method
    static void ReadData(AnonymousPipeClientStream pipe)
    {
        try
        {
            using (StreamReader reader =
                   new StreamReader(pipe, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("Reader received: " + line);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Reader Error: " + ex.Message);
        }
    }
}
