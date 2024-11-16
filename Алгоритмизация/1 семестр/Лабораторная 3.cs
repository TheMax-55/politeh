using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        int n = Convert.ToInt32(Console.ReadLine()), min = n + 1, posl = 0, posl1 = 0, max = 0, posl2 = 0, zam = 0, msum = 0, sum = 0;
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; i < n; i++)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            //Задание 1 Минимальный размер подпоследовательности, состоящей из 1
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
            //Задание 2 Максимальный размер подпоследовательности, состоящей из одинаковых четных элементов
            if (x % 2 == 0 && x != zam)
            {
                zam = x;
                max = Math.Max(max, posl2);
                posl2 = 0;
            }
            if (x % 2 == 0 && x == zam)
            {
                posl2++;
            }
            if (x % 2 != 0)
            {
                max = Math.Max(max, posl2);
                posl2 = 0;
            }
            //Задание 3 Максимальная сумма подпоследовательности, состоящей из четных элементов
            if (x % 2 == 0)
            {
                sum += x;
            }
            else if (msum == 0 || sum > msum && sum != 0)
            {
                msum = sum;
                sum = 0;
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
        
        max = Math.Max(max, posl2);
        Console.WriteLine($"Максимальный размер подпоследовательности одинаковых четных элементов: {max}");
        
        if (sum != 0 && sum > msum)
        {
            msum = sum;
        }
        Console.WriteLine($"Максимальная сумма подпоследовательности четных элементов: {msum}");
    }
}