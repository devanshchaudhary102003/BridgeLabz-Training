using System;
using Microsoft.Data.SqlClient;
using DBConnect.Interface;
using DBConnect.Models;

namespace DBConnect.Services
{
    public class PatientService : IPatientService
    {
        public void RegisterPatient(Patient p)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                string query = @"INSERT INTO Patients(name,dob,phone,email,address,blood_group)
                                 VALUES(@name,@dob,@phone,@email,@address,@blood_group)";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", p.Name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@dob", p.DOB ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@phone", p.Phone);
                command.Parameters.AddWithValue("@email", p.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@address", p.Address ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@blood_group", p.BloodGroup ?? (object)DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Patient Registered Successfully!");
            }
        }

        public void UpdatePatient(int id, string address)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                string query = "UPDATE Patients SET address = @address WHERE patient_id = @id";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Patient Updated Successfully!");
            }
        }

        public void SearchPatient(string name)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                string query = "SELECT patient_id, name, phone FROM Patients WHERE name LIKE @name";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", "%" + name + "%");

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["patient_id"]}, Name: {reader["name"]}, Phone: {reader["phone"]}");
                }
            }
        }
    }
}
