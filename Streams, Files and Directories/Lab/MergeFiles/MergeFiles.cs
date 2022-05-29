namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> text = new List<string>();
            
            using StreamReader streamReader1 = new StreamReader(firstInputFilePath);
            {
                using StreamReader streamReader2 = new StreamReader(secondInputFilePath);
                {                  
                    while (true)
                    {
                        string firstLine = streamReader1.ReadLine();
                        string secondLine = streamReader2.ReadLine();
                        
                        if (firstLine == null && secondLine == null)
                        {
                            break;
                        }

                        if (firstLine != null)
                        {
                            text.Add(firstLine);
                        }
                        if (secondLine != null)
                        {                            
                            text.Add(secondLine);
                        }
                    }
                }
            }         

            using StreamWriter streamWriter = new StreamWriter(outputFilePath);
            {
                streamWriter.WriteLine(string.Join(Environment.NewLine, text));
            }
        }
    }
}
