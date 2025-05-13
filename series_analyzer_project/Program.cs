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
                if (ValidateInput(args))
                {
                    double[] numbers = ConverteStrToNumbers(args);
                    if (ValidateLength3(numbers))
                    {
                        if (ValidatePosNumbers(numbers))
                        {
                            ShowMenu();
                            HandleMenuChoice(numbers);
                        }
                        else
                        {
                            Console.WriteLine("ERROR: enter positive numbers only.");
                            EnterSeries();
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR: enter at least 3 numbers.");
                        EnterSeries();
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: enter numbers only.");
                    EnterSeries();
                }   
        }


      
        // func that checks that the user enterd numbers only.
        static bool ValidateInput(string[] args)
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


        // func that converts the series from string[] to int[] or double[]. 
        static double[] ConverteStrToNumbers(string[] args)
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
        static bool ValidatePosNumbers(double[] numbers)
        {
            foreach (double num in numbers)
            {
                if (num < 0)
                {
                    return false;
                }
            }
            return true;
        }


        //validate that the series has at least 3 numbers in it.
        static bool ValidateLength3(double[] numbers)
        {
            return numbers.Length >= 3;
        }


        // function that gets a series of number from the user.
        static void EnterSeries()
        {
            Console.WriteLine("enter a new series: (with spaces between the numbers) ");
            string str = Console.ReadLine();
            string[] strNumList = str.Split(' ');

            Run(strNumList);
        }


        // display the menu of opperations to the user.
        static void ShowMenu()
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
                    EnterSeries();
                    break;

                case "b":
                    DisplaySeries(numbers); 
                    break;

                case "c":
                    DisplayReverse(numbers);
                    break;

                case "d":
                    DisplaySorted(numbers);
                    break;

                case "e":
                    ShowMax(numbers); 
                    break;

                case "f":
                    ShowMin(numbers);
                    break;

                case "g":
                    ShowAverage(numbers);
                    break;

                case "h":
                    ShowLegth(numbers);
                    break;

                case "i":
                    ShowSum(numbers);
                    break;

                case "j":
                    Console.WriteLine("good bye (: ");
                    break;

                default:
                    Console.WriteLine("ERROR. not valid input.");
                    ShowMenu();
                    HandleMenuChoice(numbers);
                    break;

            }
        }



        static void DisplaySeries(double[] numbers)
        {
            foreach (double num in numbers)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine("");
            ShowMenu();
            HandleMenuChoice(numbers);
        }


        static void DisplayReverse(double[] numbers)
        {
            for (int i = numbers.Length -1; i > -1; i--)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine("");
            ShowMenu();
            HandleMenuChoice(numbers);
        }



        static void DisplaySorted(double[] numbers)
        {
            double[] sorted = BubbleSort(numbers);
            foreach (double num in sorted)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine("");
            ShowMenu();
            HandleMenuChoice(sorted);
        }

        static double[] BubbleSort(double[] numbers)
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



        static void ShowMax(double[] numbers)
        {
            Console.WriteLine($"max number in the series is {GetMax(numbers)}");
            ShowMenu();
            HandleMenuChoice(numbers);
        }

        static double GetMax(double[] numbers)
        {
            double max = numbers[0];
            foreach (double num in numbers)
            {
                if (num > max)
                { max = num; }
            }
            return max;
        }



        static void ShowMin(double[] numbers)
        {
            Console.WriteLine($"min number in the series is {GetMin(numbers)}");
            ShowMenu();
            HandleMenuChoice(numbers);
        }

        static double GetMin(double[] numbers)
        {
            double min = numbers[0];
            foreach (double num in numbers)
            {
                if (num < min)
                    { min = num; }
            }
            return min;
        }



        static void ShowAverage(double[] numbers)
        {
            Console.WriteLine($"the average of the series is {GetAverage(numbers)}");
            ShowMenu();
            HandleMenuChoice(numbers);
        }

        static double GetAverage(double[] numbers)
        {
            double count = 0, sum = 0;
            foreach (double num in numbers)
            {
                count++;
                sum += num;
            }
            return sum / count;
        }



        static void ShowLegth(double[] numbers)
        {
            Console.WriteLine($"series has {GetLength(numbers)} numbers in it.");
            ShowMenu();
            HandleMenuChoice(numbers);
        }

        static double GetLength(double[] numbers)
        {
            double count = 0;
            foreach (double num in numbers)
            {
                count++;
            }
            return count;
        }



        static void ShowSum(double[] numbers)
        { 
            Console.WriteLine($"sum of the sereis is {GetSum(numbers)}");
            ShowMenu();
            HandleMenuChoice(numbers);
        }

        static double GetSum(double[] numbers)
        {
            double sum = 0;
            foreach (double num in numbers)
                { sum += num; }

            return sum;
        }

    }
}