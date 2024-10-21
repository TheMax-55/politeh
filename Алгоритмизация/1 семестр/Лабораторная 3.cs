using System;
using System.IO.Compression;
class Program
{
    static void Main()
    {
        //Задание 1 Минимальный размер подпоследовательности, состоящей из 1
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine()), min = n + 1, posl = 0, posl1 = 0;
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; i < n; i++)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                posl++;
            }
            else if (posl > 0)
            {
                min = Math.Min(min, posl);
                posl = 0;
            }
            if (x != 1)
            {
                posl1++;
            }
        }
        if (posl > 0)
        {
            min = Math.Min(min, posl);
        }
        if (posl1 == n)
        {
            min = 0;
        }
        Console.WriteLine($"Минимальный размер последовательности единиц: {min}");

        //Задание 2 Максимальный размер подпоследовательности, состоящей из одинаковых четных элементов
        Console.Write("Введите количество элементов: ");
        int n2 = Convert.ToInt32(Console.ReadLine()), max = 0, posl2 = 0, zam = 0;
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; i < n2; i++)
        {
            int y = Convert.ToInt32(Console.ReadLine());
            if (y % 2 == 0 && y != zam)
            {
                zam = y;
                max = Math.Max(max, posl2);
                posl2 = 0;
            }
            if (y % 2 == 0 && y == zam)
            {
                posl2++;
            }
            if (y % 2 != 0)
            {
                max = Math.Max(max, posl2);
                posl2 = 0;
            }
        }
        max = Math.Max(max, posl2);
        Console.WriteLine($"Максимальный размер подпоследовательности одинаковых четных элементов: {max}");

        //Задание 3 Максимальная сумма подпоследовательности, состоящей из четных элементов
        Console.Write("Введите количество элементов: ");
        int n3 = Convert.ToInt32(Console.ReadLine()), msum = 0, sum = 0;
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; i < n3; i++)
        {
            int z = Convert.ToInt32(Console.ReadLine());
            if (z % 2 == 0)
            {
                sum += z;
            }
            else
            {
                msum = Math.Max(msum, sum);
                sum = 0;
            }
        }
        msum = Math.Max(msum, sum);
        Console.WriteLine($"Максимальная сумма подпоследовательности четных элементов: {msum}");
    }
}