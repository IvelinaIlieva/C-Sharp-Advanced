using System;

namespace TuplesAndThreeuples
{
    public class StartUp
    {
        static void Main()
        {
            for (int i = 1; i <= 3; i++)
            {
                string[] input = Console.ReadLine().Split();

                switch (i)
                {
                    case 1:
                        var name1 = input[0] + " " + input[1];
                        var address = input[2];
                        var town = input.Length > 4 ? (input[3] + " " + input[4]) : input[3];
                        Threeuple<string, string, string> threeuple1 = new Threeuple<string, string, string>(name1, address, town);
                        Console.WriteLine(threeuple1);
                        break;

                    case 2:
                        var name2 = input[0];
                        var litters = int.Parse(input[1]);
                        var isDrunk = input[2] == "drunk" ? true : false;
                        Threeuple<string, int, bool> threeuple2 = new Threeuple<string, int, bool>(name2, litters, isDrunk);
                        Console.WriteLine(threeuple2);
                        break;

                    case 3:
                        var name3 = input[0];
                        var bankAccount = double.Parse(input[1]);
                        var bankName = input[2];
                        Threeuple<string, double, string> threeuple3 = new Threeuple<string, double, string>(name3, bankAccount, bankName);
                        Console.WriteLine(threeuple3);
                        break;
                }
            }
        }
    }
}
