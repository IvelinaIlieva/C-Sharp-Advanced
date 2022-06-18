using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main()
        {
            ListyIterator<string> list = new ListyIterator<string>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Create")
                {
                    list = new ListyIterator<string>(cmdArgs.Skip(1).ToArray());
                }
                else if (cmdArgs[0] == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (cmdArgs[0] == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (cmdArgs[0] == "Print")
                {
                    list.Print();
                }
                else if (cmdArgs[0] == "PrintAll")
                {
                    foreach (var item in list)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
