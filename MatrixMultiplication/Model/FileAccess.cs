using System;
using System.IO;
using System.Text;


namespace MatrixMultiplication.Model
{
    public class FileAccess
    {

        public bool SaveToFile(string size, string matrixA, string matrixB)
        {
            try
            {
                using (var streamWriter = new StreamWriter("TextFile.txt", false))
                {
                    streamWriter.WriteLine(size);
                    streamWriter.WriteLine(matrixA);
                    streamWriter.WriteLine(matrixB);
                }

                return true;
            }
            catch (Exception ex) { return false; }


        }

        public string ReadFromFile()
        {
            string size;
            string matrixA;
            string matrixB;


            using (var streamReader = new StreamReader("TextFile.txt", Encoding.UTF8))
            {
                size = streamReader.ReadLine();
                matrixA = streamReader.ReadLine();
                matrixB = streamReader.ReadLine();
            }

            return size + "|" + matrixA + "|" + matrixB;
        }
    }
}
