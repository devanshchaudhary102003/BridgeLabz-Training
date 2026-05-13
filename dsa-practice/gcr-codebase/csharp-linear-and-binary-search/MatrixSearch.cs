using System;

class MatrixSearch
{
    static bool SearchMatrix(int[,] matrix, int rows, int cols, int target)
    {
        for (int i = 0; i < rows; i++)
        {
            // Check if target can exist in this row
            if (target >= matrix[i, 0] && target <= matrix[i, cols - 1])
            {
                int left = 0;
                int right = cols - 1;

                // Binary Search in the row
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    if (matrix[i, mid] == target)
                        return true;
                    else if (matrix[i, mid] < target)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
        }
        return false;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of rows:");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of columns:");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        Console.WriteLine("Enter matrix elements row-wise:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("Enter target value:");
        int target = Convert.ToInt32(Console.ReadLine());

        bool found = SearchMatrix(matrix, rows, cols, target);

        if (found)
            Console.WriteLine("Target found in matrix");
        else
            Console.WriteLine("Target not found in matrix");
    }
}
