using System;
class SortEmployeeIDs
{
    public static void Sort(int[] employeeID)
    {
        int n = employeeID.Length;

        for(int i = 1; i < n; i++)
        {
            int key = employeeID[i];
            int j = i-1;
            
            while(j >= 0 && employeeID[j] > key)
            {
                employeeID[j+1] = employeeID[j];
                j--;
            }
            employeeID[j+1] = key;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter The Length: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] employeeID = new int[n];
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Employees ID: ");
            employeeID[i] = Convert.ToInt32(Console.ReadLine());
        }

        Sort(employeeID);
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Sorted Employee IDs: "+employeeID[i]+" ");
        }
    }
}