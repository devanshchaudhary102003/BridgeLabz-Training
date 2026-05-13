using NUnit.Framework;
using System.Linq;

// ======================
// PasswordValidator Class
// ======================
public class PasswordValidator
{
    public bool IsValid(string password)
    {
        if (string.IsNullOrEmpty(password))
            return false;

        bool hasMinLength = password.Length >= 8;
        bool hasUpperCase = password.Any(char.IsUpper);
        bool hasDigit = password.Any(char.IsDigit);

        return hasMinLength && hasUpperCase && hasDigit;
    }
}

// ======================
// NUnit Test Class
// ======================
[TestFixture]
public class PasswordValidatorTests
{
    private PasswordValidator validator;

    [SetUp]
    public void SetUp()
    {
        validator = new PasswordValidator();
    }

    //  Valid Password Tests
    [Test]
    public void ValidPassword_ShouldReturnTrue()
    {
        bool result = validator.IsValid("StrongP4ss");
        Assert.That(result, Is.True);
    }

    //  Invalid: Less than 8 characters
    [Test]
    public void Password_TooShort_ShouldReturnFalse()
    {
        bool result = validator.IsValid("Ab3");
        Assert.That(result, Is.False);
    }

    //  Invalid: No uppercase letter
    [Test]
    public void Password_NoUppercase_ShouldReturnFalse()
    {
        bool result = validator.IsValid("password1");
        Assert.That(result, Is.False);
    }

    //  Invalid: No digit
    [Test]
    public void Password_NoDigit_ShouldReturnFalse()
    {
        bool result = validator.IsValid("Password");
        Assert.That(result, Is.False);
    }

    // Invalid: Null password
    [Test]
    public void Password_Null_ShouldReturnFalse()
    {
        bool result = validator.IsValid(null);
        Assert.That(result, Is.False);
    }
}
