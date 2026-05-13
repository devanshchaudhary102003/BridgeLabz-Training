using System;
using Microsoft.Data.SqlClient;
using DBConnect.Interface;

namespace DBConnect.Services
{
    public class AppointmentService : IAppointmentService
    {
        public void BookAppointment(int patientId, int doctorId, string date, string time)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                string query = @"INSERT INTO Appointments(patient_id,doctor_id,appointment_date,appointment_time,status)
                                 VALUES(@patientId,@doctorId,@date,@time,'BOOKED')";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patientId);
                command.Parameters.AddWithValue("@doctorId", doctorId);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@time", time);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Appointment Booked!");
            }
        }

        public void CancelAppointment(int appointmentId)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string query = "UPDATE Appointments SET status = 'CANCELLED' WHERE appointment_id = @id";
                    using SqlCommand command = new SqlCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@id", appointmentId);
                    command.ExecuteNonQuery();

                    string query1 = @"INSERT INTO Audit_Log(table_name, operation, ref_id, log_time)
                                      VALUES('Appointments','CANCELLED',@id,GETDATE())";
                    using SqlCommand log = new SqlCommand(query1, connection, transaction);
                    log.Parameters.AddWithValue("@id", appointmentId);
                    log.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Appointment Cancelled!");
                }
                catch
                {
                    transaction.Rollback();
                    Console.WriteLine("Error Occurred!");
                }
            }
        }

        public void ViewDailySchedule(string date)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                string query = @"SELECT p.name AS PatientName,
                                        d.name AS DoctorName,
                                        a.appointment_time
                                 FROM Appointments a
                                 JOIN Patients p ON a.patient_id = p.patient_id
                                 JOIN Doctors d ON a.doctor_id = d.doctor_id
                                 WHERE a.appointment_date = @date AND a.status = 'BOOKED'
                                 ORDER BY a.appointment_time";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", date);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Patient: {reader["PatientName"]}, Doctor: {reader["DoctorName"]}, Time: {reader["appointment_time"]}");
                }
            }
        }
    }
}
