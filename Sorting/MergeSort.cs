using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    //Time: O(n log n), works well with cache, linkedlist, parallel sorting
    //Space: O(n)
    //Stable, but not In-place
    class MergeSort
    {
        public static void conquer(int[] arr, int[] temp, int left, int right, int rightend)
        {
            int leftend = right - 1;
            int k = left;
            int num = rightend - left + 1;

            while ((left <= leftend) && (right <= rightend))
            {
                if (arr[left] < arr[right])
                {
                    temp[k++] = arr[left++];
                }
                else
                    temp[k++] = arr[right++];
            }

            while (left <= leftend)
            {
                temp[k++] = arr[left++];
            }
            while (right <= rightend)
                temp[k++] = arr[right++];

            for (int i = 0; i < num; i++, rightend--)
                arr[rightend] = temp[rightend];
        }

        public static void divide(int[] arr, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                divide(arr, temp, left, mid);
                divide(arr, temp, mid + 1, right);
                conquer(arr, temp, left, mid+1, right);
            }
        }
        
        public static void mergesort(int[] arr)
        {
            Console.Write("\nMergeSort: ");
            int[] temp = new int[arr.Length];
            divide(arr, temp, 0, arr.Length - 1);
            foreach (int i in arr)
                Console.Write(" {0} ", i);
        }

        public static void driver()
        {
            int[] arr = { 8, 1, 3, 2, 9, 4, 5, 7, 6 };
            mergesort(arr);
        }
    }
}
