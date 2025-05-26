using System;
class Item
{
    public int id { get; set; }
    public string name { get; set; }
    public DateTime date { get; set; }
    public Item(int id, string name, DateTime date)
    {
        this.id = id;
        this.name = name;
        this.date = date;
    }
}
class Supplier
{
    public int id { get; set; }
    public string name { get; set; }
    public Supplier(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
class Operation
{
    public int itemId { get; set; }
    public int? supplierId { get; set; }
    public string operation { get; set; }
    public int amount { get; set; }
    public int price { get; set; }
    public DateTime date { get; set; }
    public Operation(int itemId, int? supplierId, string operation, int amount, int price, DateTime date)
    {
        this.itemId = itemId;
        this.supplierId = supplierId;
        this.operation = operation;
        this.amount = amount;
        this.price = price;
        this.date = date;
    }
}
class Shop
{
    public List<Item> items { get; } = new List<Item>();
    public List<Supplier> suppliers { get; } = new List<Supplier>();
    public List<Operation> operations { get; } = new List<Operation>();

    public void AddItem(Item item) => items.Add(item);
    public void AddSupplier(Supplier supplier) => suppliers.Add(supplier);
    public void AddOperation(Operation operation) => operations.Add(operation);
}
class Program
{
    static Shop shop = new Shop();
    static void Main()
    {
        for (int z = 0; ; z++)
        {
            Console.WriteLine("1. Добавить товар.\n" +
                "2. Добавить поставщика.\n" +
                "3. Добавить операцию.\n" +
                "4. Выдать выручку за определенный интервал времени.\n" +
                "5. Выдать остатки товаров.\n" +
                "6. Списание товаров, отсортированных по товарам.\n" +
                "7. Выдать поставки, отсортированные по поставщику.\n" +
                "8. Выдать продажи товаров, отсортированные по дате продажи.");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    {
                        Console.Write("Введите id товара: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Введите название товара: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите день, когда товар станет просроченным: ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        shop.AddItem(new Item(id, name, date));
                    }
                    break;
                case 2:
                    {
                        Console.Write("Введите id поставщика: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Введите название поставщика: ");
                        string name = Console.ReadLine();
                        shop.AddSupplier(new Supplier(id, name));
                    }
                    break;
                case 3:
                    {
                        Console.Write("Введите id товара: ");
                        int itemId = int.Parse(Console.ReadLine());
                        Console.Write("Введите операцию (Покупка/Продажа): ");
                        string operation = Console.ReadLine();
                        int? supplierId = null;
                        if (operation == "Покупка")
                        {
                            Console.Write("Введите id поставщика: ");
                            supplierId = int.Parse(Console.ReadLine());
                        }
                        Console.Write("Введите количество товаров: ");
                        int amount = int.Parse(Console.ReadLine());
                        Console.Write("Введите цену товара: ");
                        int price = int.Parse(Console.ReadLine());
                        Console.Write("Введите дату операции: ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        shop.AddOperation(new Operation(itemId, supplierId, operation, amount, price, date));
                    }
                    break;
                case 4:
                    {
                        if (shop.items.Count > 0 && shop.suppliers.Count > 0 && shop.operations.Count > 0)
                        {
                            Console.WriteLine("Введите интервал времени: ");
                            Console.Write("От: ");
                            DateTime start = DateTime.Parse(Console.ReadLine());
                            Console.Write("До: ");
                            DateTime end = DateTime.Parse(Console.ReadLine());
                            var interval = from item in shop.items
                                           join op in shop.operations
                                           on item.id equals op.itemId
                                           into itemOps
                                           select new
                                           {
                                               itemId = item.id,
                                               itemName = item.name,
                                               itemRevenue = itemOps.Sum(op => op.operation == "Продажа" && op.date >= start && op.date <= end ? op.amount * op.price : 0)
                                           };
                            foreach (var obj in interval)
                            {
                                Console.WriteLine($"Товар {obj.itemName} (ID: {obj.itemId}) выручка: {obj.itemRevenue}");
                            }
                        }
                        else Console.WriteLine("Сначала создайте БД.");
                    }
                    break;
                case 5:
                    {
                        if (shop.items.Count > 0 && shop.suppliers.Count > 0 && shop.operations.Count > 0)
                        {
                            var remains = from item in shop.items
                                          join op in shop.operations
                                          on item.id equals op.itemId
                                          into itemOps
                                          select new
                                          {
                                              itemId = item.id,
                                              itemName = item.name,
                                              itemRemains = itemOps.Sum(op => op.operation == "Покупка" ? op.amount : -op.amount)
                                          };

                            foreach (var obj in remains) Console.WriteLine($"Остатки товара {obj.itemName} (ID: {obj.itemId}): {obj.itemRemains}");
                        }
                        else Console.WriteLine("Сначала создайте БД.");
                    }
                    break;
                case 6: 
                    {
                        if (shop.items.Count > 0 && shop.suppliers.Count > 0 && shop.operations.Count > 0)
                        {
                            Console.Write("Введите дату для проверки годности товаров: ");
                            DateTime currDate = DateTime.Parse(Console.ReadLine());
                            var offsGroup = from item in shop.items
                                            join op in shop.operations
                                            on item.id equals op.itemId
                                            into itemOps
                                            where currDate > item.date
                                            select new
                                            {
                                                itemId = item.id,
                                                itemName = item.name,
                                                amount = itemOps.Sum(op => op.operation == "Покупка" ? op.amount : -op.amount)
                                            };
                            foreach (var item in offsGroup)
                            {
                                Console.WriteLine($"Товар {item.itemName} (ID: {item.itemId}) Количество просроченных товаров: {item.amount}");
                                Console.WriteLine();
                            }
                        }
                        else Console.WriteLine("Сначала создайте БД.");
                    }
                    break;
                case 7:
                    {
                        if (shop.items.Count > 0 && shop.suppliers.Count > 0 && shop.operations.Count > 0)
                        {
                            var supGroup = from sup in shop.suppliers
                                           join op in shop.operations
                                           on sup.id equals op.supplierId
                                           into supOps
                                           select new
                                           {
                                               supId = sup.id,
                                               supName = sup.name,
                                               opBuy = supOps.GroupBy(op => op.supplierId)
                                           };

                            foreach (var sup in supGroup)
                            {
                                foreach (var opers in sup.opBuy)
                                    foreach (Operation oper in opers) Console.WriteLine($"ID товара: {oper.itemId} Количество: {oper.amount} Цена: {oper.price} Дата: {oper.date}");
                                Console.WriteLine();
                            }
                        }
                        else Console.WriteLine("Сначала создайте БД.");
                    }
                    break;
                case 8:
                    {
                        if (shop.items.Count > 0 && shop.suppliers.Count > 0 && shop.operations.Count > 0)
                        {
                            var dateGroup = from op in shop.operations
                                            where op.operation == "Продажа"
                                            group op by op.date;

                            foreach (var opers in dateGroup)
                            {
                                foreach (Operation oper in opers) Console.WriteLine($"ID товара: {oper.itemId} ID поставщика: {oper.supplierId} Количество: {oper.amount} Цена: {oper.price} Дата: {oper.date}");
                                Console.WriteLine();
                            }
                        }
                        else Console.WriteLine("Сначала создайте БД.");
                    }
                    break;
            }
        }
    }
}
