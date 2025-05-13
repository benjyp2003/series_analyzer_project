using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace series_analyzer_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            run(args);
        }


        // run all the functions.
        static void run(string[] args)
        {
            
                if (validateInput(args))
                {
                    int[] numbers = convertArgsToInt(args);
                    validatePosNumbers(numbers);
                    validateLength(numbers);
                    showMenu(numbers);
                }
                else
                {
                    Console.WriteLine("ERROR: enter numbers only.");
                    enterSeries();
                }
            
        }

        // func that checks user enterd numbers only.
        static bool validateInput(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (!int.TryParse(args[i], out int num))  // checking if user put in numbers,
                {
                    return false;
                }
            }
            return true;
        }


        // func that converts the series from string[] to int[]. (and validates that only numbers were givin)
        static int[] convertArgsToInt(string[] args)
        {
            int[] numbers = new int[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                numbers[i] = Convert.ToInt32(args[i]);
            }

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            return numbers;
        }


        // valiadte that the user enterd at least 3 positive numbers.
        static void validatePosNumbers(int[] numbers)
        {
            foreach (int num in numbers)
            {
                if (num < 0)
                {
                    Console.WriteLine("ERROR. enter positive numbers only.");
                    enterSeries();
                }
            }
        }


        static void validateLength(int[] numbers)
        {
            if (numbers.Length < 3)
            {
                Console.WriteLine("ERROR. enter at least 3 numbers.");
                enterSeries();
            }
        }


        // function that gets a number series from the user.
        static void enterSeries()
        {
            Console.WriteLine("enter a new series: (with spaces between the numbers) ");
            string str = Console.ReadLine();
            string[] strNumList = str.Split(' ');

            run(strNumList);
        }

        // display the menu of opperations to the user.
        static void showMenu(int[] numbers)
        {
            Console.WriteLine("welcome to The Series Analyzer! \n" +
                              "click a - to enter a series. (replace the current sereis) \n" +
                              "click b - to display the series in the order it was enterd. \n" +
                              "click c - to display the series in the reverse order it was enterd. \n" +
                              "click d - to display the series in sorted order. (from low to high) \n" +
                              "click e - to display the max value of the series. \n" +
                              "click f - to display the min value of the series. \n" +
                              "click g - to display thr average of thr series. \n" +
                              "click h - to display the number of elements in the series. \n" +
                              "click i - to display the sum of the numbers in the series. \n" +
                              "click j - to exit the program.");

            menuOutput(numbers);

        }


        // handle the output of the menu.
        static void menuOutput(int[] numbers)
        {
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "a":
                    enterSeries();
                    break;

                case "b":
                    displaySeries(numbers); 
                    break;

                case "c":
                    displayReverse(numbers);
                    break;

                case "d":
                    displaySorted(numbers);
                    break;

                case "e":
                    maxVal(numbers); 
                    break;

                case "f":
                    minVal(numbers);
                    break;

                case "g":
                    getAverage(numbers);
                    break;

                case "h":
                    getLegth(numbers);
                    break;

                case "i":
                    getSum(numbers);
                    break;

                case "j":
                    Console.WriteLine("good bye (: ");
                    break;

                default:
                    Console.WriteLine("ERROR. not valid input.");
                    showMenu(numbers);
                    break;

            }
        }


        static void displaySeries(int[] numbers)
        {
            foreach (int num in numbers)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine("");
            showMenu(numbers);
        }

        static void displayReverse(int[] numbers)
        {
            for (int i = numbers.Length -1; i > -1; i--)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine("");
            showMenu(numbers);
        }

        static void displaySorted(int[] numbers)
        {

        }

        static int[] bubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length -1; i++)
            {
                bool flag = true;
                for (int j = i+1; j < numbers.Length -1 -i; j++)
                {
                    if (numbers[j] > numbers[j+1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j+1];
                        numbers[j+1] = temp;
                        flag = false;
                    }
                }
                if (flag)
                { return numbers; }
            }
            return numbers;

        }

        static void maxVal(int[] numbers)
        {
        }

        static void minVal(int[] numbers)
        {
        }

        static void getAverage(int[] numbers)
        {
        }

        static void getLegth(int[] numbers)
        {
        }

        static void getSum(int[] numbers)
        { 
        }


    }
}
