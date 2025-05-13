using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace series_analyzer_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run(args);
        }


        // run all the functions of this program.
        static void Run(string[] args)
        {
            
                if (validateInput(args))
                {
                    double[] numbers = ParseInput(args);
                    validatePosNumbers(numbers);
                    validateLength(numbers);
                    showMenu();
                    HandleMenuChoice(numbers);
                }
                else
                {
                    Console.WriteLine("ERROR: enter numbers only.");
                    enterSeries();
                }   
        }


      
        // func that checks that the user enterd numbers only.
        static bool validateInput(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (!int.TryParse(args[i], out _) && (!double.TryParse(args[i], out _)))  // checking if user put in numbers (int ou double),
                {
                    return false;
                }
            }
            return true;
        }


        // func that converts the series from string[] to int[] or double[]. (and validates that only numbers were givin)
        static double[] ParseInput(string[] args)
        {
            double[] numbers = new double[args.Length];
            
            for (int i = 0; i < args.Length; i++)
            {
                if (int.TryParse(args[i], out int num))
                {
                    numbers[i] = num;
                }
                else if (double.TryParse(args[i], out double doubleNum))
                {
                    numbers[i] = doubleNum;
                }
            }

            return numbers;
        }


        // valiadte that the user enterd at least 3 positive numbers.
        static void validatePosNumbers(double[] numbers)
        {
            foreach (double num in numbers)
            {
                if (num < 0)
                {
                    Console.WriteLine("ERROR. enter positive numbers only.");
                    enterSeries();
                }
            }
        }


        //validate that the series has at least 3 numbers in it.
        static void validateLength(double[] numbers)
        {
            if (numbers.Length < 3)
            {
                Console.WriteLine("ERROR. enter at least 3 numbers.");
                enterSeries();
            }
        }


        // function that gets a series of number from the user.
        static void enterSeries()
        {
            Console.WriteLine("enter a new series: (with spaces between the numbers) ");
            string str = Console.ReadLine();
            string[] strNumList = str.Split(' ');

            run(strNumList);
        }

        // display the menu of opperations to the user.
        static void showMenu()
        {
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                 Welcome to The Series Analyzer!              ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  [a] Enter a new series (replace the current series)         ║");
            Console.WriteLine("║  [b] Display the series in entered order                     ║");
            Console.WriteLine("║  [c] Display the series in reverse order                     ║");
            Console.WriteLine("║  [d] Display the series sorted (low to high)                 ║");
            Console.WriteLine("║  [e] Show the max value of the series                        ║");
            Console.WriteLine("║  [f] Show the min value of the series                        ║");
            Console.WriteLine("║  [g] Show the average of the series                          ║");
            Console.WriteLine("║  [h] Show the number of elements in the series               ║");
            Console.WriteLine("║  [i] Show the sum of the series                              ║");
            Console.WriteLine("║  [j] Exit the program                                        ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");
            Console.Write("Select an option: ");
        }
        


        // handle the output of the menu.
        static void HandleMenuChoice(double[] numbers)
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
                    showMax(numbers); 
                    break;

                case "f":
                    showMin(numbers);
                    break;

                case "g":
                    showAverage(numbers);
                    break;

                case "h":
                    showLegth(numbers);
                    break;

                case "i":
                    showSum(numbers);
                    break;

                case "j":
                    Console.WriteLine("good bye (: ");
                    break;

                default:
                    Console.WriteLine("ERROR. not valid input.");
                    showMenu();
                    HandleMenuChoice(numbers);
                    break;

            }
        }



        static void displaySeries(double[] numbers)
        {
            foreach (double num in numbers)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine("");
            showMenu();
            HandleMenuChoice(numbers);
        }


        static void displayReverse(double[] numbers)
        {
            for (int i = numbers.Length -1; i > -1; i--)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine("");
            showMenu();
            HandleMenuChoice(numbers);
        }



        static void displaySorted(double[] numbers)
        {
            double[] sorted = bubbleSort(numbers);
            foreach (double num in sorted)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine("");
            showMenu();
            HandleMenuChoice(sorted);
        }

        static double[] bubbleSort(double[] numbers)
        {
            for (int i = 0; i < numbers.Length ; i++)
            {
                bool flag = true;
                for (int j = 0; j < numbers.Length -1 -i; j++)
                {
                    if (numbers[j] > numbers[j+1])
                    {
                        double temp = numbers[j];
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



        static void showMax(double[] numbers)
        {
            Console.WriteLine($"max number in the series is {getMax(numbers)}");
            showMenu();
            HandleMenuChoice(numbers);
        }

        static double getMax(double[] numbers)
        {
            double max = numbers[0];
            foreach (double num in numbers)
            {
                if (num > max)
                { max = num; }
            }
            return max;
        }



        static void showMin(double[] numbers)
        {
            Console.WriteLine($"min number in the series is {getMin(numbers)}");
            showMenu();
        }

        static double getMin(double[] numbers)
        {
            double min = numbers[0];
            foreach (double num in numbers)
            {
                if (num < min)
                    { min = num; }
            }
            return min;
        }



        static void showAverage(double[] numbers)
        {
            Console.WriteLine($"the average of the series is {getAverage(numbers)}");
            showMenu();
            HandleMenuChoice(numbers);
        }

        static double getAverage(double[] numbers)
        {
            double count = 0, sum = 0;
            foreach (double num in numbers)
            {
                count++;
                sum += num;
            }
            return sum / count;
        }



        static void showLegth(double[] numbers)
        {
            Console.WriteLine($"series has {getLength(numbers)} numbers in it.");
            showMenu();
            HandleMenuChoice(numbers);
        }

        static double getLength(double[] numbers)
        {
            double count = 0;
            foreach (double num in numbers)
            {
                count++;
            }
            return count;
        }



        static void showSum(double[] numbers)
        { 
            Console.WriteLine($"sum of the seireis is {getSum(numbers)}");
            showMenu();
            HandleMenuChoice(numbers);
        }

        static double getSum(double[] numbers)
        {
            double sum = 0;
            foreach (double num in numbers)
                { sum += num; }

            return sum;
        }

    }
}