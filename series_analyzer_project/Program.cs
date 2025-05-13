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
                    double[] numbers = convertArgsToIntDouble(args);
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


      
        // func that checks that the user enterd numbers only.
        static bool validateInput(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (!int.TryParse(args[i], out _) && (!double.TryParse(args[i], out _)))  // checking if user put in numbers,
                {
                    return false;
                }
            }
            return true;
        }


        // func that converts the series from string[] to int[]. (and validates that only numbers were givin)
        static double[] convertArgsToIntDouble(string[] args)
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


        static void validateLength(double[] numbers)
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
        static void showMenu(double[] numbers)
        {
            Console.WriteLine("welcome to The Series Analyzer! \n" +
                              "click a - to enter a series. (replace the current sereis) \n" +
                              "click b - to display the series in the order it was enterd. \n" +
                              "click c - to display the series in the reverse order it was enterd. \n" +
                              "click d - to display the series in sorted order. (from low to high) \n" +
                              "click e - to display the max value of the series. \n" +
                              "click f - to display the min value of the series. \n" +
                              "click g - to display the average of thr series. \n" +
                              "click h - to display the number of elements in the series. \n" +
                              "click i - to display the sum of the numbers in the series. \n" +
                              "click j - to exit the program.");

            menuOutput(numbers);

        }


        // handle the output of the menu.
        static void menuOutput(double[] numbers)
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
                    showMenu(numbers);
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
            showMenu(numbers);
        }


        static void displayReverse(double[] numbers)
        {
            for (int i = numbers.Length -1; i > -1; i--)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine("");
            showMenu(numbers);
        }



        static void displaySorted(double[] numbers)
        {
            double[] sorted = bubbleSort(numbers);
            foreach (double num in sorted)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine("");
            showMenu(numbers);           
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
            showMenu(numbers);
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
            showMenu(numbers);
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
            showMenu(numbers);
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
            showMenu(numbers);
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
            showMenu(numbers);
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
