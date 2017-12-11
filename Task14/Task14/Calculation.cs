using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task14
{
    partial class Matrix
    {
        /// <summary>
        /// Initialization of matrix with random numbers
        /// </summary>
        private void MatrixInitialization()
        {   
            for (var i = 0; i < _sizeRows; i++)
                for (var j = 0; j < _sizeColumns; j++)
                    matrix[i, j] = rand.Next() % 10 + 1;
        }

        /// <summary>
        /// Addition of two matrixes
        /// </summary>
        /// <param name="first">First matrix to add</param>
        /// <param name="second">Second matrix to add</param>
        /// <returns>New matrix of first matrix added to second</returns>
        public static Matrix operator +(Matrix first, Matrix second)
        {
            Matrix result = new Matrix(first._sizeRows, first._sizeColumns);
            try
            {
                first.CompareSize(second);
                for (var i = 0; i < first._sizeRows; i++)
                    for (var j = 0; j < first._sizeColumns; j++)
                        result.matrix[i, j] = first.matrix[i, j] + second.matrix[i,j];
            }
            catch (Exception mException)
            {
                Console.WriteLine($"Matrix A({first._sizeRows};{first._sizeColumns}) is not the same size to B({second._sizeRows};{second._sizeColumns})");
            }
            return result;
        }

        /// <summary>
        /// Substraction of two matrixes
        /// </summary>
        /// <param name="first">First matrix to substract</param>
        /// <param name="second">Second matrix to substract</param>
        /// <returns>New matrix of second substracted from the first</returns>
        public static Matrix operator -(Matrix first, Matrix second)
        {
            Matrix result = new Matrix(first._sizeRows, first._sizeColumns);
            try
            {
                first.CompareSize(second);
                for (var i = 0; i < first._sizeRows; i++)
                    for (var j = 0; j < first._sizeColumns; j++)
                        result.matrix[i, j] = first.matrix[i, j] - second.matrix[i, j];
            }
            catch (Exception mException)
            {
                Console.WriteLine($"Matrix A({first._sizeRows};{first._sizeColumns}) is not the same size to B({second._sizeRows};{second._sizeColumns})");
            }
            return result;
        }

        /// <summary>
        /// Get new matrix which is multipled on the decimal number
        /// </summary>
        /// <param name="number">Decimal number to multiple on</param>
        /// <returns>New matrix: multiplication of the matrix and the number</returns>
        public Matrix MultiplicationOnANumber(int number)
        {
            Matrix result = new Matrix(_sizeRows, _sizeColumns);
            for (var i = 0; i < _sizeRows; i++)
                    for (var j = 0; j < _sizeColumns; j++)
                        result.matrix[i,j] = matrix[i, j] * number;
            return result;
        }

        /// <summary>
        /// Multiplication of the matrixes
        /// </summary>
        /// <param name="first">First matrix to multiplication</param>
        /// <param name="second">Second matrix to multiplication</param>
        /// <returns>New matrix </returns>
        public static Matrix operator *(Matrix first, Matrix second)
        {
            Matrix result = new Matrix(first._sizeRows, second._sizeColumns);
            try
            {   
                for (var i = 0; i < first._sizeRows; i++)
                    for (var j = 0; j < second._sizeColumns; j++)
                        for (var k = 0; k < first._sizeRows; k++)
                            result.matrix[i, j] += first.matrix[i, k]*second.matrix[k, j];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of range exception");
            }
            return result;
        }

        /// <summary>
        /// Verification of the matrixes
        /// </summary>
        /// <param name="first">First matrix of verification</param>
        /// <param name="second">Second matrix of verification</param>
        /// <returns>Bool value of the verification result</returns>
        public static bool operator ==(Matrix first, Matrix second)
        {
            if (!first.CompareSizeToMultiplication(second)) return false;
            for (var i = 0; i < first._sizeColumns; i++)
                for (var j = 0; j < first._sizeColumns; j++)
                    if (first.matrix[i, j] != second.matrix[i, j]) return false;
            return true;
        }

        /// <summary>
        /// Verification of the matrixes
        /// </summary>
        /// <param name="first">First matrix of verification</param>
        /// <param name="second">Second matrix of verification</param>
        /// <returns>Bool value of the verification result</returns>
        public static bool operator !=(Matrix first, Matrix second)
        {
            if (first.CompareSizeToMultiplication(second)) return true;
            bool check = false;
            for (var i = 0; i < first._sizeColumns; i++)
                for (var j = 0; j < first._sizeColumns; j++)
                    if (first.matrix[i, j] != second.matrix[i, j]) check = true;
            return check;
        }

        /// <summary>
        /// Tension of the matrix
        /// </summary>
        /// <returns>New matrix</returns>
        public Matrix TensionMatrix()
        {
            Matrix result = new Matrix(_sizeColumns, _sizeRows);
            try
            {
                for (var i = 0; i < _sizeColumns; i++)
                    for (var j = 0; j < _sizeRows; j++)
                    {
                        result.matrix[i, j] = matrix[j, i];
                    }
            }
            catch (IndexOutOfRangeException)
            {
                Console.Write("Index out of range");
            }
            return result;
        }

        /// <summary>
        /// Get submatrix of the matrix with the entered indexes
        /// </summary>
        /// <param name="sizeRow1">First row of submatrix</param>
        /// <param name="sizeRow2">Second column of submatrix</param>
        /// <param name="sizeColumn1">First row of submatrix</param>
        /// <param name="sizeColumn2">Second Column of submatrix</param>
        /// <returns>Submatrix of the entered row/column values</returns>
        public Matrix SubMatrix(int sizeRow1, int sizeRow2, int sizeColumn1, int sizeColumn2)
        {
            try
            {
                VerifyIndexesSubMatrix(sizeRow1, sizeRow2, sizeColumn1, sizeColumn2);
                var sizeRow = SubMatrixSize(sizeRow1, sizeRow2);
                var sizeColumn = SubMatrixSize(sizeColumn1, sizeColumn2);
                var result = new Matrix(sizeRow, sizeColumn);
                for (var i = 0; i < sizeRow; i++)
                    for (var j = 0; j < sizeColumn; j++)
                        result.matrix[i, j] = matrix[i + sizeRow1, j + sizeColumn1];
                return result;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Entered indexes are bigger than you can enter");
            }
            return new Matrix();
        }

        /// <summary>
        /// Verify of the indexes of submatrix
        /// </summary>
        /// <param name="sizeRow1">First row of submatrix</param>
        /// <param name="sizeRow2">Second column of submatrix</param>
        /// <param name="sizeColumn1">First row of submatrix</param>
        /// <param name="sizeColumn2">Second Column of submatrix</param>
        /// <returns>Bool value of verification</returns>
        public bool VerifyIndexesSubMatrix(int sizeRow1, int sizeRow2, int sizeColumn1, int sizeColumn2)
        {
            if((sizeRow1 <= _sizeRows) || (sizeRow2 <= _sizeRows) || (sizeColumn1 <= _sizeColumns) || (sizeColumn2 <= _sizeColumns))
                return true;
            Console.WriteLine("Entered indexes are not valid");
            return false;
        }

        /// <summary>
        /// Verification and substraction and addition of 2 (two operands)
        /// </summary>
        /// <param name="a">Row/column value</param>
        /// <param name="b">Row/column value</param>
        /// <returns>Size of the matrix</returns>
        public int SubMatrixSize(int a, int b)
        {            
            return a > b ? (a - b) + 2 : (b - a) + 2;
        }

        public void PrintMatrix(string typePrint)
        {
            Console.WriteLine(typePrint);
            for (var i = 0; i < _sizeRows; i++)
            {
                for (var j = 0; j < _sizeColumns; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        public bool CompareSizeToMultiplication(Matrix compare)
        {
            //sizeRows of the first matrix has to be equal to the sizeColums of the second
            if (_sizeRows == compare._sizeColumns)
                return true;
            Console.WriteLine($"We are not able to multiply Matrix A on B");
            return false;
        }

        /// <summary>
        /// Verification of the sizes of the matrixes
        /// </summary>
        /// <param name="compare">Matrix to compare with</param>
        /// <returns>True/false result</returns>
        public bool CompareSize(Matrix compare)
        {
            if (_sizeRows != compare._sizeRows || _sizeColumns != compare._sizeColumns)                 
                throw new Exception("mException");
            return true;
        }
    }
}
