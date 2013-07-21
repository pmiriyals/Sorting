using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            HeapSort.driver();
            QuickSort.driver();
            MergeSort.driver();
            Console.ReadLine();
        }
    }
}
