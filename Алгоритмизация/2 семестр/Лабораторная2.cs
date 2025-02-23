using System;
public interface IMath
{
    double CalcArea();
    double CalcPerimeter();
}
public class Figure
{
    public string Name { get; set; }
}
class Circle : Figure, IMath
{
    double Lenght { get; set; }
    public Circle(string name, double lenght)
    {
        Name = name;
        Lenght = lenght;
    }
    public double CalcArea()
    {
        return 3.14 * Lenght * Lenght;
    }
    public double CalcPerimeter()
    {
        return 2 * 3.14 * Lenght;
    }
}
class Square : Figure, IMath
{
    double Lenght { get; set; }
    public Square(string name, double lenght)
    {
        Name = name;
        Lenght = lenght;
    }
    public double CalcArea()
    {
        return Lenght * Lenght;
    }
    public double CalcPerimeter()
    {
        return 4 * Lenght;
    }
}
class Triangle : Figure, IMath
{
    double Lenght { get; set; }
    public Triangle(string name, double lenght)
    {
        Name = name;
        Lenght = lenght;
    }

    public double CalcArea()
    {
        return Lenght * Lenght * Math.Sqrt(3) / 4;
    }
    public double CalcPerimeter()
    {
        return 3 * Lenght;
    }
}
class Program
{
    static void Main()
    {
        Circle circle = new Circle("Окружность", 1);
        Square square = new Square("Квадрат", 3);
        Triangle triangle = new Triangle("Треугольник", 2);
        Console.WriteLine($"Площадь окружности: {circle.CalcArea()}");
        Console.WriteLine($"Периметр окружности: {circle.CalcPerimeter()}");
        Console.WriteLine($"Площадь квадрата: {square.CalcArea()}");
        Console.WriteLine($"Периметр квадрата: {square.CalcPerimeter()}");
        Console.WriteLine($"Площадь треугольника: {triangle.CalcArea()}");
        Console.WriteLine($"Периметр треугольника: {triangle.CalcPerimeter()}");
    }
}