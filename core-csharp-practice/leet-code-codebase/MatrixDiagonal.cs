/*Given a square matrix mat, return the sum of the matrix diagonals.
Only include the sum of all the elements on the primary diagonal and all the elements on the secondary diagonal that are not part of the primary diagonal.*/
using System;

class MatrixDiagonal
{
    static void Main(string[] args)
    {
        // Taking matrix size
        Console.WriteLine("Enter number of rows:");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of columns:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[][] mat = new int[m][];

        // Initializing and taking matrix input
        Console.WriteLine("Enter matrix elements:");
        for (int i = 0; i < m; i++)
        {
            mat[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                mat[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int ans = DiagonalSum(mat);

        Console.WriteLine("Diagonal Sum = " + ans);
    }

    static int DiagonalSum(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        int ans = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j || i + j == n - 1)
                {
                    ans += mat[i][j];
                }
            }
        }
        return ans;
    }
}
