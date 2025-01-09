using System;
using System.Globalization;
using System.Threading;
class Subject
{
    public string Name;
    public int Mark;
}
class Student
{
    public string Fio;
    public string[][] Subject;

    public Student(string name, string[][] subjects)
    {
        Fio = name;
        Subject = subjects;
    }
}
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        for (int i = 0; ; i++)
        {
            Console.WriteLine("1. Заполнить базу данных.");
            Console.WriteLine("2. Выборка по среднему баллу 4.5.");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.Write("Введите количество студентов, которых хотите добавить: ");
                int numstud = int.Parse(Console.ReadLine());
                for (int j = 0; j < numstud; j++)
                {   
                    Subject subject = new Subject();
                    Console.Write("Введите фио: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите количество предметов: ");
                    int num = int.Parse(Console.ReadLine());
                    string[][] subjects = new string[num][];
                    for (int k = 0; k < num; k++)
                    {
                        Console.Write("Введите название предмета: ");
                        subject.Name = Console.ReadLine();
                        Console.Write("Введите оценку: ");
                        subject.Mark = int.Parse(Console.ReadLine());
                        subjects[k] = [subject.Name, subject.Mark.ToString()];
                    }
                    students.Add(new Student(name, subjects));
                }
            }
            if (n == 2)
            {
                if (students.Count != 0)
                {
                    int count = 0;
                    foreach (var student in students)
                    {
                        double avgMark = 0;
                        for (int j = 0; j < student.Subject.Length; j++)
                        {
                            avgMark += int.Parse(student.Subject[j][1]);
                        }
                        avgMark /= student.Subject.Length;
                        if (avgMark >= 4.5)
                        {
                            Console.WriteLine(student.Fio);
                            count++;

                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Таких студентов нет.");
                    }
                }
                else
                {
                    Console.WriteLine("Сначала заполните базу данных.");
                }
            }
        }
    }
}