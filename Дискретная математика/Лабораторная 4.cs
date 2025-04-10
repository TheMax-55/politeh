using System;
class Program
{
    static void Dijkstra(double[,] arr, int v1, int v2)
    {
        double inf = double.PositiveInfinity;
        int n = arr.GetLength(0);
        double[] sum = new double[n];
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            sum[i] = (i != v1) ? inf : 0;
        }
        for (int i = 0; i < n - 1; i++)
        {
            int currv = -1;
            double minsum = inf;
            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && sum[j] < minsum)
                {
                    minsum = sum[j];
                    currv = j;
                }
            }
            if (currv == -1) break;
            visited[currv] = true;
            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && arr[currv, j] != inf && sum[currv] + arr[currv, j] < sum[j])
                {
                    sum[j] = sum[currv] + arr[currv, j];
                }
            }
        }
        Console.WriteLine(sum[v2] == inf ? $"Маршрута между вершинами {v1 + 1} и {v2 + 1} не существует." : $"Длина кратчайшего маршрута от {v1 + 1} до {v2 + 1}: {sum[v2]}");
    }
    static void Main()
    {
        double i = double.PositiveInfinity;
        double[,] test1 = {
            { i,2,i,19,25 },
            { 2,i,6,14,i },
            { 21,6,i,1,13 },
            { i,6,1,i,2 },
            { 7,11,6,2,i },
        };
        double[,] test2 =
        {
            { i,9,i,6,11,i },
            { i,i,8,i,i,i },
            { i,i,i,i,6,9 },
            { i,5,7,i,6,i },
            { i,6,i,i,i,4 },
            { i,i,i,i,i,i }
        };
        double[,] test3 =
        {
            { i,5,i,i,2,4 },
            { 5,i,12,i,i,i },
            { i,12,i,9,i,3 },
            { i,i,9,i,7,10 },
            { 2,i,i,7,i,8 },
            { 4,1,3,10,8,i }
        };
        Dijkstra(test1, 3, 0);
        Dijkstra(test1, 1, 4);
        Dijkstra(test2, 0, 4);
        Dijkstra(test2, 4, 3);
        Dijkstra(test3, 1, 5);
        Dijkstra(test3, 5, 4);
    }
}
