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

            var intersectionSet = new Dictionary<int, int>();

            foreach (int i in set1) {
                if (intersectionSet.ContainsKey(i)) {
                    intersectionSet[i]++;
                }
                else {
                    intersectionSet[i] = 1;
                }
            }

            foreach (int j in set2) {
                if (intersectionSet.ContainsKey(j)) {
                    intersectionSet[j]++;
                }
                else {
                    intersectionSet[j] = 1;
                }
            }

            // Print the intersectionSet
            Console.WriteLine("Intersection Set:");
            foreach (var kvp in intersectionSet) {
                if (kvp.Value > 1) {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}
