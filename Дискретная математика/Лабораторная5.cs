using System;
class Program
{
    static void Ford(double[,] arr, int v1, int v2)
    {
        double inf = double.PositiveInfinity;
        int n = arr.GetLength(0);
        double[] lambda = new double[n];
        for (int i = 0; i < n; i++)
        {
            lambda[i] = (i != v1) ? inf : 0;
        }
        for (int k = 1; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (lambda[i] + arr[i, j] < lambda[j])
                    {
                        lambda[j] = lambda[i] + arr[i, j];
                    }
                }
            }
        }
        Console.WriteLine(lambda[v2]!=inf ? $"Длина кратчайшего маршрута: {lambda[v2]}" : "Маршрута между точками нет.");
    }
    static void Main()
    {
        double inf = double.PositiveInfinity;
        double[,] test1 = {
            { inf,   1, inf, inf,  3  },
            { inf, inf,   8,   7,  1  },
            { inf, inf, inf,   1,  -5 },
            { inf, inf,   2, inf, inf },
            { inf, inf, inf,   4, inf },
        };
        double[,] test2 =
        {
            { inf, 2, inf, 19, 25 },
            { 2, inf, 6, 14, inf },
            { 21, 6, inf, 1, 13 },
            { inf, 6, 1, inf, 2 },
            { 7, 11, 6, 2, inf }
        };
        Ford(test1, 0, 4);
        Ford(test1, 2, 1);
        Ford(test1, 4, 1);
        Ford(test2, 0, 3);
        Ford(test2, 1, 2);
        Ford(test2, 2, 4);
    }
}
