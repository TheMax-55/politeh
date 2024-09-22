using System;

    class Program {
        static void Main() {
            int nomer1=Convert.ToInt32(Console.ReadLine());
            int nomer2=Convert.ToInt32(Console.ReadLine());
            (nomer1,nomer2)=(nomer2,nomer1);
            Console.WriteLine(nomer1);
            Console.WriteLine(nomer2);
        }
        
    }