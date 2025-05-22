using System;
using System.Globalization;
class Phone
{
    public string name { get; set; }
    public string number { get; set; }
    public int year { get; set; }
    public string phoneOperator { get; set; } 
    public Phone(string name, string number, int year, string phoneOperator)
    {
        this.name = name;
        this.number = number;
        this.year = year;
        this.phoneOperator = phoneOperator;
    }
}
class Program
{
    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        for (int z = 0; ; z++)
        {
            Console.WriteLine("1. Добавить телефон.\n" +
                "2. Выдать телефоны по оператору.\n" +
                "3. Выдать телефоны за определенный год.\n" +
                "4. Выдать данные, сгруппированные по оператору.\n" +
                "5. Выдать данные, сгруппированные по году.");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    {
                        Console.Write("Введмте имя владельца: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите номер: ");
                        string number = Console.ReadLine();
                        Console.Write("Введите год: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Введите оператора: ");
                        string phoneOperator = Console.ReadLine();
                        phones.Add(new Phone(name, number, year, phoneOperator));
                    }
                    break;
                case 2: 
                    {
                        if (phones.Count > 0)
                        {
                            Console.Write("Введите оператора: ");
                            string phoneOperator = Console.ReadLine();
                            var phoneInfo = from phone in phones
                                            where phone.phoneOperator == phoneOperator
                                            select phone;
                            if (phoneInfo.Any()) foreach (Phone phone in phoneInfo) Console.WriteLine($"Владелец: {phone.name} Номер: {phone.number} Год: {phone.year} Оператор: {phone.phoneOperator}");
                            else Console.WriteLine("Таких телефонов нет.");
                        }
                        else Console.WriteLine("Сначала добавьте телефоны в базу данных.");
                    }
                    break;
                case 3: 
                    {
                        if (phones.Count > 0)
                        {
                            Console.Write("Введите год: ");
                            int year = int.Parse(Console.ReadLine());
                            var phoneInfo = from phone in phones
                                            where phone.year == year
                                            select phone;
                            if (phoneInfo.Any()) foreach (Phone phone in phoneInfo) Console.WriteLine($"Владелец: {phone.name} Номер: {phone.number} Год: {phone.year} Оператор: {phone.phoneOperator}");
                            else Console.WriteLine("Таких телефонов нет.");
                        }
                        else Console.WriteLine("Сначала добавьте телефоны в базу данных.");
                    }
                    break;
                case 4:
                    {
                        if (phones.Count > 0)
                        {
                            var phoneInfo = from phone in phones
                                            orderby phone.phoneOperator
                                            select phone;
                            string phoneOperator = "";
                            foreach (Phone phone in phoneInfo)
                            {
                                if (phoneOperator != phone.phoneOperator)
                                {
                                    Console.WriteLine();
                                    phoneOperator = phone.phoneOperator;
                                }
                                Console.WriteLine($"Владелец: {phone.name} Номер: {phone.number} Год: {phone.year} Оператор: {phone.phoneOperator}");
                            }
                        }
                        else Console.WriteLine("Сначала добавьте телефоны в базу данных.");
                    }
                    break;
                case 5: 
                    {
                        if (phones.Count > 0)
                        {
                            var phoneInfo = from phone in phones
                                            orderby phone.year
                                            select phone;
                            int year = 0;
                            foreach (Phone phone in phoneInfo)
                            {
                                if (year != phone.year)
                                {
                                    Console.WriteLine();
                                    year = phone.year;
                                }
                                Console.WriteLine($"Владелец: {phone.name} Номер: {phone.number} Год: {phone.year} Оператор: {phone.phoneOperator}");
                            }
                        }
                        else Console.WriteLine("Сначала добавьте телефоны в базу данных.");
                    } 
                    break;
            }
        }
    }
}
