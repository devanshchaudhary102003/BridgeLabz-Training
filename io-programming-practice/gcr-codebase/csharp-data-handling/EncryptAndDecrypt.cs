using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Employee
{
    public int Id;
    public string Name;
    public string Department;

    // Sensitive
    public string Email;
    public decimal Salary;

    public Employee(int id, string name, string dept, string email, decimal salary)
    {
        Id = id;
        Name = name;
        Department = dept;
        Email = email;
        Salary = salary;
    }
}

public static class AesCrypto
{
    // IMPORTANT:
    // In real apps, do NOT hardcode keys. Store securely (env var, KeyVault, etc.)
    // 32 bytes = AES-256 key
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("0123456789ABCDEF0123456789ABCDEF");

    // 16 bytes = IV (AES block size)
    private static readonly byte[] Iv = Encoding.UTF8.GetBytes("ABCDEF0123456789");

    public static string EncryptToBase64(string plainText)
    {
        if (plainText == null) plainText = "";

        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = Iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] cipherBytes = Transform(inputBytes, encryptor);
                return Convert.ToBase64String(cipherBytes);
            }
        }
    }

    public static string DecryptFromBase64(string base64Cipher)
    {
        if (string.IsNullOrWhiteSpace(base64Cipher)) return "";

        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = Iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                byte[] cipherBytes = Convert.FromBase64String(base64Cipher);
                byte[] plainBytes = Transform(cipherBytes, decryptor);
                return Encoding.UTF8.GetString(plainBytes);
            }
        }
    }

    private static byte[] Transform(byte[] data, ICryptoTransform transform)
    {
        using (var ms = new MemoryStream())
        using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
        {
            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();
            return ms.ToArray();
        }
    }
}

public static class CsvSecureStore
{
    public static void WriteEmployeesEncrypted(string path, List<Employee> employees)
    {
        using (var sw = new StreamWriter(path, false, Encoding.UTF8))
        {
            sw.WriteLine("Id,Name,Department,EmailEncrypted,SalaryEncrypted");

            foreach (var e in employees)
            {
                string encEmail = AesCrypto.EncryptToBase64(e.Email);
                string encSalary = AesCrypto.EncryptToBase64(e.Salary.ToString(CultureInfo.InvariantCulture));

                // Simple CSV: avoid commas in Name/Dept for this demo
                sw.WriteLine(e.Id + "," + e.Name + "," + e.Department + "," + encEmail + "," + encSalary);
            }
        }
    }

    public static List<Employee> ReadEmployeesDecrypted(string path)
    {
        var result = new List<Employee>();

        using (var sr = new StreamReader(path, Encoding.UTF8))
        {
            string header = sr.ReadLine(); // skip header

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Trim().Length == 0) continue;

                string[] parts = line.Split(',');
                if (parts.Length != 5)
                    throw new FormatException("Invalid CSV format: expected 5 columns.");

                int id = int.Parse(parts[0]);
                string name = parts[1];
                string dept = parts[2];

                string email = AesCrypto.DecryptFromBase64(parts[3]);

                string salaryText = AesCrypto.DecryptFromBase64(parts[4]);
                decimal salary = decimal.Parse(salaryText, CultureInfo.InvariantCulture);

                result.Add(new Employee(id, name, dept, email, salary));
            }
        }

        return result;
    }
}

class EncryptAndDecrypt
{
    public static void Main()
    {
        string path = "employees_secure.csv";

        var employees = new List<Employee>
        {
            new Employee(1, "Amit", "IT", "amit@company.com", 75000m),
            new Employee(2, "Neha", "HR", "neha@company.com", 52000m),
            new Employee(3, "Ravi", "Sales", "ravi@company.com", 61000m),
            new Employee(4, "Priya", "Finance", "priya@company.com", 88000m),
            new Employee(5, "Karan", "Support", "karan@company.com", 45000m),
        };

        // 1) Write (encrypted)
        CsvSecureStore.WriteEmployeesEncrypted(path, employees);
        Console.WriteLine("Encrypted CSV written to: " + path);

        // Show raw file content (you'll see Base64 in sensitive fields)
        Console.WriteLine("\n--- Raw CSV (Encrypted Fields) ---");
        Console.WriteLine(File.ReadAllText(path));

        // 2) Read (decrypt)
        Console.WriteLine("--- Decrypted Read Output ---");
        var decrypted = CsvSecureStore.ReadEmployeesDecrypted(path);

        foreach (var e in decrypted)
        {
            Console.WriteLine("Id: " + e.Id +
                              " | Name: " + e.Name +
                              " | Dept: " + e.Department +
                              " | Email: " + e.Email +
                              " | Salary: " + e.Salary);
        }
    }
}
