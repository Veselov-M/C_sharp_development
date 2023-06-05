using System;



void Compare ()
{
    Console.Write("Please enter first string: ");
    string firstString = Console.ReadLine ();

    Console.Write("Please enter second string: ");
    string secondString = Console.ReadLine ();

    if (firstString.Length == secondString.Length)
    {
        int compareResult = 0;

        for (int i = 0; i < firstString.Length - 1; i++)
        {
            if (firstString[i] == secondString[i])
            {
                ++compareResult;
            }
        }
        if (compareResult == firstString.Length - 1)
        {
            Console.WriteLine("\nThe strings are the same!");
        }
        else Console.WriteLine("\nThe strings aren`t the same!");
    }
    else Console.WriteLine("\nThe strings aren`t the same!");


}


void analyze()
{
    Console.Write("Please enter string you want to analyze: ");
    string analyzingString = Console.ReadLine();

    int chars = 0;
    int digit = 0;
    int specialCharacters = 0;


    foreach (char x in analyzingString)
    {
        if ((int)x > 64 && (int)x < 91)
        {
            ++chars;
        }

        if ((int)x > 96 && (int)x < 123)
        {
            ++chars;
        }
    }

    foreach (char x in analyzingString)
    {
        if ((int)x > 47 && (int)x < 58)
        {
            ++digit;
        }
    }

    specialCharacters = analyzingString.Length - chars - digit;

    Console.WriteLine("\nNumber of chars in your string is: " + chars);
    Console.WriteLine("Number of digits in your string is: " + digit);
    Console.WriteLine("Number of special characters in your string is: " + specialCharacters);
}


void Sort()
{
    Console.Write("Please enter string you want to sort: ");
    string sortingString = Console.ReadLine().ToLower();
    char[] lowerString = sortingString.ToArray();
    Array.Sort(lowerString);

    foreach (char x in lowerString)
    {
        Console.Write(x);
    }
}

void duplicate()
{
    Console.Write("Please enter string in witch you want to found duplicated chars: ");
    string duplicateString = Console.ReadLine();
    char[] lowerString = duplicateString.ToArray();
    Array.Sort(lowerString);
    char[] charString = new char[lowerString.Length];

    for (int i = 0; i < lowerString.Length - 1; i++)
    {
        if (lowerString[i] == lowerString[i + 1])
        {
            charString[i] = lowerString[i];
        }
    }
    var noDuplicate = charString.Distinct();

    Console.Write("\nChars that duplicated:");

    foreach(char x in noDuplicate)
    {
        if (x.Equals(""))
        {

        }
        else Console.Write(" " + x);
    }

}














void menu()
{
    Console.WriteLine("\nPlease enter the number of the program you want to launch:");
    Console.WriteLine("\n1. Compare");
    Console.WriteLine("2. Analyze");
    Console.WriteLine("3. Sort");
    Console.WriteLine("4. Duplicate");
    Console.WriteLine("5. Clear console");
    Console.WriteLine("6. Exit program");
}

while (true)
{
    menu();
    var pageNumber = int.Parse(Console.ReadLine());

    switch (pageNumber)
    {
        case 5:
            Console.Clear();
            break;

        case 6:
            Environment.Exit(0);
            break;

        case 1:

            Compare();
            break;

        case 2:
            analyze();
            break;

        case 3:

            Sort();
            break;

        case 4:

            duplicate();
            break;


        default:
            Console.WriteLine("Enter correct number");
            break;
    }
}
