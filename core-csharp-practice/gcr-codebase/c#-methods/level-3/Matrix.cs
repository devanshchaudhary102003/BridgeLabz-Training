using System;

class Matrix
{
    static void Main(string[] args)
    {
        Random rand = new Random();

        double[,] matrixA2x2 = CreateRandomMatrix(2, 2, rand);
        double[,] matrixB2x2 = CreateRandomMatrix(2, 2, rand);

        Console.WriteLine("Matrix A (2x2):");
        DisplayMatrix(matrixA2x2);
        Console.WriteLine("Matrix B (2x2):");
        DisplayMatrix(matrixB2x2);

        Console.WriteLine("Addition of 2x2 matrices:");
        DisplayMatrix(AddMatrices(matrixA2x2, matrixB2x2));

        Console.WriteLine("Subtraction of 2x2 matrices:");
        DisplayMatrix(SubtractMatrices(matrixA2x2, matrixB2x2));

        Console.WriteLine("Multiplication of 2x2 matrices:");
        DisplayMatrix(MultiplyMatrices(matrixA2x2, matrixB2x2));

        Console.WriteLine("Transpose of Matrix A:");
        DisplayMatrix(TransposeMatrix(matrixA2x2));

        Console.WriteLine("Determinant of Matrix A: " + Determinant2x2(matrixA2x2));

        Console.WriteLine("Inverse of Matrix A:");
        double[,] inv2x2 = Inverse2x2(matrixA2x2);
        if (inv2x2 != null)
            DisplayMatrix(inv2x2);
        else
            Console.WriteLine("Matrix is singular, inverse does not exist.");

        // Example for 3x3 matrices
        double[,] matrixA3x3 = CreateRandomMatrix(3, 3, rand);
        double[,] matrixB3x3 = CreateRandomMatrix(3, 3, rand);

        Console.WriteLine("Matrix A (3x3):");
        DisplayMatrix(matrixA3x3);
        Console.WriteLine("Matrix B (3x3):");
        DisplayMatrix(matrixB3x3);

        Console.WriteLine("Addition of 3x3 matrices:");
        DisplayMatrix(AddMatrices(matrixA3x3, matrixB3x3));

        Console.WriteLine("Subtraction of 3x3 matrices:");
        DisplayMatrix(SubtractMatrices(matrixA3x3, matrixB3x3));

        Console.WriteLine("Multiplication of 3x3 matrices:");
        DisplayMatrix(MultiplyMatrices(matrixA3x3, matrixB3x3));

        Console.WriteLine("Transpose of Matrix A:");
        DisplayMatrix(TransposeMatrix(matrixA3x3));

        Console.WriteLine("Determinant of Matrix A: " + Determinant3x3(matrixA3x3));

        Console.WriteLine("Inverse of Matrix A:");
        double[,] inv3x3 = Inverse3x3(matrixA3x3);
        if (inv3x3 != null)
            DisplayMatrix(inv3x3);
        else
            Console.WriteLine("Matrix is singular, inverse does not exist.");
    }

    public static double[,] CreateRandomMatrix(int rows, int cols, Random rand)
    {
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = rand.Next(1, 10);
        return matrix;
    }

    public static double[,] AddMatrices(double[,] A, double[,] B)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = A[i, j] + B[i, j];
        return result;
    }

    public static double[,] SubtractMatrices(double[,] A, double[,] B)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = A[i, j] - B[i, j];
        return result;
    }

    public static double[,] MultiplyMatrices(double[,] A, double[,] B)
    {
        int rowsA = A.GetLength(0);
        int colsA = A.GetLength(1);
        int rowsB = B.GetLength(0);
        int colsB = B.GetLength(1);

        if (colsA != rowsB) throw new Exception("Matrix multiplication not possible");

        double[,] result = new double[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
            for (int j = 0; j < colsB; j++)
                for (int k = 0; k < colsA; k++)
                    result[i, j] += A[i, k] * B[k, j];

        return result;
    }

    public static double[,] TransposeMatrix(double[,] A)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        double[,] result = new double[cols, rows];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[j, i] = A[i, j];

        return result;
    }

    public static double Determinant2x2(double[,] A)
    {
        return A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
    }

    public static double Determinant3x3(double[,] A)
    {
        return A[0,0]*(A[1,1]*A[2,2] - A[1,2]*A[2,1])
             - A[0,1]*(A[1,0]*A[2,2] - A[1,2]*A[2,0])
             + A[0,2]*(A[1,0]*A[2,1] - A[1,1]*A[2,0]);
    }

    public static double[,] Inverse2x2(double[,] A)
    {
        double det = Determinant2x2(A);
        if (det == 0) return null;

        double[,] inv = new double[2, 2];
        inv[0, 0] = A[1, 1] / det;
        inv[0, 1] = -A[0, 1] / det;
        inv[1, 0] = -A[1, 0] / det;
        inv[1, 1] = A[0, 0] / det;

        return inv;
    }

    public static double[,] Inverse3x3(double[,] A)
    {
        double det = Determinant3x3(A);
        if (det == 0) return null;

        double[,] inv = new double[3, 3];

        inv[0,0] = (A[1,1]*A[2,2]-A[1,2]*A[2,1])/det;
        inv[0,1] = (A[0,2]*A[2,1]-A[0,1]*A[2,2])/det;
        inv[0,2] = (A[0,1]*A[1,2]-A[0,2]*A[1,1])/det;

        inv[1,0] = (A[1,2]*A[2,0]-A[1,0]*A[2,2])/det;
        inv[1,1] = (A[0,0]*A[2,2]-A[0,2]*A[2,0])/det;
        inv[1,2] = (A[0,2]*A[1,0]-A[0,0]*A[1,2])/det;

        inv[2,0] = (A[1,0]*A[2,1]-A[1,1]*A[2,0])/det;
        inv[2,1] = (A[0,1]*A[2,0]-A[0,0]*A[2,1])/det;
        inv[2,2] = (A[0,0]*A[1,1]-A[0,1]*A[1,0])/det;

        return inv;
    }

    public static void DisplayMatrix(double[,] A)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(A[i, j].ToString("F2") + "\t");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
