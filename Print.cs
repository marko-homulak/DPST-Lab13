using System;

namespace Lab13
{
    public static class Print
    {
        public static void SetColor(ConsoleColor bg, ConsoleColor text)
        {
            Console.BackgroundColor = bg;
            Console.ForegroundColor = text;
        }

        public static void Matrix(int[,] matrix, int size, int[] diagonal, bool sorted = false)
        {
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        SetColor(ConsoleColor.Black, ConsoleColor.Red);
                        Console.Write($" {diagonal[i],5} ");
                        SetColor(ConsoleColor.Black, ConsoleColor.Gray);
                    }
                    else
                    {
                        Console.Write(matrix[i, j] < 0 ? $" {matrix[i, j],5} " : $"  {matrix[i, j],4} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
