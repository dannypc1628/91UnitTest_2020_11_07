using System;
using System.Security.Cryptography.X509Certificates;

namespace UnitTest91
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Holiday
    {
        

        public string SayHello()
        {
            var _day = GetToday();
            if (_day.Month == 12 && _day.Day == 25)
            {
                return "Merry Xmas";
            }

            return "Today is not Xmas";
        }

        protected virtual DateTime GetToday()
        {
            return DateTime.Now;
        }
    }
}
