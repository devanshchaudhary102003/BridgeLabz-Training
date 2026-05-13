using HealthCheckPro.Attributes;
namespace HealthCheckPro.Controllers;

public class LabTestController
{
    [PublicAPI("Get all avilable lab tests")]
    public void GetAllTests()
    {
        
    }

    [PublicAPI("Book a lab test")]
    [AuthAPI("Patient")]
    public void BookTest()
    {
        
    }

    public void DeleteTest()
    {
        // Missing annotation (intentional)
    }
}