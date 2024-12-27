using System;
using System.Numerics;
class Math
{
    public int number1;
    public int number2;
    public Math()
    {
        number1 = 0;
        number2 = 0;
    }
    public Math(int number1)
    {
        this.number1 = number1;
        number2 = 0;
    }
    public Math(int number1, int number2)
    {
        this.number1 = number1;
        this.number2 = number2;
    }
    public void Addition()
    {
        Console.WriteLine(number1 + number2);
    }
    public void Subtraction()
    {
        Console.WriteLine(number1 - number2);
    }
    public void Multiplication()
    {
        Console.WriteLine(number1 * number2);
    }
    public void Division()
    {
        if (number2 != 0)
        {
            Console.WriteLine(number1 / number2);
        }
        else
        {
            Console.WriteLine("На 0 делить нельзя");
        }
    }

    static void Main()
    {
        Math Primer1 = new Math();
        Math Primer2 = new Math(10);
        Math Primer3 = new Math(20,4);
        Console.WriteLine("Объект 1");
        Primer1.Addition();
        Primer1.Subtraction();
        Primer1.Multiplication();
        Primer1.Division();
        Console.WriteLine("Объект 2");
        Primer2.Addition(); 
        Primer2.Subtraction();
        Primer2.Multiplication();
        Primer2.Division();
        Console.WriteLine("Объект 3");
        Primer3.Addition();
        Primer3.Subtraction();
        Primer3.Multiplication();
        Primer3.Division();
    }
}
