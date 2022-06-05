using System;

namespace DateModifier
{
    public class DateModifier
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            Console.WriteLine(GetDays(date1, date2));
        }

        private static int GetDays(string date1, string date2)
        {
            DateTime date11 = DateTime.Parse(date1);
            DateTime date12 = DateTime.Parse(date2);

            int diff = Math.Abs((date11 - date12).Days);
            return diff;
        }
    }
}
