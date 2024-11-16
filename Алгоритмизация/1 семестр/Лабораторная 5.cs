using System;
class Program
{
    static void Main()
    {
        
        Console.Write("Введите количество элементов массива: ");
        int n = Convert.ToInt32(Console.ReadLine()), kolvo = 0, kolvo2 = 0;
        int[] x = new int[n];
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; n > i; i++)
        {
            x[i] = Convert.ToInt32(Console.ReadLine());
        }
        //Задание 1 Определить кол-во элементов, оканчивающихся на 3
        for (int i = 0; n > i; i++)
        {
            if (Math.Abs(x[i] % 10) == 3)
            {
                kolvo++;
            }
        }
        Console.WriteLine($"Количество элементов, оканчивающихся на 3: {kolvo}");

        //Задание 2 Определить, являются ли элементы массива равномерно возрастающей последовательностью
        int razn = x[1] - x[0];
        for (int i = 1; n > i; i++)
        {
            if (razn == x[i] - x[i - 1] && razn > 0)
            {
                kolvo2++;
            }

        }
        if (kolvo2 == n - 1)
        {
            Console.WriteLine("Элементы являются равномерно возрастающей последовательностью");
        }
        else
        {
            Console.WriteLine("Элементы не являются равномерно возрастающей последовательностью");
        }
        //Задание 3 Поменять местами максимальный и минимальный элементы массива
        int maxi = x[0], mini = x[0];
        for (int i = 0; n > i; i++)
        {
            if (x[i] > maxi)
            {
                maxi = x[i];
            }
            if (x[i] < mini)
            {
                mini = x[i];
            }
        }
        for (int i = 0; n > i; i++)
        {
            if (x[i] == maxi)
            {
                x[i] = mini;
            }
            else if (x[i] == mini)
            {
                x[i] = maxi;
            }
        }
        for (int i = 0; n > i; i++)
        {
            Console.WriteLine(x[i]);
        }
    }
}
