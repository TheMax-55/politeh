using System;
using System.Buffers;
using System.Threading;
class Bake
{
    public int Temperature;
    public int Time;
}
class Bread : Bake
{
    public string Name;
    public int Weight;
}
class Meat: Bake
{
    public string Name;
    public int Weight;
}


class Program
{
    static void Main()
    {
        string[][] arrbrd = new string[2][];
        string[][] arrmt = new string[2][];
        for (int i = 0; ; i++)
        {
            int currTemp = 0;
            int duration = 0;
            int countbrd = 0;
            int countmt = 0;
            Console.WriteLine("1. Заполнить базу данных хлеба.");
            Console.WriteLine("2. Заполнить базу данных мяса.");
            Console.WriteLine("3. Выборка по времени приготовления.");
            Console.WriteLine("4. Выборка по температуре.");
            Console.WriteLine("5. Выход.");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                for (int j = 0; j < 2; j++)
                {
                    Bread bread = new Bread();
                    Console.Write("Введите название хлеба: ");
                    bread.Name = Console.ReadLine();
                    Console.Write("Введите температуру хлеба: ");
                    bread.Temperature = int.Parse(Console.ReadLine());
                    Console.Write("Введите время приготовления хлеба: ");
                    bread.Time = int.Parse(Console.ReadLine());
                    Console.Write("Введите массу хлеба: ");
                    bread.Weight = int.Parse(Console.ReadLine());
                    arrbrd[j] = [bread.Name, bread.Temperature.ToString(), bread.Time.ToString(), bread.Weight.ToString()];
                }
            }
            if (n == 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    Meat meat = new Meat();
                    Console.Write("Введите название мяса: ");
                    meat.Name = Console.ReadLine();
                    Console.Write("Введите температуру мяса: ");
                    meat.Temperature = int.Parse(Console.ReadLine());
                    Console.Write("Введите время приготовления мяса: ");
                    meat.Time = int.Parse(Console.ReadLine());
                    Console.Write("Введите массу мяса: ");
                    meat.Weight = int.Parse(Console.ReadLine());
                    arrmt[j] = [meat.Name, meat.Temperature.ToString(), meat.Time.ToString(), meat.Weight.ToString()];
                }
            }
            if (n == 3)
            {
                if (arrbrd[0]!=null || arrmt[0] != null)
                {
                    Console.Write("Введите время приготовления: ");
                    duration = int.Parse(Console.ReadLine());
                    if (arrbrd[0] != null)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (duration < int.Parse(arrbrd[j][2]))
                            {
                                Console.WriteLine($"Наименование: {arrbrd[j][0]} Температура: {arrbrd[j][1]} Длительность: {arrbrd[j][2]} Масса: {arrbrd[j][3]}");
                                countbrd++;
                            }
                        }
                        if (countbrd == 0)
                        {
                            Console.WriteLine("Такого хлеба нет.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Хлеба нет.");
                    }
                    if (arrmt[0] != null)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (duration < int.Parse(arrmt[j][2]))
                            {
                                Console.WriteLine($"Наименование: {arrmt[j][0]} Температура: {arrmt[j][1]} Длительность: {arrmt[j][2]} Масса: {arrmt[j][3]}");
                                countmt++;
                            }
                        }
                        if (countmt == 0)
                        {
                            Console.WriteLine("Такого мяса нет.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Мяса нет.");
                    }
                }
                else
                {
                    Console.WriteLine("Сначала заполните базу данных.");
                }
            }
            if (n == 4)
            {
                if (arrbrd[0] != null || arrmt[0] != null)
                {
                    Console.Write("Введите температуру: ");
                    currTemp = int.Parse(Console.ReadLine());

                    if (arrbrd[0] != null)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (currTemp >= int.Parse(arrbrd[j][1]))
                            {
                                Console.WriteLine($"Наименование: {arrbrd[j][0]} Температура: {arrbrd[j][1]} Длительность: {arrbrd[j][2]} Масса: {arrbrd[j][3]}");
                                countbrd++;
                            }
                        }
                        if (countbrd == 0)
                        {
                            Console.WriteLine("Такого хлеба нет.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Хлеба нет.");
                    }
                    if (arrmt[0] != null)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (currTemp >= int.Parse(arrmt[j][1]))
                            {
                                Console.WriteLine($"Наименование: {arrmt[j][0]} Температура: {arrmt[j][1]} Длительность: {arrmt[j][2]} Масса: {arrmt[j][3]}");
                                countmt++;
                            }
                        }
                        if (countmt == 0)
                        {
                            Console.WriteLine("Такого мяса нет.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Мяса нет.");
                    }
                }
                else
                {
                    Console.WriteLine("Сначала заполните базу данных.");
                }
            }
            if (n == 5)
            {
                break;
            }
        }
    }
}
