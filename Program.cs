using System;

namespace Lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numThreads = 4;

            int[] myDiagonal = { 45, 57, 69, 54, 25, 10, 5, 1, -14, 25, 96, 81, 6, 18, 3, 25 };

            int min = -99, max = 99;
            Console.Write("Please enter size of the square matrix => ");
            Print.SetColor(ConsoleColor.Black, ConsoleColor.Yellow);
            int size = int.Parse(Console.ReadLine());
            while (size > myDiagonal.Length)
            {
                Console.Clear();
                Print.SetColor(ConsoleColor.Black, ConsoleColor.Red);
                Console.WriteLine($"Error! Arrray size must be less then {myDiagonal.Length}.");
                Print.SetColor(ConsoleColor.Black, ConsoleColor.White);
                Console.Write("Please enter size of the square matrix => ");
                Print.SetColor(ConsoleColor.Black, ConsoleColor.Yellow);
                size = int.Parse(Console.ReadLine());
            }
            Print.SetColor(ConsoleColor.Black, ConsoleColor.Gray);
            Console.WriteLine();

            int[,] matrix = new int[size, size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = myDiagonal[i];
                    }
                    else
                    {
                        matrix[i, j] = rand.Next(min, max + 1);
                    }
                }
            }

            int[] diagonal = new int[size];
            for (int i = 0; i < size; i++)
            {
                diagonal[i] = matrix[i, i];
            }

            Print.Matrix(matrix, size, diagonal);
            ArrayMethods.ParallelOddEvenSort(diagonal, numThreads);
            Print.Matrix(matrix, size, diagonal, true);

            Console.ReadKey();
        }
    }
}
