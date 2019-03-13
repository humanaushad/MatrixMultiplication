using System;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MatrixCalculation
{
    public class Calculation
    {
        public double[,] MatrixA { get; set; }
        public double[,] MatrixB { get; set; }

        public Calculation(int size, string matrixA, string matrixB)
        {
            MatrixA = ToArray(size, matrixA);
            MatrixB = ToArray(size, matrixB);
        }

        //Matrix multiplication and mD5 conversion
        public string MatrixMultiplication()
        {
            string hd5HashResult;

            Matrix<double> a =  DenseMatrix.OfArray(MatrixA);
            Matrix<double> b =  DenseMatrix.OfArray(MatrixB);

            var matrixResult = a * b;
            var concatResult = string.Empty;

            foreach (var value in matrixResult.ToArray())
            {
                concatResult = concatResult + value + " ";
            }

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var inputBytes = System.Text.Encoding.ASCII.GetBytes(concatResult);
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                hd5HashResult = sb.ToString();
            }

            return hd5HashResult;
        }

        //Converts string to array e.g "1 2 3 1 2 3 1 2 3" to double[,] array ={{1,2,3},{1,2,3},{1,2,3}}
        public double[,] ToArray(int size, string matrix)
        {
            var numbers = matrix.Split(' ').Select(Double.Parse).ToArray();
            int k = 0;

            double[,] tempArray = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tempArray[i, j] = numbers[k];
                    k++;
                }
            }
            return tempArray;
        }
    }
}
