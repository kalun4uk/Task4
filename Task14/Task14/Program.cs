using System;

namespace Task14
{
    class Program
    {
        static void Main(string[] args)
        {

            Matrix matrix1 = new Matrix(10,8);
            Matrix matrix2 = new Matrix(8,10);
            matrix1.PrintMatrix("Matrix1");
            matrix2.PrintMatrix("Matrix2");
            (matrix1+matrix2).PrintMatrix("Matrix Sum");
            (matrix1 - matrix2).PrintMatrix("Matrix Substraction");
            (matrix1.MultiplicationOnANumber(5)).PrintMatrix("Multiplication on a number");
            (matrix1 * matrix2).PrintMatrix("Matrix multiplication");
            Console.WriteLine($"Matrix1 == Matrix2 : {matrix1 == matrix2}");
            Console.WriteLine($"Matrix != Matrix2 : {matrix1 != matrix2}");
            (matrix1.SubMatrix(1,3,1,4)).PrintMatrix("Get submatrix");
            (matrix1.TensionMatrix()).PrintMatrix("Matrix tension");

            Console.ReadKey();
        }
    }
}
