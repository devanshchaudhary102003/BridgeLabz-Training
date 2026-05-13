using NUnit.Framework;
using System;
using System.IO;

// ======================
// FileProcessor Class
// ======================
public class FileProcessor
{
    public void WriteToFile(string filename, string content)
    {
        File.WriteAllText(filename, content);
    }

    public string ReadFromFile(string filename)
    {
        return File.ReadAllText(filename);
    }
}

// ======================
// NUnit Test Class
// ======================
[TestFixture]
public class FileProcessorTests
{
    private string tempDir;
    private FileProcessor processor;

    // Runs before EACH test
    [SetUp]
    public void SetUp()
    {
        processor = new FileProcessor();

        tempDir = Path.Combine(
            Path.GetTempPath(),
            "FileProcessorTests_" + Guid.NewGuid().ToString("N")
        );

        Directory.CreateDirectory(tempDir);
    }

    // Runs after EACH test
    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(tempDir))
        {
            Directory.Delete(tempDir, true);
        }
    }

    //  Test 1: Write + Read + File Exists
    [Test]
    public void WriteAndRead_File_Content_ShouldMatch_And_FileShouldExist()
    {
        string filePath = Path.Combine(tempDir, "test.txt");
        string content = "Hello NUnit File Test";

        processor.WriteToFile(filePath, content);

        Assert.That(File.Exists(filePath), Is.True);

        string readContent = processor.ReadFromFile(filePath);
        Assert.That(readContent, Is.EqualTo(content));
    }

    //  Test 2: File not found → IOException
    [Test]
    public void ReadFromFile_WhenFileDoesNotExist_ShouldThrowIOException()
    {
        string missingFilePath = Path.Combine(tempDir, "missing.txt");

        Assert.That(
            () => processor.ReadFromFile(missingFilePath),
            Throws.InstanceOf<IOException>()
        );
    }
}
