using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your number for X ");
            string xstr = Console.ReadLine();
            bool isXNumber = int.TryParse(xstr, out int resultX);

            if (isXNumber == false)
            {
                Console.WriteLine("\nInvalid input!");
                Console.Read();
                Environment.Exit(0);
            }

            Console.Write("Please enter your number for Y ");
            string ystr = Console.ReadLine();
            bool isYNumber = int.TryParse(ystr, out int resultY);

            if (isYNumber == false)
            {
                Console.WriteLine("\nInvalid input!");
                Console.Read();
                Environment.Exit(0);
            }

            if (resultX == resultY)
            {
                Console.WriteLine("\nYou have entered 2 same numbers - " + resultX);
                Console.Read();
            }

            int sum = 0;

            for (int i = resultX; i <= resultY; i++)
            {
                sum += i;
            }

            Console.WriteLine(sum);
            Console.Read();
        }
    }
}

