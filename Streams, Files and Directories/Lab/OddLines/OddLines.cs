namespace OddLines
{
    using System.Collections.Generic;
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);

            int counter = 0;

            List<string> oddLines = new List<string>();

            foreach (string line in lines)
            {
                if (counter % 2 != 0)
                {
                    oddLines.Add(line);
                }
                counter++;
            }

            File.WriteAllLines(outputFilePath, oddLines);
        }
    }
}
