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
        double i = double.PositiveInfinity;
        double[,] test1 = {
            { i,1,i,i,3 },
            { i,i,8,7,1 },
            { i,i,i,1,-5 },
            { i,i,2,i,i },
            { i,i,i,4,i },
        };
        double[,] test2 =
        {
            { i,2,i,19,25 },
            { 2,i,6,14,i },
            { 21,6,i,1,13 },
            { i,6,1,i,2 },
            { 7,11,6,2,i }
        };
        Ford(test1, 0, 4);
        Ford(test1, 2, 1);
        Ford(test1, 4, 1);
        Ford(test2, 0, 3);
        Ford(test2, 1, 2);
        Ford(test2, 2, 4);
    }
}
