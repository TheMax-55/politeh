using System;

class Program
{
    static void Main()
    {
        //Задание 1 Определить локальный максимум
        Console.Write("Введите количество элементов: ");
        int n1 = Convert.ToInt32(Console.ReadLine()), lokmax = 0, a = 0, alev = 0, aprav = 0;
        Console.WriteLine("Введите элементы: ");
        a = Convert.ToInt32(Console.ReadLine());
        aprav = Convert.ToInt32(Console.ReadLine());
        for (int i = 2; i < n1; i++)
        {
            alev = a;
            a = aprav;
            aprav = Convert.ToInt32(Console.ReadLine());
            if (a > alev && a > aprav)
            {
                lokmax++;
            }
        }
        Console.WriteLine($"Количество локальных максимумов: {lokmax}");

        //Задание 2 Определить все ли элементы являются нечетными
        Console.Write("Введите количество элементов: ");
        int n2 = Convert.ToInt32(Console.ReadLine()), kolvo = 0;
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; i < n2; i++)
        {
            int sim = Convert.ToInt32(Console.ReadLine());
            if (sim % 2 != 0)
            {
                kolvo++;
            }
        }
        if (kolvo==n2)
        {
            Console.WriteLine("Все элементы нечётные");
        }
        else
        {
            Console.WriteLine("Не все элементы нечётные");
        }

        //Задание 3 Определить второй максимум
        Console.Write("Введите количество элементов: ");
        int n3 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите элементы:");
        int x = Convert.ToInt32(Console.ReadLine());
        int y = Convert.ToInt32(Console.ReadLine());
        int max1 = Math.Max(x, y);
        int max2 = Math.Min(x, y);
        for (int i = 2; i < n3; i++)
        {
            int z = Convert.ToInt32(Console.ReadLine());
            if (z > max1)
            {
                max1 = z;
            }
            else if (z > max2)
            {
                max2 = z;
            }
        }
        Console.WriteLine($"Второй максимум: {max2}");

        //Задание 4 Определить количество элементов, оканчивающихся на 5
        Console.Write("Введите количество элементов: ");
        int n4 = Convert.ToInt32(Console.ReadLine()), kolvo2 = 0;
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; i < n4; i++)
        {
            int sim = Convert.ToInt32(Console.ReadLine());
            if (Math.Abs(sim % 10) == 5)
            {
                kolvo2++;
            }
        }
        Console.WriteLine($"Количество: {kolvo2}");
    }
}

    