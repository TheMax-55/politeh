using System;
class Program
{
    static void Main()
    {
        StreamReader file = File.OpenText("input.txt");
        string input = null;
        StreamWriter output = new StreamWriter("output.txt");
        while ((input = file.ReadLine()) != null)
        {
            bool oddNumber = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    int start = i;
                    while (i < input.Length && char.IsDigit(input[i])) i++;
                    string numberStr = input.Substring(start, i - start);
                    int lastDigit = int.Parse(numberStr[numberStr.Length - 1].ToString());
                    if (lastDigit % 2 == 1)
                    {
                        oddNumber = true;
                        break;
                    }
                }
            }
            if (oddNumber) output.WriteLine(input);
        }
        output.Close();
    }
}
