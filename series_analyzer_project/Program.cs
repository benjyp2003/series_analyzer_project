using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace series_analyzer_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            convertToInt(args);
        }

        // func that converts the series from string[] to int[]. (and validates that only numbers were givin)
        static void convertToInt(string[] args)
        {
            int[] numbers = new int[args.Length];

            numbers = validInput(args, numbers);
            
            validatePosNumbers(numbers);
        }


        // func that checks user enterd numbers only.
        static int[] validInput(string[] args, int[] numbers)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (int.TryParse(args[i], out int num))  // checking if user put in numbers,
                {
                    numbers[i] = num;              // if he did, convert evry number to int and store them in "numbers".
                }
                else                              // if he put enything else, we ask him to renter the series.
                {
                    Console.WriteLine("ERROR. enter numbers only! ");
                    enterSeries();
                }
            }

            return numbers;
        }

        // function that gets a number series from the user.
        static void enterSeries()
        {
            Console.WriteLine("enter a new series: (with spaces between the numbers) ");
            string str  = Console.ReadLine();
            string[] strNumList = str.Split(' ');

            convertToInt(strNumList);
        }
        
        // valiadte that the user enterd at least 3 positive numbers.
        static void validatePosNumbers(int[] numbers)
        {
            if (numbers.Length < 3)
            {
                Console.WriteLine("ERROR. enter at least 3 numbers.");
                enterSeries(); 
            }

            foreach (int num in numbers)
            {
                if (num < 0)
                {
                    Console.WriteLine("ERROR. enter positive numbers only.");
                    enterSeries();
                }
            }

            menu(numbers);
        }

        static void menu(int[] numbers)
        {
            Console.WriteLine("welcome to The Series Analyzer! \n" +
                              "click a - to enter a series. (replace the current sereis) \n" +
                              "click b - to display the series in the order it was enterd. \n" +
                              "click c - to display the series in the reverse order it was enterd. \n" +
                              "click d - to display the series in sorted order. (from low to high) \n" +
                              "click e - to display the max value of the series. \n" +
                              "click f - to display the min value of the series. \n" +
                              "click g - to display thr avarege of thr series. \n" +
                              "click h - to display the number of elements in the series. \n" +
                              "click i - to display the sum of the numbers in the series. \n" +
                              "click j - to exit the program.");

            string choice = Console.ReadLine();
            output(choice, numbers);

        }

        static void output(string choice, int[] numbers)
        {
            
        }
    }
}
