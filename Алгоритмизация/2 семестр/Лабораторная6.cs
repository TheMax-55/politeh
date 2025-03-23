using System;
public class Car
{
    public string Brand { get; set; }
    public string Owner { get; set; }
    public string Year { get; set; }
    public bool Washed { get; set; }
}
public class Garage
{
    public List<Car> Cars { get; set; } = new List<Car>();
}
public class Washing
{
    public static bool WashCar(bool wash)
    {
        return true;
    }
}

class Program
{
    delegate bool WashCar(bool washed);
    static void Main()
    {
        Garage garage = new Garage();
        Console.Write("Введите количество машин в гараже: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Car car = new Car();
            Console.Write("Введите марку машины: ");
            car.Brand = Console.ReadLine();
            Console.Write("Введите фио владельца машины: ");
            car.Owner = Console.ReadLine();
            Console.Write("Введите год выпуска машины: ");
            car.Year = Console.ReadLine();
            Console.Write("Если машина помыта, введите 1, иначе введите 2: ");
            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                car.Washed = true;
            }
            else
            {
                car.Washed = false;
            }
            garage.Cars.Add(car);
        }
        WashCar wash = Washing.WashCar;
        foreach (var car in garage.Cars)
        {
            Console.WriteLine($"Марка: {car.Brand}\n" +
                $"Владелец: {car.Owner}\n" +
                $"Год выпуска: {car.Year}\n" +
                $"{(car.Washed ? "Машина помыта." : "Машина не помыта.")}");
            if (!car.Washed)
            {
               car.Washed = wash(car.Washed);
               Console.WriteLine($"{(car.Washed ? "Теперь машина помыта." : "Ошибка.")}");
            }
        }
    }
}