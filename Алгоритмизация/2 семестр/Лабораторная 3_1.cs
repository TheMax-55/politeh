using System;
using System.Diagnostics.SymbolStore;
class Program
{
    static void Main()
    {
        Console.Write("Введите последовательность: ");
        string s = Console.ReadLine();
        bool flag = true;
        char sym2;
        Stack<char> st = new Stack<char>();
        foreach (char sym in s)
        {
            
                if (sym == ')' || sym == ']' || sym == '}')
                {
                    try
                    {
                        sym2 = st.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Ошибка.");
                        flag = false;
                        break;
                    }
                    if (!((sym == ')' && sym2 =='(') || (sym == ']' && sym2 == '[') || (sym == '}' && sym2 == '{')))
                        {
                            Console.WriteLine("Ошибка.");
                            flag = false;
                            break;
                        }
                    }
                else if (sym == '(' || sym == '[' || sym == '{')
                {
                    st.Push(sym);
                }
            
        }
        if (flag)
        {
            Console.WriteLine("Скобки расставлены верно.");
        }
    }
}