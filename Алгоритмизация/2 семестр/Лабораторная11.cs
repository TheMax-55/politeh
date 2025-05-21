using Microsoft.VisualBasic.FileIO;
using System;
struct Book
{
    public string author;
    public string title;
    public string year;
    public string publisher;
    public Book(string author, string title, string year, string publisher)
    {
        this.author = author;
        this.title = title;
        this.year = year;
        this.publisher = publisher;
    }
}

struct BookInfo
{
    public string issueDate;
    public string deliveryDate;
    public BookInfo(string issueDate, string deliveryDate)
    {
        this.issueDate = issueDate;
        this.deliveryDate = deliveryDate;
    }
}

class Library
{
    public Book book {  get; set; }
    public BookInfo bookInfo { get; set; }
    public Library(Book book, BookInfo bookInfo)
    {
        this.book = book;
        this.bookInfo = bookInfo;
    }
}

class Program
{
    static void Main()
    {
        List<Library> library = new List<Library>();
        for (int z = 0; ; z++)
        {
            int count = 0; 
            Console.WriteLine("1. Добавить книгу.\n" +
                "2. Книги, которые не выдавались.\n" +
                "3. Книги, которые не сданы.");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    {
                        Console.Write("Введите автора: ");
                        string author = Console.ReadLine();
                        Console.Write("Введите название: ");
                        string title = Console.ReadLine();
                        Console.Write("Введите год выпуска: ");
                        string year = Console.ReadLine();
                        Console.Write("Введите издательство: ");
                        string publisher = Console.ReadLine();
                        Console.Write("Введите дату выдачи (введите -, если книга не выдавалась): ");
                        string issue = Console.ReadLine();
                        Console.Write("Введите дату сдачи (введите -, если книга не сдавалась): ");
                        string delivery = Console.ReadLine();
                        Book book = new Book(author, title, year, publisher);
                        BookInfo bookInfo = new BookInfo(issue, delivery);
                        library.Add(new Library(book, bookInfo));
                    }
                    break;
                case 2:
                    {
                        if (library.Count > 0)
                        {
                            for (int i = 0; i < library.Count; i++)
                            {
                                if(library[i].bookInfo.issueDate == "-")
                                {
                                    Console.WriteLine($"Автор: {library[i].book.author}\n" +
                                        $"Название: {library[i].book.title}\n" +
                                        $"Год выпуска: {library[i].book.year}\n" +
                                        $"Издательство: {library[i].book.publisher}\n");
                                    count++;
                                }
                            }
                            if (count == 0)
                            {
                                Console.WriteLine("Таких книг нет.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала добавьте книги в базу данных.");
                        }
                    }
                    break;
                case 3:
                    {
                        if (library.Count > 0)
                        {
                            for (int i = 0; i < library.Count; i++)
                            {
                                if (library[i].bookInfo.deliveryDate == "-" && library[i].bookInfo.issueDate != "-")
                                {
                                    Console.WriteLine($"Автор: {library[i].book.author}\n" +
                                        $"Название: {library[i].book.title}\n" +
                                        $"Год выпуска: {library[i].book.year}\n" +
                                        $"Издательство: {library[i].book.publisher}\n");
                                    count++;
                                }
                            }
                            if (count == 0)
                            {
                                Console.WriteLine("Таких книг нет.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала добавьте книги в базу данных.");
                        }
                    }
                    break;
            }
        }
    }
}
