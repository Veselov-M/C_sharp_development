using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            void menuNavigation ()
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Max value");
                Console.WriteLine("2. Min value");
                Console.WriteLine("3. Is sum odd");
                Console.WriteLine("4. Clear console");
                Console.WriteLine("5. Exit program");

            }

            void maxValue ()
            {
                Console.Write("Please enter your numbers using a space as a separator: ");
                Console.ReadLine();
                string textNumbers = Console.ReadLine();
                var splitedTextNumbers = textNumbers.Split(" ");
                int [] numbers = new int[splitedTextNumbers.Length];
                int i = 0;

                foreach (var numb in splitedTextNumbers)
                {
                    if (int.TryParse(numb, out var parsedResult))
                    {
                        numbers[i++] += parsedResult;
                    }
                }

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if(numbers[j] > numbers[j + 1])
                    {
                        numbers[j + 1] = numbers[j];
                    }
                }

                int maximum = numbers[numbers.Length - 1];
                Console.WriteLine("Maximum number is " + maximum);
                Console.ReadLine();
                Environment.Exit(0);

            }

            void minValue()
            {
                Console.Write("Please enter your numbers using a space as a separator: ");
                Console.ReadLine();
                string textNumbers = Console.ReadLine();
                var splitedTextNumbers = textNumbers.Split(" ");
                int[] numbers = new int[splitedTextNumbers.Length];
                int i = 0;

                foreach (var numb in splitedTextNumbers)
                {
                    if (int.TryParse(numb, out var parsedResult))
                    {
                        numbers[i++] += parsedResult;
                    }
                }

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        numbers[j + 1] = numbers[j];
                    }
                }

                int minimum = numbers[numbers.Length - 1];
                Console.WriteLine("Minimum number is " + minimum);
                Console.ReadLine();
                Environment.Exit(0);
            }

            void TrySumIfOdd ()
            {
                Console.WriteLine("Enter your first number: ");
                Console.ReadLine();
                string firstValue = Console.ReadLine();
                bool x = int.TryParse(firstValue, out var parsedResultX);

                Console.WriteLine("Enter your last number: ");
                string lastValue = Console.ReadLine();
                bool y = int.TryParse(lastValue, out var parsedResultY);

                int sum = parsedResultX + parsedResultY;

                if (sum % 2 == 0)
                {
                    Console.WriteLine("Sum of your numbers is odd and equals " + sum);
                }
                else Console.WriteLine("Sum of your numbers isn`t odd and equals " + sum);
                Console.ReadLine();
                Environment.Exit(0);
            }
            

            while (true)
            {
                menuNavigation();
                var pageNumber = Console.Read();
                switch (pageNumber - 48)
                {
                    case 1:

                        maxValue();
                        break;

                    case 2:
                        minValue();
                        break;

                    case 3:

                        TrySumIfOdd();
                        break;

                    case 4:
                        Console.Clear();
                        menuNavigation();
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Enter coorect number");
                        break;

                }
            }
        }
    }
}
           