using System;
using Microsoft.Data.SqlClient;
using DBConnect.Interface;
using DBConnect.Models;

namespace DBConnect.Services
{
    public class DoctorService : IDoctorService
    {
        public void AddDoctor(Doctor d)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                string query = @"INSERT INTO Doctors(name,specialty_id,phone,consultation_fee,is_active)
                                 VALUES(@name,@spec,@phone,@consfee,1)";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", d.Name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@spec", d.SpecialtyId);
                command.Parameters.AddWithValue("@phone", d.Phone);
                command.Parameters.AddWithValue("@consfee", d.ConsultationFee);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Doctor Added Successfully!");
            }
        }

        public void DeactivateDoctor(int doctorId)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                string query = "UPDATE Doctors SET is_active = 0 WHERE doctor_id = @id";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", doctorId);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Doctor Deactivated!");
            }
        }

        public void ViewDoctorBySpecialty(string specialty)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                string query = @"SELECT d.name AS DoctorName, s.specialty_name
                                 FROM Doctors d
                                 JOIN Specialties s ON d.specialty_id = s.specialty_id
                                 WHERE s.specialty_name = @spec AND d.is_active = 1";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@spec", specialty);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Doctor: {reader["DoctorName"]}, Specialty: {reader["specialty_name"]}");
                }
            }
        }
    }
}
