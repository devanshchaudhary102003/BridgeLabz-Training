using System;
using Microsoft.Data.SqlClient;
using DBConnect.Interface;

namespace DBConnect.Services
{
    public class BillingService : IBillingService
    {
        public void GenerateBill(int visitId, decimal amount)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                string query = @"INSERT INTO Bills(visit_id,total_amount,payment_status)
                                 VALUES(@visit,@amount,'PENDING')";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@visit", visitId);
                command.Parameters.AddWithValue("@amount", amount);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Bill Generated!");
            }
        }

        public void RecordPayment(int billId)
        {
            using (SqlConnection connection = DBConnectionUtil.GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string query = @"UPDATE Bills
                                     SET payment_status = 'PAID',
                                         payment_date = GETDATE()
                                     WHERE bill_id = @id";

                    using SqlCommand upd = new SqlCommand(query, connection, transaction);
                    upd.Parameters.AddWithValue("@id", billId);
                    upd.ExecuteNonQuery();

                    string query1 = @"INSERT INTO Payment_Transaction(bill_id,payment_mode,payment_time)
                                      VALUES(@id,'UPI',GETDATE())";

                    using SqlCommand ins = new SqlCommand(query1, connection, transaction);
                    ins.Parameters.AddWithValue("@id", billId);
                    ins.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Payment Recorded!");
                }
                catch
                {
                    transaction.Rollback();
                    Console.WriteLine("Payment Failed!");
                }
            }
        }
    }
}
