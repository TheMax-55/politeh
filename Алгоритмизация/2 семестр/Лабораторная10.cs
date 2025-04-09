using System;
class Math<T>
{
    public T num1 { get; set; }
    public T num2 { get; set; }
    public Math(T num1, T num2)
    {
        this.num1 = num1;
        this.num2 = num2;
    }
    public T Addition()
    {
        dynamic num1 = this.num1;
        dynamic num2 = this.num2;
        return num1 + num2;
    }
    public T Subtraction()
    {
        dynamic num1 = this.num1;
        dynamic num2 = this.num2;
        return num1 - num2;
    }
    public T Multiplication()
    {
        dynamic num1 = this.num1;
        dynamic num2 = this.num2;
        return num1 * num2;
    }
    public T Division()
    {
        dynamic num1 = this.num1;
        dynamic num2 = this.num2;
        if (num2 == 0)
        {
            throw new DivideByZeroException("На ноль делить нельзя.");
        }
        return num1 / num2;
    }
}
class Program
{
    static void Main()
    {
        Math<int> math1 = new Math<int>(32, 0);
        int result11 = math1.Addition();
        Console.WriteLine(result11);
        int result12 = math1.Subtraction();
        Console.WriteLine(result12);
        int result13 = math1.Multiplication();
        Console.WriteLine(result13);
        try
        {
            int result14 = math1.Division();
            Console.WriteLine(result14);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
        }

        Math<double> math2 = new Math<double>(31.4, 21.6);
        double result21 = math2.Addition();
        Console.WriteLine(result21);
        double result22 = math2.Subtraction();
        Console.WriteLine(result22);
        double result23 = math2.Multiplication();
        Console.WriteLine(result23);
        try
        {
            double result24 = math2.Division();
            Console.WriteLine(result24);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
