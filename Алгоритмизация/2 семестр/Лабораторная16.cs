using System;
class Program
{
    unsafe static void Main()
    {
        Console.Write("Введите размерность массива: ");
        int size = int.Parse(Console.ReadLine());
        int* array = stackalloc int[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write("Введите целое число: ");
            array[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < size; i++)
        {
            int reverse = 0;
            int temp = array[i];
            while (temp > 0)
            {
                reverse = reverse * 10 + temp % 10;
                temp /= 10;
            }
            if (array[i] == reverse) Console.WriteLine($"{array[i]} палиндром.");
            else Console.WriteLine($"{array[i]} не палиндром.");
        }
    }
}
