using NUnit.Framework;
using System;
using System.Globalization;

// ======================
// DateFormatter Class
// ======================
public class DateFormatter
{
    // Converts yyyy-MM-dd → dd-MM-yyyy
    public string FormatDate(string inputDate)
    {
        if (string.IsNullOrEmpty(inputDate))
            throw new ArgumentException("Input date cannot be null or empty");

        DateTime date = DateTime.ParseExact(
            inputDate,
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture
        );

        return date.ToString("dd-MM-yyyy");
    }
}

// ======================
// NUnit Test Class
// ======================
[TestFixture]
public class DateFormatterTests
{
    private DateFormatter formatter;

    [SetUp]
    public void SetUp()
    {
        formatter = new DateFormatter();
    }

    //  Valid date test
    [Test]
    public void FormatDate_ValidDate_ReturnsFormattedDate()
    {
        string result = formatter.FormatDate("2024-01-15");
        Assert.That(result, Is.EqualTo("15-01-2024"));
    }

    // Invalid format test
    [Test]
    public void FormatDate_InvalidFormat_ThrowsException()
    {
        Assert.That(
            () => formatter.FormatDate("15-01-2024"),
            Throws.TypeOf<FormatException>()
        );
    }

    //  Invalid date value
    [Test]
    public void FormatDate_InvalidDate_ThrowsException()
    {
        Assert.That(
            () => formatter.FormatDate("2024-13-40"),
            Throws.TypeOf<FormatException>()
        );
    }

    //  Null input
    [Test]
    public void FormatDate_NullInput_ThrowsException()
    {
        Assert.That(
            () => formatter.FormatDate(null),
            Throws.TypeOf<ArgumentException>()
        );
    }
}
