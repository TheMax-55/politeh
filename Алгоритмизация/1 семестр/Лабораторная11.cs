using System;
using System.Buffers;
class Bake
{
    public int Temperature;
    public int Time;
}
class Bread : Bake
{
    public string Name;
}
class Program
{
    static void Main()
    {
        int count = 0;
        string[][] arr = new string[2][];
        Bread bread = new Bread { };
        for (int i = 0; ; i++)
        {
            Console.WriteLine("1. Заполнить базу данных.");
            Console.WriteLine("2. Выборка по длительности.");
            Console.WriteLine("3. Выборка по температуре.");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("Введите название хлеба: ");
                    bread.Name = Console.ReadLine();
                    Console.Write("Введите температуру хлеба: ");
                    bread.Temperature = int.Parse(Console.ReadLine());
                    Console.Write("Введите продолжительность выпекания хлеба: ");
                    bread.Time = int.Parse(Console.ReadLine());
                    arr[j] = [bread.Name, bread.Temperature.ToString(), bread.Time.ToString()];
                }
            }
            if (n == 2)
            {
                if (arr[0] != null) {
                    Console.Write("Введите продолжительность выпекания: ");
                    int duration = int.Parse(Console.ReadLine());
                    for (int j = 0; j < 2; j++) {
                        if (duration < int.Parse(arr[j][2]))
                        {
                            Console.WriteLine($"Наименование: {arr[j][0]} Температура: {arr[j][1]} Длительность: {arr[j][2]}");
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Такого хлеба нет.");
                    }
                }
                else
                {
                    Console.WriteLine("Сначала заполните базу данных.");
                }
            }
            if (n == 3)
            {
                if (arr[0] != null) {
                    Console.Write("Введите температуру: ");
                    int currTemp = int.Parse(Console.ReadLine());
                    for (int j = 0; j < 2; j++)
                    {
                        if (currTemp >= int.Parse(arr[j][1]))
                        {
                            Console.WriteLine($"Наименование: {arr[j][0]} Температура: {arr[j][1]} Длительность: {arr[j][2]}");
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Такого хлеба нет.");
                    }
                }
                else
                {
                    Console.WriteLine("Сначала заполните базу данных.");
                }
            }
        }
    }
}