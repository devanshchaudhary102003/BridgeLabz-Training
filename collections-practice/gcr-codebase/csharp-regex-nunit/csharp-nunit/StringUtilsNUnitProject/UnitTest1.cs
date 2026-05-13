using NUnit.Framework;
using System;

// ======================
// String Utility Class
// ======================
public class StringUtils
{
    public string Reverse(string str)
    {
        if (str == null) return null;

        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    public bool IsPalindrome(string str)
    {
        if (str == null) return false;

        string reversed = Reverse(str);
        return str.Equals(reversed, StringComparison.OrdinalIgnoreCase);
    }

    public string ToUpperCase(string str)
    {
        if (str == null) return null;

        return str.ToUpper();
    }
}

// ======================
// NUnit Test Class
// ======================
[TestFixture]
public class StringUtilsTests
{
    private StringUtils utils;

    [SetUp]
    public void Setup()
    {
        utils = new StringUtils();
    }

    // -------- Reverse Tests --------
    [Test]
    public void Reverse_String_ReturnsReversedString()
    {
        string result = utils.Reverse("hello");
        Assert.That(result, Is.EqualTo("olleh"));
    }

    // -------- Palindrome Tests --------
    [Test]
    public void IsPalindrome_ValidPalindrome_ReturnsTrue()
    {
        bool result = utils.IsPalindrome("madam");
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPalindrome_NotPalindrome_ReturnsFalse()
    {
        bool result = utils.IsPalindrome("hello");
        Assert.That(result, Is.False);
    }

    // -------- UpperCase Tests --------
    [Test]
    public void ToUpperCase_String_ReturnsUpperCase()
    {
        string result = utils.ToUpperCase("devansh");
        Assert.That(result, Is.EqualTo("DEVANSH"));
    }

    [Test]
    public void ToUpperCase_AlreadyUpperCase_ReturnsSame()
    {
        string result = utils.ToUpperCase("HELLO");
        Assert.That(result, Is.EqualTo("HELLO"));
    }
}
