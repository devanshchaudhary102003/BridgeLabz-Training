using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

class GenerateEmployeeCsvReport
{
    static void Main(string[] args)
    {
        // 1) Update these two values
        string connectionString = "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;";
        string outputCsvPath = "employees_report.csv";

        // 2) Update table/column names if your schema is different
        string query =
            "SELECT EmployeeId, Name, Department, Salary " +
            "FROM Employees " +
            "ORDER BY EmployeeId";

        try
        {
            DataTable employees = FetchEmployees(connectionString, query);
            WriteEmployeesToCsv(employees, outputCsvPath);

            Console.WriteLine("CSV report generated successfully: " + outputCsvPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static DataTable FetchEmployees(string connectionString, string query)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        {
            conn.Open();
            adapter.Fill(dt);
        }

        return dt;
    }

    static void WriteEmployeesToCsv(DataTable dt, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            // Header row as required
            writer.WriteLine("Employee ID,Name,Department,Salary");

            foreach (DataRow row in dt.Rows)
            {
                string employeeId = EscapeCsv(row["EmployeeId"]);
                string name = EscapeCsv(row["Name"]);
                string department = EscapeCsv(row["Department"]);
                string salary = EscapeCsv(row["Salary"]);

                writer.WriteLine(employeeId + "," + name + "," + department + "," + salary);
            }
        }
    }

    // Properly escapes commas, quotes, and new lines in CSV fields
    static string EscapeCsv(object value)
    {
        if (value == null || value == DBNull.Value) return "";

        string s = value.ToString();

        bool mustQuote = s.Contains(",") || s.Contains("\"") || s.Contains("\n") || s.Contains("\r");
        if (s.Contains("\""))
            s = s.Replace("\"", "\"\"");

        return mustQuote ? "\"" + s + "\"" : s;
    }
}
