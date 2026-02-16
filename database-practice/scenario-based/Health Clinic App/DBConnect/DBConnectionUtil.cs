using Microsoft.Data.SqlClient;

namespace DBConnect
{
    internal static class DBConnectionUtil
    {
        private static readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=HealthClinic;Trusted_Connection=true;TrustServerCertificate=true";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
