using System;
using System.Collections.Generic;

namespace Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            var set1 = new HashSet<int>() { 1, 3, 5, 7, 9, 11 };
            var set2 = new HashSet<int>() { 9, 11, 13, 15, 17, 19 };

            // Convert HashSet<int> to arrays
            int[] array1 = set1.ToArray();
            int[] array2 = set2.ToArray();

            var intersectionSet = new HashSet<int>();

            // Find intersection of array1 and array2
            foreach (int i in array1) {
                if (Array.IndexOf(array2, i) != -1) { // Check if i exists in array2
                    intersectionSet.Add(i);
                }
            }

            // Print the intersectionSet
            Console.WriteLine("Intersection Set:");
            foreach (int num in intersectionSet) {
                Console.WriteLine(num);
            }
        }
    }
}
