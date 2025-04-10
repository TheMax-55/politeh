using System;
class Program
{
    static void Main()
    {
        HashSet<string> set = new HashSet<string>();
        Console.Write("Введите элементы последовательности: ");
        string[] s = Console.ReadLine().Split(' ');
        //Задание 1
        foreach (string sym in s)
        {
            set.Add(sym);
        }
        Console.Write("Последовательность составлена из данных элементов: ");
        foreach (string sym in set)
        {
            Console.Write($"{sym} ");
        }
        //Задание 2
        int count = 0;
        string repeated = "";
        foreach (string currsym in set)
        {
            int currcount = 0;
            foreach (string sym in s)
            {
                if (currsym == sym)
                {
                    currcount++;
                }
            }
            if (currcount > count)
            {
                count = currcount;
                repeated = currsym + " ";
            }
            else if (currcount == count)
            {
                repeated = repeated + currsym + " ";
            }
        }
        Console.Write($"\nБольше всего повторялись: {repeated}");
    }
}