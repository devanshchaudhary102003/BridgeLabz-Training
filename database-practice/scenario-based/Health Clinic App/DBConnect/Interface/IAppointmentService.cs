namespace DBConnect.Interface
{
    public interface IAppointmentService
    {
        void BookAppointment(int patientId, int doctorId, string date, string time);
        void CancelAppointment(int appointmentId);
        void ViewDailySchedule(string date);
    }
}
