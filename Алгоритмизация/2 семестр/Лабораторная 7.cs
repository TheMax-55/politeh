using System;
class Coordinates
{
    public int x { get; set; }
    public int y { get; set; }
    public Coordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
delegate void OutOfRangeHandler();
class OutOfRangeEvent
{
    public event OutOfRangeHandler Notify;
    public void OutOfRangeCheck()
    {
        if (Notify != null)
        {
            Notify();
        }
    }
}

class Program
{
    static void Handler()
    {
        Console.WriteLine("Точка вышла за пределы поля.");
    }
    static void Main()
    {
        Random coords = new Random();

        Coordinates leftAngle = new Coordinates(0, 100);
        Coordinates rightAngle = new Coordinates(100, 0);
        Coordinates point = new Coordinates(50, 50);
        
        OutOfRangeEvent evt = new OutOfRangeEvent();
        evt.Notify += Handler;

        while (1 > 0) 
        { 
            point.x += coords.Next(-50,50);
            point.y += coords.Next(-50,50);
            if (leftAngle.x > point.x || rightAngle.x < point.x || leftAngle.y < point.y || rightAngle.y > point.y)
            {
                evt.OutOfRangeCheck();
                break;
            }
        }
    }
}
