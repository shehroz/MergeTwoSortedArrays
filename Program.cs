using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr1 = { 1, 2, 3, 4 };
            int[] arr2 = { 5, 6, 7, 8 };
            int[] result = MergeTwoArray(arr1, arr2);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.ReadKey();

        }

        public static int[] MergeTwoArray(int[] arr1, int[] arr2)
        {
            int len = arr1.Length + arr2.Length;
            int index1 = 0, index2 = 0;
            int[] result = new int[len];
            for (int i = 0; i < result.Length; i++)
            {
                if (index1 == arr1.Length)
                    result[i] = arr2[index2++];
                else if (index2 == arr2.Length)
                    result[i] = arr1[index1++];
                else if (arr1[index1] < arr2[index2])
                    result[i] = arr1[index1++];
                else if (arr2[index2] < arr1[index1])
                    result[i] = arr2[index2++];
            }
            return result;
        }
        public static int[] MergeTwoArraysOpt(int[] arr1, int[] arr2)
        {
            int len1 = arr1.Length;
            int len2 = arr2.Length;
            int index1 = 0, index2 = 0;
            Array.Resize<int>(ref arr1, arr1.Length + arr2.Length);

            for (int i = 0; i < arr2.Length; i++)
            {
                if (index1 == len1)
                    arr1[i] = arr2[index2++];
                else if (index2 == len2)
                    arr1[i] = arr1[index1++];
                else if (arr1[index1] < arr2[index2])
                    arr1[i] = arr1[index1++];
                else if (arr2[index2] < arr1[index1])
                {
                    for (int j = len1 + i; j > i; j--)
                    {
                        arr1[j] = arr1[j - 1];
                    }
                    arr1[i] = arr2[index2++];
                    index1++;
                }
            }

            return arr1;

        }

    }
}
