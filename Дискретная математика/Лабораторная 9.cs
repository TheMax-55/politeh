using System;

class Program
{
    static void Ford(double[,] matrix)
    {
        double inf = double.PositiveInfinity;
        int n = matrix.GetLength(0);
        double maxFlow = 0;
        while (true)
        {
            int[] parent = new int[n];
            Array.Fill(parent, -1);
            double[] pathCapacity = new double[n];
            Array.Fill(pathCapacity, 0);
            pathCapacity[0] = inf;
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            while (stack.Count > 0)
            {
                int current = stack.Pop();
                for (int next = 0; next < n; next++)
                {
                    if (matrix[current, next] > 0 && parent[next] == -1)
                    {
                        double capacity = Math.Min(pathCapacity[current], matrix[current, next]);
                        parent[next] = current;
                        pathCapacity[next] = capacity;
                        stack.Push(next);
                    }
                }
            }
            if (parent[n - 1] == -1) break;
            double flow = pathCapacity[n - 1];
            maxFlow += flow;
            for (int v = n - 1; v != 0; v = parent[v])
            {
                int u = parent[v];
                matrix[u, v] -= flow;
                matrix[v, u] += flow;
            }
        }

        Console.WriteLine(maxFlow);
    }
    static void Main()
    {
        double i = double.NegativeInfinity;
        double[,] test1 =
        {
            { i,15,i,i,76,54 },
            { i,i,16,i,i,i },
            { i,i,i,23,13,i },
            { i,i,i,i,i,12 },
            { i,31,i,7,i,8 },
            { i,i,i,i,i,i }
        };
        double[,] test2 = 
        {
            { i,40,i,70,60,i,20 },
            { i,i,i,i,i,i,70 },
            { i,i,i,i,60,30,40 },
            { i,i,i,i,i,90,20 },
            { i,i,i,i,i,20,90 },
            { i,i,i,i,i,i,100 },
            { i,i,i,i,i,i,i }
        };
        double[,] test3 =
        {
            { i,12,65,i,41,i },
            { i,i,i,17,38,i },
            { i,i,i,i,11,16 },
            { i,i,34,i,i,19 },
            { i,i,i,i,i,50 },
            { i,i,i,i,i,i }
        };
        double[,] test4 =
        {
            { i,76,47,i,i,41 },
            { i,i,i,i,44,56 },
            { i,i,i,25,15,i },
            { i,35,i,i,13,29 },
            { i,i,i,i,i,50 },
            { i,i,i,i,i,i }
        };
        double[,] test5 =
        {
            {i,15,18,9,i,i,i },
            {i,i,15,i,7,12,i },
            {i,i,i,i,i,11,i },
            {i,i,14,i,i,10,i },
            {i,i,i,5,i,i,10 },
            {i,i,i,i,8,i,15 },
            {i,i,i,i,i,i,i },
        };
        Ford(test1);
        Ford(test2);
        Ford(test3);
        Ford(test4);
        Ford(test5);
    }
}
