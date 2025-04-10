using System;
class Program
{
    static void Wave(double[,] arr, int n1, int m1, int n2, int m2)
    {
        double inf = double.PositiveInfinity;
        int n = arr.GetLength(0);
        double[,] arr2 = new double[n + 2, n + 2]; 
        for(int i = 0; i < n+2; i++)
        {
            for (int j = 0; j < n+2; j++)
            {
                if (i == 0 || j == 0 || i == n + 1 || j == n + 1)
                {
                    arr2[i, j] = -1;
                }
                else
                {
                    arr2[i, j] = arr[i - 1, j - 1];
                }
            }
        }
        arr2[n1 + 1, m1 + 1] = 0;
        for (int k = 0; k < n * n; k++)
        {
            for (int i = 0; i < n + 2; i++)
            {
                for (int j = 0; j < n + 2; j++)
                {
                    if (arr2[i, j] != inf && arr2[i, j] != -1)
                    {
                        if (arr2[i - 1, j] > arr2[i, j])
                        {
                            arr2[i - 1, j] = arr2[i, j] + 1;
                        }
                        if (arr2[i, j - 1] > arr2[i, j])
                        {
                            arr2[i, j - 1] = arr2[i, j] + 1;
                        }
                        if (arr2[i + 1, j] > arr2[i, j])
                        {
                            arr2[i + 1, j] = arr2[i, j] + 1;
                        }
                        if (arr2[i, j + 1] > arr2[i, j])
                        {
                            arr2[i, j + 1] = arr2[i, j] + 1;
                        }
                    }
                }
            }
        }
        if (arr2[n2 + 1, m2 + 1] != inf)
        {
            Console.WriteLine($"Значение в точке: { arr2[n2 + 1, m2 + 1] }");
        }
        else
        {
            Console.WriteLine($"Невожмозно дойти.");
        }
    }

    static void Main()
    {
        double i = double.PositiveInfinity;
        double[,] test1 =
        {
            { i, i, i, -1, -1 },
            { i, -1, i, i, i },
            { i, -1, i, -1, i },
            { i, i, i, -1, i },
            { i, i, i, -1, i }
        };
        double[,] test2 =
        {
            { i, -1, -1, i },
            { -1, i, i, -1},
            { -1, -1, -1, -1},
            { i, i, i, i}
        };
        double[,] test3 =
        {
            { i,i,-1,i,i,i,i,i },
            { i,i,-1,i,i,i,i,i },
            { i,i,i,i,i,i,i,i },
            { i,i,i,i,i,i,i,i },
            { i,-1,-1,-1,-1,i,i,i },
            { i,i,i,i,i,i,i,i },
            { i,i,i,i,i,i,i,i },
            { i,i,i,i,i,i,i,i}
        };
        Wave(test1, 3, 1, 3, 4);
        Wave(test2, 3, 0, 0, 3);
        Wave(test3, 6, 3, 0, 3);
    }
}
