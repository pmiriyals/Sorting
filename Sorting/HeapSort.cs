using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    //In-place, not stable
    class HeapSort
    {
        //Time: O(nlogn)
        public static void heapsort(int[] arr)
        {
            int end = arr.Length - 1;   //index of the last element in arr
            heapify(arr, end);  //place max element in arr at index 0
            while (end >= 0)
            {
                SwapArr(arr, 0, end);   //Extract max element and place it at the last index (correct posn)
                end--;  //Now arr to be sorted is from 0 to end-1
                siftdown(arr, 0, end);  //Get the next max element and place it at index 0
            }

            Console.Write("\nHeapSort : ");
            foreach (int i in arr)
                Console.Write(" {0} ", i);
        }
        
        public static void heapify(int[] arr, int count)
        {
            int start = (count - 1) / 2;    //Find the last parent, that is for an element at index 'k', children are 2k+1, 2k+2
            while (start >= 0)  //for every parent from last to first, sift down (that is place array in max heap)
            {
                siftdown(arr, start, count);
                start--;    //for each parent
            }
        }

        public static void SwapArr(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void siftdown(int[] arr, int start, int end)
        {
            int root = start;   //last parent (root element)
            while ((root * 2 + 1) <= end)   //end is the index of last element in arr
            {
                int child = root * 2 + 1;   //1st child of start
                int swap = root;    //save start index
                if (arr[child] > arr[swap]) //parent should be greater than both children in max heap
                    swap = child;

                if (child + 1 <= end && arr[swap] < arr[child + 1])
                    swap = child + 1;   //find the max element between parent, child1, child2 and save index to swap

                if (swap != root)   //if the root element is not the max element
                {
                    SwapArr(arr, swap, root);   //Place max to parent's posn
                    root = swap;    //Now, root element will be swap 
                }
                else
                    return; //if parent is the max element then return
            }
        }

        public static void driver()
        {
            int[] arr = { 8, 1, 3, 2, 9, 4, 5, 7, 6 };
            heapsort(arr);
        }
    }
}
