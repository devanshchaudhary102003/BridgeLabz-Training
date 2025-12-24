using System;
class StudentsAge
{
    static void Main(string[] args)
    {
        int[] arr = new int[10];
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        for(int i = 0; i < arr.Length; i++)

        {
            if(arr[i] >= 18)
            {
                Console.WriteLine("The student with the age "+arr[i]+" can vote");
            }
            else
            {
                Console.WriteLine("The student with the age "+arr[i]+" cannot vote");
            }
        }
    }
}