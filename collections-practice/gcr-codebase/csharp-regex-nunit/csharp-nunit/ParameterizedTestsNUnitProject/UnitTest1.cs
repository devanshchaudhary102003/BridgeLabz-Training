using NUnit.Framework;

// ======================
// Utility Class
// ======================
public class NumberUtils
{
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}

// ======================
// NUnit Parameterized Tests
// ======================
[TestFixture]
public class NumberUtilsTests
{
    private NumberUtils utils;

    [SetUp]
    public void Setup()
    {
        utils = new NumberUtils();
    }

    // -------- Parameterized Test --------
    [TestCase(2, true)]
    [TestCase(4, true)]
    [TestCase(6, true)]
    [TestCase(7, false)]
    [TestCase(9, false)]
    public void IsEven_Test_WithMultipleValues(int number, bool expectedResult)
    {
        bool result = utils.IsEven(number);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
