using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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
        Console.Clear();

        Console.WriteLine("Выберите: перевод из десятичной системы в фибонначиевскую (нажмите 1)\n          " +
            "перевод из фибоначчиевкой системы в десятичную (нажмите 2)\n          для выхода нажмите Q");
        
        ConsoleKey readKey = Console.ReadKey().Key;
        if (readKey == ConsoleKey.D1 || readKey == ConsoleKey.NumPad1)
        {
            Console.Clear();
            Console.WriteLine(" Введите десятичное целое число:");
            string input = Console.ReadLine();
            uint num = Convert.ToUInt32(input);
            string outputNum = Output(num);
            Console.WriteLine(string.Format(" {0} => {1}\n Нажмите любую клавишу для продолжения\n или Q для выхода", input, outputNum));

            if (Console.ReadKey().Key != ConsoleKey.Q)
            {
                Process.Start(AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
            else Environment.Exit(0);
        }
        else if (readKey == ConsoleKey.D2 || readKey == ConsoleKey.NumPad2)
        {
            Console.Clear();
            Console.WriteLine(" Введите число в системе фибоначчи:");
            string input = Console.ReadLine();
            uint fibPosition = 2;
            uint currentFibonaciNum = Fibonacci(fibPosition);

            IList<uint> fibonacciNumbers = new List<uint>();
            IList<uint> result = input.Select(c => uint.Parse(c.ToString())).ToList();
            IList<uint> result_1 = new List<uint>(); 

            do
            {
                fibonacciNumbers.Add(currentFibonaciNum);
                currentFibonaciNum = Fibonacci(++fibPosition);
            } 
            while (currentFibonaciNum <= uint.Parse(input));
            
            foreach (uint a in result.Reverse())
            {
               result_1.Add(a);
            }

            uint decimalNumber = 0;

            for (int i = 0; i < result_1.Count; i++)
            {
                decimalNumber += result_1[i] * fibonacciNumbers[i];
            }

            Console.WriteLine(string.Format(" {0} => {1}\n Нажмите любую клавишу для продолжения\n или Q для выхода", input, decimalNumber));

            if (Console.ReadKey().Key != ConsoleKey.Q)
            {
                Process.Start(AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
            else Environment.Exit(0);
        }
        else if(readKey == ConsoleKey.Q)
        {
            Environment.Exit(0);
        }
    }
}