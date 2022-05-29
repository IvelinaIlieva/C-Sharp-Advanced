namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] words = File.ReadAllText(wordsFilePath).Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                wordCounts.Add(word, 0);
            }

            using (StreamReader sr = new StreamReader(textFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Regex regex = new Regex(@"[A-Za-z]+");

                    MatchCollection matchCollection = regex.Matches(line);

                    foreach (Match word in matchCollection)
                    {
                        string currWord = word.ToString().ToLower();
                        if (wordCounts.ContainsKey(currWord))
                        {
                            wordCounts[currWord]++;
                        }
                    }
                }
            }

            using StreamWriter streamWriter = new StreamWriter(outputFilePath);
            {
                foreach (var (w, count) in wordCounts.OrderByDescending(w => w.Value))
                {
                    string newLine = $"{w} - {count}";

                    streamWriter.WriteLine(newLine);
                }
            }
        }
    }
}





