using System;
class MultiDimensional
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of Rows:");
        int Rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of Columns:");
        int Columns = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[Rows,Columns];

        Console.WriteLine("Enter the elements of the 2D Array:");
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int[] arr = new int[Rows*Columns];
        int idx = 0;

        for(int i = 0; i < Rows; i++)
        {
            for(int j = 0; j < Columns; j++)
            {
                arr[idx] = matrix[i,j];
                idx++;
            }
        }

        Console.WriteLine("2D Arrays");
        for(int i = 0; i < Rows; i++)
        {
            for(int j = 0; j < Columns; j++)
            {
                Console.Write(matrix[i,j]+" ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("1D Array");
        for(int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]+" ");
        }
    }
}