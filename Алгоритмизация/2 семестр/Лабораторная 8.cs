using System;
class Сontestant
{
    public string name { get; set; }
    public int position { get; set; }
    public Сontestant(string name, int position)
    {
        this.name = name;
        this.position = position;
    }
}

delegate void CompetitionHandler(string contestant);

class CompetitionEvent
{
    public event CompetitionHandler Notify;

    public void WinnerCheck(string contestant)
    {
        if (Notify != null)
        {
            Notify(contestant);
        }
    }
}

class Program
{
    static void Handler(string contestant)
    {
        Console.WriteLine($"Участник {contestant} победил.");
    }

    static void Main()
    {

        List<Сontestant> contestants = new List<Сontestant>();
        contestants.Add(new Сontestant("Петр", 0));
        contestants.Add(new Сontestant("Иван", 0));
        contestants.Add(new Сontestant("Роман", 0));
        contestants.Add(new Сontestant("Юрий", 0));
        int finish = 100;
        int count = 0;

        CompetitionEvent evt = new CompetitionEvent();
        evt.Notify += Handler;

        while (1 > 0)
        {
            for (int i = 0; i < contestants.Count; i++)
            {

                Random rndspeed = new Random();
                int speed = rndspeed.Next(1, 7);

                contestants[i].position += speed;

                if (contestants[i].position >= finish)
                {
                    evt.WinnerCheck(contestants[i].name);
                    count++;
                }
            }
            if (count > 0) break;
        }
    }
}
