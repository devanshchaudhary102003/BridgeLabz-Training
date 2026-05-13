using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace AddressBook
{
    public class DataBaseDataSource : IDataSource
    {
        // Store connection string for SQL Server
        private readonly string connectionString;

        // Constructor to initialize connection string
        public DataBaseDataSource(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Save all address books and their contacts into database
        public void Save(Dictionary<string, List<AddressBook>> addressBooks)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Loop through each address book
                foreach (var book in addressBooks)
                {
                    string bookName = book.Key;
                    List<AddressBook> contacts = book.Value;

                    // Loop through each contact in that address book
                    foreach (var c in contacts)
                    {
                        string query = @"INSERT INTO AddressBookTable
                        (BookName, FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email)
                        VALUES
                        (@BookName, @FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            // Add parameter values safely
                            cmd.Parameters.AddWithValue("@BookName", bookName);
                            cmd.Parameters.AddWithValue("@FirstName", c.firstName ?? "");
                            cmd.Parameters.AddWithValue("@LastName", c.lastName ?? "");
                            cmd.Parameters.AddWithValue("@Address", c.address ?? "");
                            cmd.Parameters.AddWithValue("@City", c.city ?? "");
                            cmd.Parameters.AddWithValue("@State", c.state ?? "");
                            cmd.Parameters.AddWithValue("@Zip", c.zip ?? "");
                            cmd.Parameters.AddWithValue("@PhoneNumber", c.phoneNumber ?? "");
                            cmd.Parameters.AddWithValue("@Email", c.email ?? "");

                            // Execute insert query
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            Console.WriteLine("Address Book saved to Database successfully.");
        }

        // Load all contacts from database into dictionary format
        public Dictionary<string, List<AddressBook>> Load()
        {
            Dictionary<string, List<AddressBook>> addressBooks = new Dictionary<string, List<AddressBook>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM AddressBookTable";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Get address book name from DB
                        string bookName = reader["BookName"].ToString();

                        // Create contact object from DB row
                        AddressBook contact = new AddressBook
                        {
                            firstName = reader["FirstName"].ToString(),
                            lastName = reader["LastName"].ToString(),
                            address = reader["Address"].ToString(),
                            city = reader["City"].ToString(),
                            state = reader["State"].ToString(),
                            zip = reader["Zip"].ToString(),
                            phoneNumber = reader["PhoneNumber"].ToString(),
                            email = reader["Email"].ToString()
                        };

                        // If address book not present, create new list
                        if (!addressBooks.ContainsKey(bookName))
                        {
                            addressBooks[bookName] = new List<AddressBook>();
                        }

                        // Add contact to respective address book
                        addressBooks[bookName].Add(contact);
                    }
                }
            }

            Console.WriteLine("Address Book loaded from Database successfully.");
            return addressBooks;
        }
    }
}