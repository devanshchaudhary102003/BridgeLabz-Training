using System;

//Node class
class StudentNode
{
    public int RollNo;
    public string Name;
    public int Age;
    public string Grade;
    public StudentNode Next;

    public StudentNode(int RollNo, string Name, int Age, string Grade)
    {
        this.RollNo = RollNo;
        this.Name = Name;
        this.Age = Age;
        this.Grade = Grade;
        Next = null;
    }
}

//Singly Linked List Class
class StudentLinkedList
{
    private StudentNode Head;

    //Add at Beginning
    public void AddAtBeginning(int RollNo, string Name, int Age, string Grade)
    {
        StudentNode newNode = new StudentNode(RollNo,Name,Age,Grade);
        newNode.Next = Head;
        Head = newNode;
        Console.WriteLine("Student added at beginning.");
    }

    //Add at End
    public void AddAtEnd(int RollNo, string Name, int Age, string Grade)
    {
        StudentNode newNode = new StudentNode(RollNo,Name,Age,Grade);
        if(Head == null)
        {
            Head = newNode;
            Console.WriteLine("Student Added at end.");
            return;
        }

        StudentNode temp = Head;
        while(temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
        Console.WriteLine("Student added at end.");
    }

    //Add at Specific Position
    public void AddAtPosition(int Position,int RollNo,string Name,int Age,string Grade)
    {
        if(Position <= 0)
        {
            Console.WriteLine("Invalid Positon.");
            return;
        }

        if(Position == 1)
        {
            AddAtBeginning(RollNo,Name,Age,Grade);
            return;
        }

        StudentNode newNode = new StudentNode(RollNo,Name,Age,Grade);
        StudentNode temp = Head;

        for(int i = 1 ; i < Position - 1 && temp != null; i++)
        {
            temp = temp.Next;
        }

        if(temp == null)
        {
            Console.WriteLine("Position Out of Range.");
            return;
        }

        newNode.Next = temp.Next;
        temp.Next = newNode;
        Console.WriteLine("Student added at position "+Position);
    }

    //Delete by Roll Number
    public void DeleteByRollNo(int RollNo)
    {
        if(Head == null)
        {
            Console.WriteLine("List is Empty.");
            return;
        }

        if(Head.RollNo == RollNo)
        {
            Head = Head.Next;
            Console.WriteLine("Student Deleted.");
            return;
        }

        StudentNode temp = Head;
        while(temp.Next != null && temp.Next.RollNo != RollNo)
        {
            temp = temp.Next;
        }

        if(temp.Next == null)
        {
            Console.WriteLine("Student not found.");
        }
        else
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Student deleted.");
        }
    }

    //Search By Roll Number
    public void SearchByRollNo(int RollNo)
    {
        StudentNode temp = Head;

        while(temp != null)
        {
            if(temp.RollNo == RollNo)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine("Roll No: "+temp.RollNo);
                Console.WriteLine("Name: "+temp.Name);
                Console.WriteLine("Age: "+temp.Age);
                Console.WriteLine("Grade: "+temp.Grade);
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Student Not Found.");
    }

    //Update Grade
    public void UpdateGrade(int RollNo,string newGrade)
    {
        StudentNode temp = Head;

        while(temp != null)
        {
            if(temp.RollNo == RollNo)
            {
                temp.Grade = newGrade;
                Console.WriteLine("Grade Updated Successfully.");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Student Not Found.");
    }

    //Display all Records
    public void DisplayAll()
    {
        if(Head == null)
        {
            Console.WriteLine("No Student records available.");
            return;
        }

        StudentNode temp = Head;

        while(temp != null)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Roll No: "+temp.RollNo);
            Console.WriteLine("Name: "+temp.Name);
            Console.WriteLine("Age: "+temp.Age);
            Console.WriteLine("Grade: "+temp.Grade);

            temp = temp.Next;
        }
    }
}
class StudentRecordManagement
{
    static void Main(string[] args)
    {
        StudentLinkedList list = new StudentLinkedList();

        list.AddAtBeginning(1,"Devansh",20,"A");
        list.AddAtEnd(2,"Rahul",21,"B");
        list.AddAtPosition(2,3,"Ankit",19,"A+");

        Console.WriteLine("\nAll Student Records: ");
        list.DisplayAll();

        Console.WriteLine("\nSearch Roll No 2: ");
        list.SearchByRollNo(2);

        Console.WriteLine("\nUpdate Grade of Roll No 1: ");
        list.UpdateGrade(1,"A+");

        Console.WriteLine("\nDelete Roll No 3: ");
        list.DeleteByRollNo(3);

        Console.WriteLine("\nFinal Student Records: ");
        list.DisplayAll();
    }
}