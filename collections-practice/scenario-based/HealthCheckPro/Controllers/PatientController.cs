using HealthCheckPro.Attributes;
namespace HealthCheckPro.Controllers;

public class PatientController
{
    [PublicAPI("Register a New Patient")]
    public void Register()
    {
        
    }

    [AuthAPI("Doctor")]
    public void GetMedicalHistory()
    {
        
    }
}