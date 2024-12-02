using System;
class Program
{
    static void Main()
    {
        //Задание 1 Определить максимальную длину строки, состоящую из XYZ
        Console.Write("Введите:");
        string stroka = Console.ReadLine();
        int kolvo = 0, mkolvo = 0;
        for (int i = 0; stroka.Length > i; i++)
        {
            if ((stroka[i] == 'X' && kolvo % 3 == 0) || (stroka[i] == 'Y' && kolvo % 3 == 1) || (stroka[i] == 'Z' && kolvo % 3 == 2))
            {
                kolvo += 1;
                mkolvo = Math.Max(mkolvo, kolvo);
            }
            else if (stroka[i] == 'X')
            {
                kolvo = 1;
            }
            else
            {
                kolvo = 0;
            }
        }
        Console.WriteLine(mkolvo);

        //Задание 2 Определить символ, который реже всего встречается в образце a*b
        Console.Write("Введите:");
        string stroka2 = Console.ReadLine(), otvet = "", proverka = "";
        int minpovtor = stroka2.Length;
        for (int i = 2; stroka2.Length > i; i++)
        {
            int povtor = 0;
            if ((stroka2[i - 2] == 'A' || stroka2[i - 2] == 'a') && (stroka2[i] == 'B' || stroka2[i] == 'b'))
            {
                char temp = stroka2[i - 1];
                povtor++;
                for (int j = i + 1; stroka2.Length > j; j++)
                {
                    if ((stroka2[j - 2] == 'A' || stroka2[j - 2] == 'a') && stroka2[j - 1] == temp && (stroka2[j] == 'B' || stroka2[j] == 'b'))
                    {
                        povtor++;
                    }
                }
                if (minpovtor > povtor && !proverka.Contains(temp))
                {
                    minpovtor = povtor;
                    otvet = "";
                    otvet += temp;
                }
                else if (minpovtor == povtor && !proverka.Contains(temp))
                {
                    otvet += temp;
                }
                proverka += stroka2[i - 1];
            }
        }
        if (otvet == "")
        {
            Console.Write("Таких символов нет");
        }
        else
        {
            Console.Write(otvet);
        }

    }
}