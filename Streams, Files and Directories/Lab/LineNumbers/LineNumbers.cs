namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using StreamReader streamReader = new StreamReader(inputFilePath);
            {
                string line = streamReader.ReadLine();
                int counter = 0;

                using StreamWriter streamWriter = new StreamWriter(outputFilePath);
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        counter++;
                        string newLine = $"{counter}. {line}";

                        streamWriter.WriteLine(newLine);
                    }
                }
            }
        }
    }
}
