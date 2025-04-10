using System;
using System.Data;
class Math
{
    public static int Addition(int num1, int num2)
    {
        return num1 + num2;
    }
    public static int Subtraction(int num1, int num2)
    {
        return num1 - num2;
    }
    public static int Multiplication(int num1, int num2)
    {
        return num1 * num2;
    }
    public static int Division(int num1, int num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("На ноль делить нельзя.");
        }
        return num1 / num2;

    }
}
    
delegate int MathDel(int num1, int num2);
class Program
{
    static void Main()
    {
        int num1 = 2;
        int num2 = 8;

        MathDel math1 = Math.Addition;
        int result1 = math1(num1, num2);
        math1 = Math.Subtraction;
        result1 = math1(result1, num2);
        math1 = Math.Multiplication;
        result1 = math1(result1, num2);
        Console.WriteLine($"Результат первой последовательности операций: {result1}");

        try
        { 
            MathDel math2 = Math.Multiplication;
            int result2 = math2(num1, num2);
            math2 = Math.Subtraction;
            result2 = math2(result2, num1);
            math2 = Math.Division;
            result2 = math2(result2, num1);
            Console.WriteLine($"Результат второй последовательности операций: {result2}");
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
