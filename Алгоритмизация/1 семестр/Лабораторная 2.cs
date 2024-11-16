using System;
class Program
{
    static void Main()
    {

        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine()), lokmax = 0, a1 = 0, a2 = 0, a3 = 0, kolvo = 0, kolvo2 = 0, max1 = 0, max2 = 0;
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; n > i; i++)
        {
            a1 = a2;
            a2 = a3;
            a3 = Convert.ToInt32(Console.ReadLine());
            //Задание 1 Определить локальный минимум
            if (a2 > a1 && a2 > a3 && i >= 2)
            {
                lokmax++;
            }

            //Задание 2 Определить все ли элементы являются нечетными
            if (a3 % 2 != 0)
            {
                kolvo++;
            }
            //Задание 3 Определить второй максимум
            if (i == 2)
            {
                max1 = Math.Max(a1, Math.Max(a2, a3));
                max2 = a1 + a2 + a3 - Math.Max(a1, Math.Max(a2, a3)) - Math.Min(a1, Math.Min(a2, a3));
            }
            if (a3 > max1)
            {
                max2 = max1;
                max1 = a3;
            }
            else if (a3 > max2)
            {
                max2 = a3;
            }
            //Задание 4 Определить количество элементов, оканчивающихся на 5
            if (Math.Abs(a3 % 10) == 5)
            {
                kolvo2++;
            }
        }
        Console.WriteLine($"Количество локальных максимумов: {lokmax}");
        Console.WriteLine($"Второй максимум: {max2}");
        if (kolvo == n)
        {
            Console.WriteLine("Все элементы нечётные");
        }
        else
        {
            Console.WriteLine("Не все элементы нечётные");
        }

        Console.WriteLine($"Количество элементов, оканчивающихся на 5: {kolvo2}");
    }
}

    