using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите:");
        string stroka = Console.ReadLine();
        int kolvo1 = 0, kolvo2=0;
        string glasn = "aeiouyAEIOUY";
        //Задание 1 Убрать лишние пробелы
        while (stroka.Contains("  ")){
            stroka=stroka.Replace("  ", " ");
        }
        Console.WriteLine(stroka);
        string[] stroka2 = stroka.Split(" ");
        //Задание 2 Определить количество слов, в которых на четных местах стоят гласные буквы
        for (int i = 0; i < stroka2.Length; i++)
        {
            for (int j = 1; j < stroka2[i].Length; j += 2)
            {
                if (glasn.Contains(stroka2[i][j]))
                {
                    kolvo1++;
                    break;
                }
            }
        }
        Console.WriteLine(kolvo1);
        //Задание 3 Определить количество слов, длина которых нечетная, а первый и последний символ совпадают
        for (int i = 0; stroka2.Length > i; i++)
        {
            if (stroka2[i].Length % 2 != 0 && stroka2[i][0] == stroka2[i][stroka2[i].Length - 1])
            {
                kolvo2++;
            }

        }
        Console.WriteLine(kolvo2);
        //Задание 4 Выдать все слова, в которых присутствует хотя бы 1 символ а
        for (int i = 0; stroka2.Length > i; i++)
        {

                if (stroka2[i].Contains('a') || stroka2[i].Contains('A'))
                {
                Console.WriteLine(stroka2[i]);
                }
        }
    }
}