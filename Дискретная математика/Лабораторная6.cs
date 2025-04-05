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
        double[,] arr2 = new double[n, n];
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr2[i, j] = Math.Min(arr[i, k] + arr[k, j], arr[i, j]);
                }
            }
            arr = arr2;
        }
        Print(arr2);
    }
    static void Main()
    {
        double inf = double.PositiveInfinity;
        double[,] test1 = {
            { 0,  10, 18, 8,  inf,inf },
            { 10, 0,  16, 9,  21, inf },
            { inf,16, 0,  inf,inf,15 },
            { 7,  9,  inf,0,  inf,12 },
            { inf,inf,inf,inf,0,  23 },
            { inf,inf,15, inf,23, 0 }
        };
        double[,] test2 =
        {
            {0, inf, -2, inf },
            {4, 0, 3, inf },
            {inf, inf, 0, 2 },
            {inf, -1, inf, 0}
        };
        double[,] test3 =
        {
            {0,   10,  18,   8,  inf, inf },
            {10,   0,  16,   9,  21,  inf },
            {inf, 16,   0,  inf, inf, 15 },
            {7,    9,  inf,  0,  inf, 12 },
            {inf, inf, inf, inf, 0,   23 },
            {inf, inf, 15,  inf, 23,  0 }
        };
        Floyd(test1);
        Floyd(test2);
        Floyd(test3);
    }
}
