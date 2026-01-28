using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

// ======================
// UserRegistration Class
// ======================
public class UserRegistration
{
    public void RegisterUser(string username, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username is invalid");

        if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            throw new ArgumentException("Email is invalid");

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            throw new ArgumentException("Password is invalid");

        // In real app → save user to DB
        // Here we just validate inputs
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(
            email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase
        );
    }
}

// ======================
// NUnit Test Class
// ======================
[TestFixture]
public class UserRegistrationTests
{
    private UserRegistration registration;

    [SetUp]
    public void SetUp()
    {
        registration = new UserRegistration();
    }

    //  Valid Registration
    [Test]
    public void RegisterUser_ValidInputs_DoesNotThrow()
    {
        Assert.That(
            () => registration.RegisterUser(
                "devansh",
                "devansh@example.com",
                "secret123"
            ),
            Throws.Nothing
        );
    }

    //  Invalid Username
    [Test]
    public void RegisterUser_InvalidUsername_ThrowsException()
    {
        Assert.That(
            () => registration.RegisterUser(
                "",
                "user@example.com",
                "secret123"
            ),
            Throws.TypeOf<ArgumentException>()
        );
    }

    //  Invalid Email
    [Test]
    public void RegisterUser_InvalidEmail_ThrowsException()
    {
        Assert.That(
            () => registration.RegisterUser(
                "user",
                "invalid-email",
                "secret123"
            ),
            Throws.TypeOf<ArgumentException>()
        );
    }

    //  Invalid Password
    [Test]
    public void RegisterUser_InvalidPassword_ThrowsException()
    {
        Assert.That(
            () => registration.RegisterUser(
                "user",
                "user@example.com",
                "123"
            ),
            Throws.TypeOf<ArgumentException>()
        );
    }

    // Null Inputs
    [Test]
    public void RegisterUser_NullInputs_ThrowsException()
    {
        Assert.That(
            () => registration.RegisterUser(null, null, null),
            Throws.TypeOf<ArgumentException>()
        );
    }
}
