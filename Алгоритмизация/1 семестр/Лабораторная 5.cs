using System;
using System.Xml.Schema;
class Program
{
    static void Main()
    {
        //Задание 1 Определить кол-во элементов, оканчивающихся на 3
        Console.Write("Введите количество элементов массива: ");
        int n1 = Convert.ToInt32(Console.ReadLine()), kolvo = 0;
        int[] x = new int[n1];
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; n1 > i; i++)
        {
            x[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; n1 > i; i++)
        {
            if (Math.Abs(x[i] % 10) == 3)
            {
                kolvo++;
            }
        }
        Console.WriteLine($"Количество элементов, оканчивающихся на 3: {kolvo}");

        //Задание 2 Определить, являются ли элементы массива равномерно возрастающей последовательностью
        Console.Write("Введите количество элементов массива: ");
        int n2 = Convert.ToInt32(Console.ReadLine()), kolvo2 = 0;
        int[] x2 = new int[n2];
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; n2 > i; i++)
        {
            x2[i] = Convert.ToInt32(Console.ReadLine());
        }
        int razn = x2[1] - x2[0];
        for (int i = 1; n2 > i; i++)
        {
            if (razn == x2[i] - x2[i - 1] && razn > 0)
            {
                kolvo2++;
            }

        }
        if (kolvo2 == n2 - 1)
        {
            Console.WriteLine("Элементы являются равномерно возрастающей последовательностью");
        }
        else
        {
            Console.WriteLine("Элементы не являются равномерно возрастающей последовательностью");
        }

        //Задание 3 Поменять местами максимальный и минимальный элементы массива
        Console.Write("Введите количество элементов массива: ");
        int n3 = Convert.ToInt32(Console.ReadLine());
        int[] x3 = new int[n3];
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; n3 > i; i++)
        {
            x3[i] = Convert.ToInt32(Console.ReadLine());
        }
        int maxi = x3[0], mini = x3[0];
        for (int i = 0; n3 > i; i++)
        {
            if (x3[i] > maxi)
            {
                maxi = x3[i];
            }
            if (x3[i] < mini)
            {
                mini = x3[i];
            }
        }
        for (int i = 0; n3 > i; i++)
        {
            if (x3[i] == maxi)
            {
                x3[i] = mini;
            }
            else if (x3[i] == mini)
            {
                x3[i] = maxi;
            }
        }
        for (int i = 0; n3 > i; i++)
        {
            Console.WriteLine(x3[i]);
        }
    }
}