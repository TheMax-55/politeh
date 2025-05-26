using System;
class Program
{
    static void Little(double[,] originalMatrix)
    {
        int n = originalMatrix.GetLength(0);
        double inf = double.PositiveInfinity;
        double[,] matrix = (double[,])originalMatrix.Clone();
        double totalCost = 0;
        while (n > 1)
        {
            totalCost += ReduceRows(matrix, n, inf);
            totalCost += ReduceColumns(matrix, n, inf);
            var (maxI, maxJ) = EvaluateZeros(matrix, n, inf);
            matrix[maxJ, maxI] = inf;
            n--;
            matrix = ReduceMatrix(matrix, maxI, maxJ, n, inf);
        }
        Console.WriteLine(totalCost);
    }
    static double ReduceRows(double[,] matrix, int n, double inf)
    {
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            double min = inf;
            for (int j = 0; j < n; j++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];
            if (min != inf && min != 0)
            {
                sum += min;
                for (int j = 0; j < n; j++)
                    if (matrix[i, j] != inf)
                        matrix[i, j] -= min;
            }
        }
        return sum;
    }

    static double ReduceColumns(double[,] matrix, int n, double inf)
    {
        double sum = 0;
        for (int j = 0; j < n; j++)
        {
            double min = inf;
            for (int i = 0; i < n; i++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];

            if (min != inf && min != 0)
            {
                sum += min;
                for (int i = 0; i < n; i++)
                    if (matrix[i, j] != inf)
                        matrix[i, j] -= min;
            }
        }
        return sum;
    }
    static (int, int) EvaluateZeros(double[,] matrix, int n, double inf)
    {
        double maxScore = double.NegativeInfinity;
        int maxI = -1, maxJ = -1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == 0)
                {
                    double rowMin = inf;
                    double colMin = inf;

                    for (int k = 0; k < n; k++)
                    {
                        if (k != j && matrix[i, k] < rowMin) rowMin = matrix[i, k];
                        if (k != i && matrix[k, j] < colMin) colMin = matrix[k, j];
                    }

                    double score = (rowMin == inf ? 0 : rowMin) + (colMin == inf ? 0 : colMin);
                    if (score > maxScore)
                    {
                        maxScore = score;
                        maxI = i;
                        maxJ = j;
                    }
                }
            }
        }
        return (maxI, maxJ);
    }

    static double[,] ReduceMatrix(double[,] oldMatrix, int row, int col, int newSize, double inf)
    {
        double[,] newMatrix = new double[newSize, newSize];
        int newRow = 0, newCol;

        for (int i = 0; i < oldMatrix.GetLength(0); i++)
        {
            if (i == row) continue;
            newCol = 0;
            for (int j = 0; j < oldMatrix.GetLength(1); j++)
            {
                if (j == col) continue;
                newMatrix[newRow, newCol] = oldMatrix[i, j];
                newCol++;
            }
            newRow++;
        }
        return newMatrix;
    }
    static void Main()
    {
        double i = double.PositiveInfinity;
        double[,] test1 =
        {
            { i,17,16,21,22,17 },
            { 13,i,21,15,22,27 },
            { 25,3,i,31,12,9 },
            { 13,40,29,i,32,12 },
            { 9,2,19,14,i,11 },
            { 42,17,5,9,23,i }
        };
        double[,] test2 =
        {
            { i,12,22,28,32 },
            { 12,i,10,40,20 },
            { 22,10,i,50,10 },
            { 28,27,17,i,27 },
            { 32,20,10,60,i }
        };
        double[,] test3 =
        {
            { i,11,12,12,10 },
            { 7,i,6,6,10 },
            { 2,6,i,2,11 },
            { 2,2,9,i,12 },
            { 2,2,3,8,i }
        };
        double[,] test4 =
        {
            { i,6,4,8,7,14 },
            { 6,i,7,11,7,10 },
            { 4,7,i,4,3,10,},
            { 8,11,4,i,5,11 },
            { 7,7,3,5,i,7 },
            { 14,10,10,11,7,i },
        };
        Little(test1);
        Little(test2);
        Little(test3);
        Little(test4);
    }
}
