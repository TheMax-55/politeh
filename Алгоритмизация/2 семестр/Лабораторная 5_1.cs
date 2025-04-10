using System;

class Phone
{
    public string Number { get; set; }
    public string Operator { get; set; }
}
class Program
{
    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        Console.Write("Введите количество телефонов: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Phone phone = new Phone();
            Console.Write("Введите номер: ");
            phone.Number = Console.ReadLine();
            Console.Write("Введите оператора: ");
            phone.Operator = Console.ReadLine();
            phones.Add(phone);
        }
        Dictionary<string, int> operators = new Dictionary<string, int>();
        for (int i = 0; i < phones.Count; i++)
        {
            if (!operators.ContainsKey(phones[i].Operator))
            {
                operators.Add(phones[i].Operator, 1);
            }
            else
            {
                operators[phones[i].Operator]++;
            }
        }
        foreach(var x in operators.Keys)
        {
            Console.WriteLine($"Оператор: {x}, количество пользующихся: {operators[x]}");
        }

    }
}
