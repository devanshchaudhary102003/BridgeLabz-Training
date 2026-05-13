using NUnit.Framework;
using System.Threading;

// ======================
// Service Class
// ======================
public class PerformanceService
{
    public int LongRunningTask()
    {
        Thread.Sleep(3000);
        return 1;
    }
}

// ======================
// NUnit CancelAfter Test
// ======================
[TestFixture]
public class PerformanceServiceTests
{
    private PerformanceService service;

    [SetUp]
    public void Setup()
    {
        service = new PerformanceService();
    }

    // Test will FAIL after 2 seconds (without obsolete warning)
    [Test]
    [CancelAfter(2000)]
    public void LongRunningTask_Should_Complete_Within_2_Seconds()
    {
        int result = service.LongRunningTask();
        Assert.That(result, Is.EqualTo(1));
    }
}
