using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab13
{
    public static class ArrayMethods
    {
        public static void ShellSort(int[] arr)
        {
            int size = arr.Length;
            int step = SedgwicksFormula(size);

            while (step > 0)
            {
                for (int i = 0; i < size - step; i++)
                {
                    int j = i;
                    while (j >= 0 && arr[j] < arr[j + step])
                    {
                        (arr[j], arr[j + step]) = (arr[j + step], arr[j]);
                        j--;
                    }
                }
                step /= 2;
            }
        }

        public static void OddEvenSort(int[] arr)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;

                for (int i = 1; i < arr.Length - 1; i += 2)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        sorted = false;
                    }
                }

                for (int i = 0; i < arr.Length - 1; i += 2)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        sorted = false;
                    }
                }
            }
        }

        public static void ParallelOddEvenSort(int[] array, int maxThreads)
        {
            bool sorted = false;
            int n = array.Length;
            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = maxThreads };

            Stopwatch sw = Stopwatch.StartNew();

            while (!sorted)
            {
                sorted = true;

                Parallel.For(1, (n - 1) / 2 + 1, options, i =>
                {
                    int index = 2 * i - 1;
                    if (index < n - 1 && array[index] > array[index + 1])
                    {
                        Swap(array, index, index + 1);
                        sorted = false;
                    }
                });

                Parallel.For(0, n / 2, options, i =>
                {
                    int index = 2 * i;
                    if (index < n - 1 && array[index] > array[index + 1])
                    {
                        Swap(array, index, index + 1);
                        sorted = false;
                    }
                });
            }
            sw.Stop();

            Console.WriteLine($"\nTime: {sw.Elapsed.TotalMilliseconds} ms");
        }

        private static int SedgwicksFormula(int size)
        {
            int step1 = 9 * (int)Math.Pow(2, size) - 9 * (int)Math.Pow(2, size / 2) + 1;
            int step2 = 8 * (int)Math.Pow(2, size) - 6 * (int)Math.Pow(2, (size + 1) / 2) + 1;
            return (size % 2 == 0) ? step1 : step2;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
