using System;
using Microsoft.Data.SqlClient;
using DBConnect.Interface;

namespace DBConnect.Services
{
    public class VisitService : IVisitService
    {
        public void RecordVisit(int appointmentId, string diagnosis, string notes)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string query = @"INSERT INTO Visits(appointment_id,diagnosis,notes)
                                     VALUES(@appoint,@diagnosis,@notes)";

                    using SqlCommand command = new SqlCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@appoint", appointmentId);
                    command.Parameters.AddWithValue("@diagnosis", diagnosis);
                    command.Parameters.AddWithValue("@notes", notes ?? (object)DBNull.Value);
                    command.ExecuteNonQuery();

                    string query1 = @"UPDATE Appointments
                                      SET status = 'COMPLETED'
                                      WHERE appointment_id = @id";

                    using SqlCommand command1 = new SqlCommand(query1, connection, transaction);
                    command1.Parameters.AddWithValue("@id", appointmentId);
                    command1.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Visit Recorded!");
                }
                catch
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction Failed!");
                }
            }
        }
    }
}
