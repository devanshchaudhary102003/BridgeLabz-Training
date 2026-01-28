using NUnit.Framework;

// ======================
// DatabaseConnection Class
// ======================
public class DatabaseConnection
{
    public bool IsConnected { get; private set; }

    public void Connect()
    {
        IsConnected = true;
    }

    public void Disconnect()
    {
        IsConnected = false;
    }
}

// ======================
// NUnit Test Class
// ======================
[TestFixture]
public class DatabaseConnectionTests
{
    private DatabaseConnection db;

    // Runs BEFORE each test
    [SetUp]
    public void Setup()
    {
        db = new DatabaseConnection();
        db.Connect();
    }

    // Runs AFTER each test
    [TearDown]
    public void TearDown()
    {
        db.Disconnect();
    }

    [Test]
    public void Connection_Is_Established_In_Setup()
    {
        Assert.That(db.IsConnected, Is.True);
    }

    [Test]
    public void Connection_Is_Closed_In_Teardown()
    {
        // Setup already connected it
        Assert.That(db.IsConnected, Is.True);

        // Manually call TearDown to verify behavior
        db.Disconnect();
        Assert.That(db.IsConnected, Is.False);
    }
}
