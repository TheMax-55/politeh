using System;
using static System.Net.Mime.MediaTypeNames;
class Program
{
    static void Print(double[,] arr)
    {
        int n = arr.GetLength(0);
        Console.Write("    ");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{i + 1,4}");
        }
        Console.WriteLine();
        Console.Write("    ");
        for (int i = 0; i < n; i++)
        {
            Console.Write("----");
        }
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{i + 1,2} |");
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{arr[i, j],4}");
            }
            Console.WriteLine();
        }
    }
    static void Floyd(double[,] arr)
    {
        int n = arr.GetLength(0);
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = Math.Min(arr[i, k] + arr[k, j], arr[i, j]);
                }
            }
        }
        Print(arr);
    }
    static void Main()
    {
        double i = double.PositiveInfinity;
        double[,] test1 = {
            { 0,10,18,8,i,i },
            { 10,0,16,9,21,i },
            { i,16,0,i,i,15 },
            { 7,9,i,0,i,12 },
            { i,i,i,i,0,23 },
            { i,i,15,i,23,0 }
        };
        double[,] test2 =
        {
            { 0,i,-2,i },
            { 4,0,3,i },
            { i,i,0,2 },
            { i,-1,i,0 }
        };
        double[,] test3 =
        {
            { 0,10,18,8,i,i },
            { 10,0,16,9,21,i },
            { i,16,0,i,i,15 },
            { 7,9,i,0,i,12 },
            { i,i,i,i,0,23 },
            { i,i,15,i,23,0 }
        };
        Floyd(test1);
        Floyd(test2);
        Floyd(test3);
    }
}
