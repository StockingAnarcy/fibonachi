using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    private static uint Fibonacci(uint n)
    {
        if (n < 2)
        {
            return n;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

    private static string Output(uint num)
    {
        IList<uint> fibonacciNumbers = new List<uint>();
        uint fibPosition = 2;

        uint currentFibonaciNum = Fibonacci(fibPosition);

        do
        {
            fibonacciNumbers.Add(currentFibonaciNum);
            currentFibonaciNum = Fibonacci(++fibPosition);
        } while (currentFibonaciNum <= num);

        uint temp = num;
        StringBuilder output = new StringBuilder();

        foreach (uint item in fibonacciNumbers.Reverse())
        {
            if (item <= temp)
            {
                output.Append("1");
                temp -= item;
            }
            else
            {
                   output.Append("0");
            }
        }

        return output.ToString();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите число для перевода в фибоначчиевскую систему: ");

        string input = Console.ReadLine();

        var num = Convert.ToUInt32(input);

        string outputRepresentation = Output(num);
        Console.WriteLine(string.Format(" {0} : {1}", input, outputRepresentation));
        Console.WriteLine("\nПеревести в десятичное?  y/n");

        if(Console.ReadKey().Key == ConsoleKey.Y)
        {
                string bin = outputRepresentation;
                int dec = Convert.ToInt32(bin, 2);
                Console.WriteLine(string.Format("\n {0} : {1}", bin, dec));
        }
       
        if (Console.ReadKey().Key == ConsoleKey.N)
        {
            Environment.Exit(0);
        }

        Console.ReadKey();
    }

}