using System;
class Program
{
    static void Algo1(int[,] arr)
    {
        int n = arr.GetLength(0);
        bool[] visited = new bool[n];
        int count = 0;
        void DFS(int num)
        {
            visited[num] = true;
            for (int i = 0; i < n; i++)
            {
                if (arr[num, i] == 1 && !visited[i])
                {
                    DFS(i);
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                DFS(i);
                count++;
            }
        }
        Console.WriteLine($"Количество компонент связности: {count}");
    }

    static void Algo2(int[,] arr)
    {
        int n = arr.GetLength(0);
        int[] visited = new int[n];
        visited[0] = 1;
        int count = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (arr[i,j] == 1)
                {
                    if (visited[i] != 0)
                    {
                        visited[i] = Math.Min(visited[i], visited[j]);
                        visited[j] = visited[i];
                    }
                    else
                    {
                        visited[i] = visited[j];
                    }
                }
            }
            if (visited[i] == 0)
            {
                count++;
                visited[i] = count; 
            }
        }
        HashSet<int> components = new HashSet<int>();
        foreach (int component in visited)
        {
            components.Add(component);
        }
        Console.WriteLine($"Количество компонент связности: {components.Count}");
    }


    static void Main()
    {
        int[,] test1 = {
            { 0,1,1,0,0 },
            { 1,0,0,1,0 },
            { 1,0,0,0,1 },
            { 0,1,0,0,0 },
            { 0,0,1,0,0 }
        };
        int[,] test2 = {
            { 0,0,0,0,0,1,0,1 },
            { 0,0,0,1,1,0,0,0 },
            { 0,0,0,0,0,1,1,0 },
            { 0,1,0,0,1,0,0,0 },
            { 0,1,0,1,0,0,0,0 },
            { 1,0,1,0,0,0,1,0 },
            { 0,0,1,0,0,1,0,0 },
            { 1,0,0,0,0,0,0,0 }
        };
        int[,] test3 = {
            { 0,1,0,0,0,0,0 },
            { 1,0,0,1,0,0,0 },
            { 0,0,0,0,0,1,0 },
            { 0,1,0,0,0,0,0 },
            { 0,0,0,0,0,0,1 },
            { 0,0,1,0,0,0,0 },
            { 0,0,0,0,1,0,0 }
        };
        int[,] test4 = {
            { 0,0,0,0,0,0 },
            { 0,0,0,0,0,0 },
            { 0,0,0,0,0,0 },
            { 0,0,0,0,0,0 },
            { 0,0,0,0,0,0 },
            { 0,0,0,0,0,0 } 
        };
        int[,] test5 =
        {
            { 0,0,0,0,0,1,0,1 },
            { 0,0,1,0,0,0,0,0 },
            { 0,1,0,0,0,0,0,0 },
            { 0,0,0,0,0,1,0,1 },
            { 0,0,0,0,0,0,1,0 },
            { 1,0,0,1,0,0,0,0 },
            { 0,0,0,0,1,0,0,0 },
            { 1,0,0,1,0,0,0,0 }
        };
        Console.WriteLine("Алгоритм 1");
        Algo1(test1);
        Algo1(test2);
        Algo1(test3);
        Algo1(test4);
        Algo1(test5);
        Console.WriteLine("Алгоритм 2");
        Algo2(test1);
        Algo2(test2);
        Algo2(test3);
        Algo2(test4);
        Algo2(test5);
    }
}
