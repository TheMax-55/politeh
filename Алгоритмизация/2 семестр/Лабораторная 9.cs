using Microsoft.VisualBasic.FileIO;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
class Array<T>
{
    public T[] array = new T[10];
    int count = 0;
    public T[] AddEl(T element)
    {
        if (count != array.Length)
        {
            array[count] = element;
            count++;
        }
        else
        {
            throw new Exception("В массиве нет места.");
        }
        return array;
    }
    public T[] DeleteEl(int index)
    {
        CheckIndex(index);
        array[index] = default;
        return array;
    }
    public void FindEl(int index)
    {
        CheckIndex(index);
        Console.WriteLine($"Элемент с индексом {index}: {array[index]}");
    }
    void CheckIndex(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Указан неверный индекс.");
        }
    }
}
class Program
{
    static void Main()
    {
        Array<int> arr = new Array<int>();
        try
        {
           for (int i = 0; i <= 10; i++)
           {
                arr.AddEl(i);
           }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Получившийся массив:");
            for (int i = 0; i < arr.array.Length; i++)
            {
                Console.WriteLine(arr.array[i]);
            }
        }
        try 
        {
            arr.DeleteEl(3);
            arr.DeleteEl(6);
            arr.DeleteEl(30);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Получившийся массив:");
            for (int i = 0; i < arr.array.Length; i++)
            {
                Console.WriteLine(arr.array[i]);
            }
        }
        try
        {
            arr.FindEl(2);
            arr.FindEl(9);
            arr.FindEl(11);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
