﻿using System;




int[] insert()
{
    Console.WriteLine("Please enter numbers you want to sort: ");
    string numberArrayReaded = Console.ReadLine();
    var numberArraySplited = numberArrayReaded.Split(" ");
    int[] numberArray = new int[numberArraySplited.Length];
    int i = 0;
    foreach (var numb in numberArraySplited)
    {
        if (int.TryParse(numb, out var parsedResult))
        {
            numberArray[i++] += parsedResult;
        }
    }
    return numberArray;
}

void selectionSort(int[] insert)
{
    for (int i = 0; i < insert.Length - 1; i++)
    {
        var smallestVal = i;

        for (int j = i + 1; j < insert.Length; j++)
        {
            if (insert[j] < insert[smallestVal])
            {
                smallestVal = j;
            }
        }
        var numberSaveElement = insert[smallestVal];
        insert[smallestVal] = insert[i];
        insert[i] = numberSaveElement;
    }
    Console.Write("Sorted array:");
    foreach (var numb in insert)
    {
        Console.Write(" " + numb);
    }
    Console.Read();
}
void bubbleSort(int[] insert)
{
    for (int j = 0; j < insert.Length - 1; j++)
    {
        if (insert[j] > insert[j + 1])
        {

            var saveNumber = insert[j + 1];
            insert[j + 1] = insert[j];
            insert[j] = saveNumber;
        }
    }
    Console.Write("Sorted array:");
    foreach (var numb in insert)
    {
        Console.Write(" " + numb);

    }

    Console.Read();
}
void insertionSort(int[] insert)
{
    for (int i = 0; i < insert.Length - 1; i++)
    {
        for (int j = i + 1; j > 0; j--)
        {
            if (insert[j - 1] > insert[j])
            {
                int saveNumber = insert[j - 1];
                insert[j - 1] = insert[j];
                insert[j] = saveNumber;
            }
        }
    }
    Console.Write("Sorted array:");
    foreach (var numb in insert)
    {
        Console.Write(" " + numb);

    }

    Console.Read();
}

void menu()
{
    Console.WriteLine("Please enter the number of the program you want to launch:");
    Console.WriteLine("\n1. Selection sort");
    Console.WriteLine("2. Bubble sort");
    Console.WriteLine("3. Insertion sort");
    Console.WriteLine("4. Clear console");
    Console.WriteLine("5. Exit program");
}

while (true)
{
    menu();
    var pageNumber = int.Parse(Console.ReadLine());
    if (pageNumber < 6 || pageNumber > 0)
    {
        switch (pageNumber)
        {
            case 4:
                Console.Clear();
                break;

            case 5:
                Environment.Exit(0);
                break;

            default:



                switch (pageNumber)
                {
                    case 1:

                        selectionSort(insert());
                        break;

                    case 2:
                        bubbleSort(insert());
                        break;

                    case 3:

                        insertionSort(insert());
                        break;

                    default:
                        Console.WriteLine("Enter correct number");
                        break;
                }
                break;
        }
    }
    else
        Console.WriteLine("Enter correct number");
}