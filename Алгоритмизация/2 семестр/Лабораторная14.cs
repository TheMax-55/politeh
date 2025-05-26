using System;
using System.Runtime.ConstrainedExecution;
class Item
{
    public int id { get; set; }
    public string name { get; set; }
    public Item(int id, string name)
    {
        this.id = id;
        this.name = name;
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
    public string date { get; set; }
    public Operation(int itemId, int? supplierId, string operation, int amount, int price, string date)
    {
        this.itemId = itemId;
        this.supplierId = supplierId;
        this.operation = operation;
        this.amount = amount;
        this.price = price;
        this.date = date;
    }
}
class Program
{
    static void Main()
    {
        List<Item> items = new List<Item>();
        List<Supplier> suppliers = new List<Supplier>();
        List<Operation> operations = new List<Operation>();
        for (int z = 0; ; z++)
        {
            Console.WriteLine("1. Добавить товар.\n" +
                "2. Добавить поставщика.\n" +
                "3. Добавить операцию.\n" +
                "4. Выдать остатки товаров.\n" +
                "5. Выдать поставки товаров, сгруппированных по поставщику.\n" +
                "6. Выдать продажи товаров, сгруппированных по дате.\n" +
                "7. Выдать выручку от продаж.\n" +
                "8. Выдать поставщика, поставившего максимальное количество товаров.");
            int n = int.Parse(Console.ReadLine());
            switch(n)
            {
                case 1:
                    {
                        Console.Write("Введите id товара: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Введите название товара: ");
                        string name = Console.ReadLine();
                        items.Add(new Item(id, name));
                    }
                    break;
                case 2:
                    {
                        Console.Write("Введите id поставщика: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Введите название поставщика: ");
                        string name = Console.ReadLine();
                        suppliers.Add(new Supplier(id, name));
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
                        string date = Console.ReadLine();
                        operations.Add(new Operation(itemId, supplierId, operation, amount, price, date));
                    }
                    break;
                case 4:
                    {
                        if (items.Count > 0 && suppliers.Count > 0 && operations.Count > 0) {
                            var remains = from item in items
                                          join op in operations
                                          on item.id equals op.itemId
                                          into itemOps
                                          select new
                                          {
                                              itemId = item.id,
                                              itemName = item.name,
                                              itemRemains = itemOps.Sum(op => op.operation == "Покупка" ? op.amount : -op.amount)
                                          };

                            foreach (var x in remains) Console.WriteLine($"Остатки товара {x.itemName} (id: {x.itemId}): {x.itemRemains}");
                        }
                        else Console.WriteLine("Сначала создайте БД.");
                    }
                        break;
                case 5: 
                    {
                        if (items.Count > 0 && suppliers.Count > 0 && operations.Count > 0)
                        {
                            var supGroup = from sup in suppliers
                                              join op in operations
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
                case 6: 
                    {
                        if (items.Count > 0 && suppliers.Count > 0 && operations.Count > 0)
                        {
                            var dateGroup = from op in operations
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
                case 7:
                    {
                        if (items.Count > 0 && suppliers.Count > 0 && operations.Count > 0)
                        {
                            var revenue = from item in items
                                          join op in operations
                                          on item.id equals op.itemId
                                          into itemOps
                                          select new
                                          {
                                              itemId = item.id,
                                              itemName = item.name,
                                              itemRevenue = itemOps.Sum(op => op.operation == "Продажа" ? (int)op.amount * (int)op.price : 0)
                                          };

                            foreach (var obj in revenue) Console.WriteLine($"Выручка от продаж от товара {obj.itemName} (ID: {obj.itemId}): {obj.itemRevenue}");
                        }
                        else Console.WriteLine("Сначала создайте БД.");
                    }
                    break;
                case 8: 
                    {
                        if (items.Count > 0 && suppliers.Count > 0 && operations.Count > 0)
                        {
                            var maxSup = (from sup in suppliers
                                           join op in operations
                                           on sup.id equals op.supplierId
                                           into supOps
                                           select new
                                           {
                                               supId = sup.id,
                                               supName = sup.name,
                                               supAmount = supOps.Sum(op => op.amount)
                                           }).OrderByDescending(s => s.supAmount).FirstOrDefault();
                            Console.WriteLine($"Поставщик, который поставил максимальное количество товаров: {maxSup.supName} (ID: {maxSup.supId}): {maxSup.supAmount}");
                        }
                        else Console.WriteLine("Сначала создайте БД.");
                    }
                    break;
            }
        }
    }
}
