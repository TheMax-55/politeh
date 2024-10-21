using System;

class Programm
{
    static void Main()
    {
        //Перевернуть элемент, удалив все нечетные цифры
        Console.Write("Введите элемент: ");
        int n = Convert.ToInt32(Console.ReadLine());
        while (n>0)
        {
            int rev = 0, cet1 = 0, cet2 = 0;
            while (n > 0)
            {
                if ((n % 10) % 2 == 0 && n % 10 != 0)
                {
                    rev = rev * 10 + (n % 10);
                    cet1++;
                }
                else if((n % 10) % 2 != 0)
                {
                    cet2++;
                }
                else if (n%10==0)
                {
                    cet1++; 
                }
                n /= 10;
                


            }
            if (cet2 - cet1 == cet2)
            {
                Console.WriteLine("Четных цифр нет");
            }
            else
            {
                Console.WriteLine(rev);
            }
            Console.Write("Введите элемент: ");
            n = Convert.ToInt32(Console.ReadLine());
            
        }

    }
        
}