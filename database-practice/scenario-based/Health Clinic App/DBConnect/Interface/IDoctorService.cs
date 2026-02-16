using DBConnect.Models;

namespace DBConnect.Interface
{
    public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);
        void DeactivateDoctor(int doctorId);
        void ViewDoctorBySpecialty(string specialty);
    }
}
