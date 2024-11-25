using System;
class Program
{
    static int[] FillNum(int len)
    {
        int[] nums = new int[len];
        for (int z = 0; len > z; z++)
        {
            nums[z] = Convert.ToInt32(Console.ReadLine());
        }
        return nums;
    }
    static void Main()
    {
        Console.Write("Введите количество подмассивов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] nums = new int[n][];
        for (int i = 0; n > i; i++)
        {
            Console.Write("Введите длину массива: ");
            int len = Convert.ToInt32(Console.ReadLine());
            nums[i] = FillNum(len);
            int maxi = nums[i][0], mini = nums[i][0];
            for (int j = 0; j < nums[i].Length; j++)
            {
                if (nums[i][j] > maxi)
                {
                    maxi = nums[i][j];
                }
                if (nums[i][j] < mini)
                {
                    mini = nums[i][j];
                }
            }
            Console.WriteLine($"Максимальный элемент: {maxi}, минимальный элемент: {mini}");
        }
    }
}
