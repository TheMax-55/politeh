using System;

    class Program {
        static void Main() {
            int a=Convert.ToInt32(Console.ReadLine());
            int b=Convert.ToInt32(Console.ReadLine());
            int max=0, min=0;
            max=(a+b+Math.Abs(a-b))/2;
            min=(a+b-Math.Abs(a-b))/2;
            Console.Write("Наибольшее: ");
            Console.WriteLine(max);
            Console.Write("Наименьшее: ");
            Console.WriteLine(min);
        }
        
    }