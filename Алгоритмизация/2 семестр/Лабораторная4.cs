using System;
class Program
{
    static bool digitCheck(string number)
    {
        int count = 0;
        bool flag = false;
        foreach (char x in number)
        {
            if (Char.IsDigit(x))
            {
                count++;
            }
        }
        if (count == number.Length)
        {
            flag = true;
        }
        return flag;
    }
    static void Main()
    {
        Stack<string> st = new Stack<string>();
        Console.Write("Введите выражение: ");
        string[] arr = Console.ReadLine().Split(" ");
        foreach (string sym in arr)
        {

            if (digitCheck(sym))
            {
                st.Push(sym);
            }
            else if (sym == "+" && st.Count >= 2)
            {
                int num1 = int.Parse(st.Pop());
                int num2 = int.Parse(st.Pop());
                st.Push((num1 + num2).ToString());
            }
            else if (sym == "-" && st.Count >= 2)
            {
                int num1 = int.Parse(st.Pop());
                int num2 = int.Parse(st.Pop());
                st.Push((num2 - num1).ToString());
            }
            else if (sym == "*" && st.Count >= 2)
            {
                int num1 = int.Parse(st.Pop());
                int num2 = int.Parse(st.Pop());
                st.Push((num1 * num2).ToString());

            }
            else if (sym == "/" && st.Count >= 2)
            {
                int num1 = int.Parse(st.Pop());
                int num2 = int.Parse(st.Pop());
                if (num1 != 0)
                {
                    st.Push((num2 / num1).ToString());
                }
            }
            else
            {
                st.Clear();
                break;
            }

        }
        if (st.Count == 1)
        {
            string answer = st.Pop();
            Console.WriteLine(answer);
        }
        else
        {
            Console.WriteLine("Ошибка.");
        }
    }
}
