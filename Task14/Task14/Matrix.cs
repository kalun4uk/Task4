using System;

namespace Task14
{
    partial class Matrix
    {
        public int[,] matrix;   //matrix of numbers
        private int _sizeRows;
        private int _sizeColumns;
        public static Random rand = new Random();

        public Matrix(){}

        /// <summary>
        /// Create new class instance with the row/columns parameters
        /// </summary>
        /// <param name="a">Count of rows of the matrix</param>
        /// <param name="b">Count of columns of the matrix</param>
        public Matrix(int a, int b)
        {
            matrix = new int[a,b];
            _sizeRows = a;
            _sizeColumns = b;
            MatrixInitialization();
        }
    }
}
