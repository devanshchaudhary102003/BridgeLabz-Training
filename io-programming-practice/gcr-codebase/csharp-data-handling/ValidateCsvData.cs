// ValidateCsvData.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ValidateCsvData
{
    // Simple + practical email regex (good for most CSV validation needs)
    // Note: "perfect" email validation is complex; this is the common approach.
    private static readonly Regex EmailRegex =
        new Regex("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$", RegexOptions.Compiled);

    // Exactly 10 digits
    private static readonly Regex Phone10DigitsRegex =
        new Regex("^\\d{10}$", RegexOptions.Compiled);

    static void Main(string[] args)
    {
        // Change this to your CSV path or pass it via command-line
        string path = args.Length > 0 ? args[0] : "data.csv";

        if (!File.Exists(path))
        {
            Console.WriteLine("File not found: " + path);
            return;
        }

        List<string> lines = new List<string>(File.ReadAllLines(path));
        if (lines.Count == 0)
        {
            Console.WriteLine("CSV is empty.");
            return;
        }

        // Parse header and find column indexes
        string[] header = SplitCsvLine(lines[0]);
        int emailIndex = FindColumnIndex(header, "Email");
        int phoneIndex = FindColumnIndex(header, "Phone Numbers"); // exact name asked

        if (emailIndex == -1)
        {
            Console.WriteLine("Error: 'Email' column not found in header.");
            PrintHeader(header);
            return;
        }

        if (phoneIndex == -1)
        {
            Console.WriteLine("Error: 'Phone Numbers' column not found in header.");
            PrintHeader(header);
            return;
        }

        bool foundInvalid = false;

        for (int i = 1; i < lines.Count; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            string[] row = SplitCsvLine(lines[i]);

            // Make sure row has enough columns
            if (emailIndex >= row.Length || phoneIndex >= row.Length)
            {
                foundInvalid = true;
                Console.WriteLine("Row " + (i + 1) + " INVALID: Missing required columns.");
                Console.WriteLine("  Raw: " + lines[i]);
                continue;
            }

            string email = (row[emailIndex] ?? "").Trim();
            string phoneRaw = (row[phoneIndex] ?? "").Trim();

            // If phone numbers might contain spaces/dashes like 98765-43210, remove non-digits:
            // But requirement says "contain exactly 10 digits", so we can normalize to digits and check length.
            string phoneDigitsOnly = KeepDigitsOnly(phoneRaw);

            List<string> errors = new List<string>();

            if (!IsValidEmail(email))
                errors.Add("Invalid Email");

            if (!IsValidPhone10Digits(phoneDigitsOnly))
                errors.Add("Invalid Phone (must be exactly 10 digits)");

            if (errors.Count > 0)
            {
                foundInvalid = true;
                Console.WriteLine("Row " + (i + 1) + " INVALID: " + string.Join(", ", errors));
                Console.WriteLine("  Email: " + email);
                Console.WriteLine("  Phone: " + phoneRaw + " (digits: " + phoneDigitsOnly + ")");
                Console.WriteLine("  Raw: " + lines[i]);
            }
        }

        if (!foundInvalid)
        {
            Console.WriteLine("All rows are valid.");
        }
    }

    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        return EmailRegex.IsMatch(email);
    }

    private static bool IsValidPhone10Digits(string phoneDigitsOnly)
    {
        if (string.IsNullOrWhiteSpace(phoneDigitsOnly)) return false;
        return Phone10DigitsRegex.IsMatch(phoneDigitsOnly);
    }

    private static int FindColumnIndex(string[] header, string columnName)
    {
        for (int i = 0; i < header.Length; i++)
        {
            string name = (header[i] ?? "").Trim();

            // Case-insensitive match
            if (string.Equals(name, columnName, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

    private static void PrintHeader(string[] header)
    {
        Console.WriteLine("Header columns found:");
        for (int i = 0; i < header.Length; i++)
        {
            Console.WriteLine("  [" + i + "] " + header[i]);
        }
    }

    // Keeps only digits from a string
    private static string KeepDigitsOnly(string s)
    {
        if (s == null) return "";
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c >= '0' && c <= '9') sb.Append(c);
        }
        return sb.ToString();
    }

    // Basic CSV splitter that supports quoted fields with commas:
    // Example: "a,b",c  -> [a,b] [c]
    private static string[] SplitCsvLine(string line)
    {
        List<string> fields = new List<string>();
        if (line == null) return fields.ToArray();

        StringBuilder current = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char ch = line[i];

            if (ch == '"')
            {
                // Handle escaped quote: ""
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    current.Append('"');
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (ch == ',' && !inQuotes)
            {
                fields.Add(current.ToString());
                current.Clear();
            }
            else
            {
                current.Append(ch);
            }
        }

        fields.Add(current.ToString());
        return fields.ToArray();
    }
}
