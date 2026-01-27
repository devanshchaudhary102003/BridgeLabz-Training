using System;
using System.IO;

class ByteArrayStreamImageDemo
{
    static void Main()
    {
        string sourceImage = "source.jpg.jpg";       // input image
        string destinationImage = "copy.jpg";    // output image

        try
        {
            // Check if source image exists
            if (!File.Exists(sourceImage))
            {
                Console.WriteLine("Source image not found.");
                return;
            }

            // ---------- IMAGE TO BYTE ARRAY ----------
            byte[] imageBytes;

            using (FileStream fs = new FileStream(sourceImage, FileMode.Open, FileAccess.Read))
            using (MemoryStream ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                imageBytes = ms.ToArray();
            }

            Console.WriteLine("Image converted to byte array.");
            Console.WriteLine("Byte array size: " + imageBytes.Length + " bytes");

            // ---------- BYTE ARRAY TO IMAGE ----------
            using (MemoryStream ms = new MemoryStream(imageBytes))
            using (FileStream fs = new FileStream(destinationImage, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(fs);
            }

            Console.WriteLine("New image file created: " + destinationImage);

            // ---------- VERIFY FILES ----------
            bool identical = AreFilesIdentical(sourceImage, destinationImage);

            if (identical)
            {
                Console.WriteLine("Verification successful: Images are identical.");
            }
            else
            {
                Console.WriteLine("Verification failed: Images are NOT identical.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("File I/O error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }

    // Method to verify both files byte-by-byte
    static bool AreFilesIdentical(string file1, string file2)
    {
        byte[] bytes1 = File.ReadAllBytes(file1);
        byte[] bytes2 = File.ReadAllBytes(file2);

        if (bytes1.Length != bytes2.Length)
            return false;

        for (int i = 0; i < bytes1.Length; i++)
        {
            if (bytes1[i] != bytes2[i])
                return false;
        }

        return true;
    }
}
