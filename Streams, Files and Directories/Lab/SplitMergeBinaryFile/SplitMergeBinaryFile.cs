namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            FileInfo fileInfo = new FileInfo(sourceFilePath);

            long firstLength = 0;
            long secondLength = 0;

            if (fileInfo.Length % 2 != 0)
            {
                firstLength = fileInfo.Length / 2 + 1;
            }
            else
            {
                firstLength = fileInfo.Length / 2;
            }
            secondLength = fileInfo.Length / 2;

            using (var source = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (var first = new FileStream(partOneFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[firstLength];

                    int bytesRead = source.Read(buffer);

                    first.Write(buffer, 0, bytesRead);

                }
                using (var second = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[secondLength];

                    int bytesRead = source.Read(buffer);

                    second.Write(buffer, 0, bytesRead);
                }
            }

        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            FileInfo fileInfo = new FileInfo(partOneFilePath + partTwoFilePath);

            long length = fileInfo.Length;

            using (var source1 = new FileStream(partOneFilePath, FileMode.Open))
            using (var source2 = new FileStream(partTwoFilePath, FileMode.Open))
            using (var joined = new FileStream(joinedFilePath, FileMode.Create))
            {
                byte[] buffer = new byte[length];

                while (true)
                {
                    int bytesRead = source1.Read(buffer);
                    if (bytesRead == 0) break;
                    joined.Write(buffer, 0, bytesRead);
                }

                while (true)
                {
                    int bytesRead = source2.Read(buffer);
                    if (bytesRead == 0) break;
                    joined.Write(buffer, 0, bytesRead);
                }

            }

        }

    }
}