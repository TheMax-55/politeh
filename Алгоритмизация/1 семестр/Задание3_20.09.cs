using System;
    class Program {
        static void Main() {
            Console.Write("Длина грядки: ");
            int L=Convert.ToInt32(Console.ReadLine());
            Console.Write("Ширина ширина: ");
            int M=Convert.ToInt32(Console.ReadLine());
            Console.Write("Расстояние до колодца: ");
            int P=Convert.ToInt32(Console.ReadLine());
            Console.Write("Количество грядок: ");
            int N=Convert.ToInt32(Console.ReadLine());
            int S=0;
            S=2*(P+M+L)*N+2*M*(N-1)*N/2;
            Console.Write("Ответ: ");
            Console.WriteLine(S);
        }
        
    }