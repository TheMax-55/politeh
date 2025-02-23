using System;

class User
{
    public string Name { get; set; }
    public string[][] PhoneInfo { get; set; }
    public string City { get; set; }

    public User(string name, string[][] info, string city)
    {
        Name = name;
        PhoneInfo = info;
        City = city;
    }
}

class Phone
{
    public string Number { get; set; }
    public string Operator { get; set; }
    public string Date { get; set; }
}

class Program
{
    static void Main()
    {
        List<User> users = new List<User>();
        for (int i = 0; ;i++)
        {
            int count = 0; 
            Console.WriteLine("1. Добавить пользователя.");
            Console.WriteLine("2. Выборка по номеру телефона.");
            Console.WriteLine("3. Выборка по телефонному оператору.");
            Console.WriteLine("4. Выборка по дате заключения договора.");
            Console.WriteLine("5. Выборка по городу.");
            Console.WriteLine("6. Выход.");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.Write("Введите ФИО: ");
                string name = Console.ReadLine();
                Console.Write("Введите количество номеров телефона: ");
                int num = int.Parse(Console.ReadLine());
                string[][] info = new string[num][];
                for (int j = 0; j < num; j++)
                {
                    Phone phone = new Phone();
                    Console.Write("Введите номер телефона: ");
                    phone.Number = Console.ReadLine();
                    Console.Write("Введите мобильного оператора: ");
                    phone.Operator = Console.ReadLine();
                    Console.Write("Введите год заключения договора: ");
                    phone.Date = Console.ReadLine();
                    info[j] = [phone.Number, phone.Operator, phone.Date];
                }
                Console.Write("Введите город проживания: ");
                string city = Console.ReadLine();
                users.Add(new User(name, info, city));
            }
            if (n == 2)
            {
                if (users.Count != 0)
                {
                    Console.Write("Введите номер телефона: ");
                    string currnumber = Console.ReadLine();
                    foreach (var user in users)
                    {
                        for (int j = 0; j < user.PhoneInfo.Length; j++)
                        {
                            if (user.PhoneInfo[j][0] == currnumber)
                            {
                                Console.WriteLine($"ФИО: {user.Name}");
                                Console.WriteLine($"Номер телефона: {user.PhoneInfo[j][0]}");
                                Console.WriteLine($"Мобильный оператор: {user.PhoneInfo[j][1]}");
                                Console.WriteLine($"Год заключения договора: {user.PhoneInfo[j][2]}");
                                Console.WriteLine($"Город проживания: {user.City}");
                                count++;
                            }
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Таких пользователей нет.");
                    }
                }
                else
                {
                    Console.WriteLine("Сначала добавьте пользователей в базу данных.");
                }
            }
            if (n == 3)
            {
                if (users.Count != 0)
                {
                    Console.Write("Введите мобильного оператора: ");
                    string curroperator = Console.ReadLine();
                    foreach (var user in users)
                    {
                        for (int j = 0; j < user.PhoneInfo.Length; j++)
                        {
                            if (user.PhoneInfo[j][1] == curroperator)
                            {
                                Console.WriteLine($"ФИО: {user.Name}");
                                Console.WriteLine($"Номер телефона: {user.PhoneInfo[j][0]}");
                                Console.WriteLine($"Мобильный оператор: {user.PhoneInfo[j][1]}");
                                Console.WriteLine($"Год заключения договора: {user.PhoneInfo[j][2]}");
                                Console.WriteLine($"Город проживания: {user.City}");
                                count++;
                            }
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Таких пользователей нет.");
                    }
                }
                else
                {
                    Console.WriteLine("Сначала добавьте пользователей в базу данных.");
                }
            }
            if (n == 4)
            {
                if (users.Count != 0)
                {
                    Console.Write("Введите год заключения договора: ");
                    string currdate = Console.ReadLine();
                    foreach (var user in users)
                    {
                        for (int j = 0; j < user.PhoneInfo.Length; j++)
                        {
                            if (user.PhoneInfo[j][2] == currdate)
                            {
                                Console.WriteLine($"ФИО: {user.Name}");
                                Console.WriteLine($"Номер телефона: {user.PhoneInfo[j][0]}");
                                Console.WriteLine($"Мобильный оператор: {user.PhoneInfo[j][1]}");
                                Console.WriteLine($"Год заключения договора: {user.PhoneInfo[j][2]}");
                                Console.WriteLine($"Город проживания: {user.City}");
                                count++;
                            }
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Таких пользователей нет.");
                    }
                }
                else
                {
                    Console.WriteLine("Сначала добавьте пользователей в базу данных.");
                }
            }
            if (n == 5)
            {
                if (users.Count != 0)
                {
                    Console.Write("Введите город проживания: ");
                    string currcity = Console.ReadLine();
                    foreach (var user in users)
                    {
                        if (user.City == currcity)
                        {
                            Console.WriteLine($"ФИО: {user.Name}");
                            for (int j = 0; j < user.PhoneInfo.Length; j++)
                            {
                                Console.WriteLine($"Номер телефона: {user.PhoneInfo[j][0]}");
                                Console.WriteLine($"Мобильный оператор: {user.PhoneInfo[j][1]}");
                                Console.WriteLine($"Год заключения договора: {user.PhoneInfo[j][2]}");
                            }
                            Console.WriteLine($"Город проживания: {user.City}");
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Таких пользователей нет.");
                    }
                }
                else
                {
                    Console.WriteLine("Сначала добавьте пользователей в базу данных.");
                }
            }
            if (n == 6)
            {
                break;
            }

        }
    }
}