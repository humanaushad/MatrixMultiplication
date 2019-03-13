using System;
using System.Text;


namespace MatrixMultiplication.Model
{
    //This class generates random matrix, calls File Access class to Save/Read and Parse Matrix and size from TextFile
    public class Numbers
    {
        public int Size { get; set; }
        public string MatrixA { get; set; }
        public string MatrixB { get; set; }

        public bool GenerateMartix(int size)
        {
            Random rnd = new Random();
            var matrixA = new StringBuilder();
            var matrixB = new StringBuilder();

            for (int i = 0; i < size*size; i++)
            {
                matrixA = matrixA.Append(rnd.Next(1, 10)).Append(" ");
                matrixB = matrixB.Append(rnd.Next(1, 10)).Append(" ");
            }

            var fileAccess = new FileAccess();
            return fileAccess.SaveToFile(size.ToString(), matrixA.ToString(), matrixB.ToString());

        }

        public string ReadMartix()
        {
            var fileAccess = new FileAccess();
            return fileAccess.ReadFromFile();
        }

        public void ParseMatrix()
        {
            var data = ReadMartix();
            var values = data.Split('|');
            Size = int.Parse(values[0].TrimEnd());
            MatrixA = values[1].TrimEnd();
            MatrixB = values[2].TrimEnd();
        }
    }
}
