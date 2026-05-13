using System;
using System.Collections.Generic;
using System.IO;

class CSVToStudent
{
    class Student
    {
        public int Id;
        public string Name;
        public int Age;
        public int Marks;

        public Student(int id, string name, int age, int marks)
        {
            Id = id;
            Name = name;
            Age = age;
            Marks = marks;
        }

        public override string ToString()
        {
            return "Student{Id=" + Id +
                   ", Name=" + Name +
                   ", Age=" + Age +
                   ", Marks=" + Marks + "}";
        }
    }

    static void Main(string[] args)
    {
        string filePath = "studentsss.csv";
        List<Student> students = new List<Student>();

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                bool headerSkipped = false;

                while ((line = sr.ReadLine()) != null)
                {
                    if (!headerSkipped)
                    {
                        headerSkipped = true; // skip header
                        continue;
                    }

                    string[] data = line.Split(',');

                    int id = int.Parse(data[0]);
                    string name = data[1];
                    int age = int.Parse(data[2]);
                    int marks = int.Parse(data[3]);

                    students.Add(new Student(id, name, age, marks));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Print all students
        foreach (Student s in students)
        {
            Console.WriteLine(s);
        }
    }
}
