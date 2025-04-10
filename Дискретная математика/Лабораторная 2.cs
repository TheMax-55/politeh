using System;
class Edge
{
    public int v1 { get; set; }
    public int v2 { get; set; }
}
class EdgeList
{
    public int sum { get; set; }
    public Edge edge { get; set; } = new Edge();
    public EdgeList(int sum, Edge edge)
    {
        this.sum = sum;
        this.edge = edge;
    }
}
class Program 
{
    static void Prima(int[,] arr)
    {
        int count = 0;
        int n = arr.GetLength(0);
        bool[] visited = new bool[n];
        visited[0] = true;
        int visitedCount = 1;

        while (visitedCount < n)
        {
            int min = int.MaxValue;
            int minvert = -1;
            for (int i = 0; i < n; i++)
            {
                if (visited[i])
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (!visited[j] && arr[i, j] != 0 && arr[i, j] < min)
                        {
                            min = arr[i, j];
                            minvert = j;
                        }
                    }
                }
            }
            count += min;
            visited[minvert] = true;
            visitedCount++;
        }
        Console.WriteLine(count);
    }

    static void Kruskal(int[,] arr)
    {
        int count = 0;
        int n = arr.GetLength(0);
        List<EdgeList> list = new List<EdgeList>();
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                if (arr[i, j] != 0)
                {
                    Edge edge = new Edge();
                    edge.v1 = i;
                    edge.v2 = j;
                    list.Add(new EdgeList(arr[i, j], edge));
                }
            }
        }
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i; j < list.Count; j++)
            {
                if (list[i].sum > list[j].sum)
                {
                    int v1 = list[i].edge.v1;
                    int v2 = list[i].edge.v2;
                    int temp = list[i].sum;

                    list[i].sum = list[j].sum;
                    list[i].edge.v1 = list[j].edge.v1;
                    list[i].edge.v2 = list[j].edge.v2;

                    list[j].sum = temp;
                    list[j].edge.v1 = v1;
                    list[j].edge.v2 = v2;
                }
            }
        }
        int[] vertexes = new int[n];
        for (int i = 0; i < n; i++)
        {
            vertexes[i] = i + 1;
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (vertexes[list[i].edge.v1] != vertexes[list[i].edge.v2])
            {
                count += list[i].sum;
                int temp1 = vertexes[list[i].edge.v1];
                int temp2 = vertexes[list[i].edge.v2];
                for (int j = 0; j < n; j++)
                {
                    if (vertexes[j] == temp1 || vertexes[j] == temp2)
                    {
                        vertexes[j] = Math.Min(temp1, temp2);
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
    static void Main()
    {
        int[,] test1 =
        {
            { 0,5,0,0,2,4 },
            { 5,0,12,0,0,1 },
            { 0,12,0,9,0,3 },
            { 0,0,9,0,7,10 },
            { 2,0,0,7,0,8 },
            { 4,1,3,10,8,0 }
        };
        int[,] test2 =
        {
            { 0,5,2,0,0 },
            { 5,0,3,0,0 },
            { 2,3,0,10,12 },
            { 0,0,10,0,6 },
            { 0,0,12,6,0 }
        };
        int[,] test3 =
        {
            { 0,9,0,0,0,0 },
            { 9,0,3,5,0,0 },
            { 0,3,0,7,0,0 },
            { 0,5,7,0,8,7 },
            { 0,0,0,8,0,1 },
            { 0,0,0,7,1,0 }
        };
        int[,] test4 =
        {
            { 0,7,8,0,0,0 },
            { 7,0,11,2,0,0 },
            { 8,11,0,6,9,0 },
            { 0,2,6,0,11,9 },
            { 0,0,9,11,0,10 },
            { 0,0,0,9,10,0 }
        };
        Console.WriteLine("Прима");
        Prima(test1);
        Prima(test2);
        Prima(test3);
        Prima(test4);
        Console.WriteLine("Краскал");
        Kruskal(test1);
        Kruskal(test2);
        Kruskal(test3);
        Kruskal(test4);
    }
}
