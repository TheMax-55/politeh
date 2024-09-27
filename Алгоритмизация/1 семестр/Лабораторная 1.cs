using System;

class Program
{
    static void Main()
    {
        //Задание 1 Обмен значений
        int nomer1 = Convert.ToInt32(Console.ReadLine());
        int nomer2 = Convert.ToInt32(Console.ReadLine());
        (nomer1, nomer2) = (nomer2, nomer1);
        Console.WriteLine(nomer1);
        Console.WriteLine(nomer2);

        //Задание 2 Вывод наибольшего и наименьшего
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int max = 0, min = 0;
        max = (a + b + Math.Abs(a - b)) / 2;
        min = (a + b - Math.Abs(a - b)) / 2;
        Console.WriteLine($"Наибольшее: {max}");
        Console.WriteLine($"Наименьшее: {min}");

        //Задание 3 Поиск пройденного расстония
        Console.Write("Длина грядки: ");
        int L = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ширина ширина: ");
        int M = Convert.ToInt32(Console.ReadLine());
        Console.Write("Расстояние до колодца: ");
        int P = Convert.ToInt32(Console.ReadLine());
        Console.Write("Количество грядок: ");
        int N = Convert.ToInt32(Console.ReadLine());
        int S = 0;
        S = 2 * (P + M + L) * N + 2 * M * (N - 1) * N / 2;
        Console.WriteLine($"Ответ: {S}");
    }

}