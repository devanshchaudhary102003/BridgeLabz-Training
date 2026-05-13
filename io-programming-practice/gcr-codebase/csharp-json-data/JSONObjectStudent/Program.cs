using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonExample
{
    // Student Model
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Subjects { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // Create Student Object
            Student student = new Student
            {
                Name = "Devansh Singh",
                Age = 22,
                Subjects = new List<string>
                {
                    "Mathematics",
                    "Computer Science",
                    "Physics"
                }
            };

            // Convert Object to JSON
            string json = JsonConvert.SerializeObject(student, Formatting.Indented);

            Console.WriteLine(json);
        }
    }
}