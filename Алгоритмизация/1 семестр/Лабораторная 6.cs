using System;
class Program
{
    static void Main()
    {

        Console.Write("Введите количество строк: ");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] arr = new int[m, n];
        Console.WriteLine("Введите элементы: ");
        for (int i = 0; m > i; i++)
        {
            for (int j = 0; n > j; j++)
            {
                arr[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        //Задание 1 Определить пары номеров столбцов, состоящих из одинаковых элементов
        for (int col1 = 0; col1 < n; col1++)
        {
            for (int col2 = col1 + 1; col2 < n; col2++)
            {
                int[] column1 = new int[m];
                int[] column2 = new int[m];
                for (int row = 0; row < m; row++)
                {
                    column1[row] = arr[row, col1];
                    column2[row] = arr[row, col2];
                }
                for (int i = 0; i < m - 1; i++)
                {
                    for (int j = 0; j < m - i - 1; j++)
                    {
                        if (column1[j] > column1[j + 1])
                        {
                            int temp1 = column1[j];
                            column1[j] = column1[j + 1];
                            column1[j + 1] = temp1;
                        }
                        if (column2[j] > column2[j + 1])
                        {
                            int temp2 = column2[j];
                            column2[j] = column2[j + 1];
                            column2[j + 1] = temp2;
                        }
                    }
                }
                int count = 0;
                for (int i = 0; i < m; i++)
                {
                    if (column1[i] == column2[i])
                    {
                        count++;
                    }
                }

                if (count == m)
                {
                    Console.WriteLine($"Столбцы {col1} и {col2} одинаковы");
                }
            }
        }
        //Задание 2 Отсортировать строки по убыванию количества нулевых элементов в строках
        int[] zero = new int[m];
        for (int i = 0; m > i; i++)
        {
            for (int j = 0; n > j; j++)
            {
                if (arr[i, j] == 0)
                {
                    zero[i]++;
                }
            }
        }
        for (int i = 0; i < m - 1; i++)
        {
            for (int j = 0; j < m - i - 1; j++)
            {
                if (zero[j] < zero[j + 1])
                {
                    for (int k = 0; k < n; k++)
                    {
                        int temp = arr[j, k];
                        arr[j, k] = arr[j + 1, k];
                        arr[j + 1, k] = temp;
                    }
                    int tempZero = zero[j];
                    zero[j] = zero[j + 1];
                    zero[j + 1] = tempZero;
                }
            }
        }
        Console.WriteLine("Сортировка по убыванию: ");
        for (int i = 0; m > i; i++)
        {
            for (int j = 0; n > j; j++)
            {
                Console.Write($"{arr[i, j]}\t");
            }
            Console.WriteLine();
        }
        //Задание 3 Поменять местами максимальный и минимальный элемент
        int maxi = arr[0, 0], mini = arr[0, 0];
        for (int i = 0; m > i; i++)
        {
            for (int j = 0; n > j; j++)
            {
                if (arr[i, j] > maxi)
                {
                    maxi = arr[i, j];
                }
                if (arr[i, j] < mini)
                {
                    mini = arr[i, j];
                }
            }
        }
        for (int i = 0; m > i; i++)
        {
            for (int j = 0; n > j; j++)
            {
                if (arr[i, j] == maxi)
                {
                    arr[i, j] = mini;
                }
                else if (arr[i, j] == mini)
                {
                    arr[i, j] = maxi;
                }
            }
        }
        Console.WriteLine("Изменение макс и мин местами: ");
        for (int i = 0; m > i; i++)
        {
            for (int j = 0; n > j; j++)
            {
                Console.Write($"{arr[i, j]}\t");
            }
            Console.WriteLine();
        }

    }
}