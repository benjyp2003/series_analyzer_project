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

            foreach (var item in args)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (int.TryParse(args[i], out int num))
                {
                    numbers[i] = num;
                }
                else
                {
                    Console.WriteLine("enter numbers only! ");
                    enterSeries();
                }
            }
            menu(numbers);
        }

        

    }
}
