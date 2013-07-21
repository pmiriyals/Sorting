using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    //Time: (avg) O(n log n) & worst O(n2)
    //In-place, but not stable
    class QuickSort
    {
        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        
        private static int conquer(int[] arr, int start, int pivotIndex, int end)
        {
            int pivot = arr[pivotIndex];
            swap(arr, pivotIndex, end);
            int storeIndex = start;
            for (int i = start; i < end; i++)
            {
                if (arr[i] < pivot)
                {
                    swap(arr, storeIndex, i);
                    storeIndex++;
                }
            }
            swap(arr, storeIndex, end);
            return storeIndex;
        }

        private static void quicksort(int[] arr, int start, int end)
        {
            if (start <= end)
            {
                int pivotIndex = start + (end - start) / 2;
                pivotIndex = conquer(arr, start, pivotIndex, end);
                quicksort(arr, start, pivotIndex - 1);
                quicksort(arr, pivotIndex + 1, end);
            }
        }

        public static void qsort(int[] arr)
        {
            Console.Write("\nQuickSort: ");
            quicksort(arr, 0, arr.Length - 1);
            foreach (int i in arr)
                Console.Write(" {0} ", i);
        }

        public static void driver()
        {
            int[] arr = { 8, 1, 3, 2, 9, 4, 5, 7, 6 };
            qsort(arr);
        }
    }
}
