using System;
using System.Collections.Generic;

namespace Union
{
    class Program
    {
        static void Main(string[] args)
        {
            var set1 = new HashSet<int>() { 1, 3, 5, 7, 9, 11 };
            var set2 = new HashSet<int>() { 9, 11, 13, 15, 17, 19 };

            var unionSet = new Dictionary<int, int>();

            foreach (int i in set1) {
                if (unionSet.ContainsKey(i)) {
                    unionSet[i]++;
                }
                else {
                    unionSet[i] = 1;
                }
            }

            foreach (int j in set2) {
                if (unionSet.ContainsKey(j)) {
                    unionSet[j]++;
                }
                else {
                    unionSet[j] = 1;
                }
            }
            
            Console.WriteLine("Union Set");
            foreach (var kvp in unionSet) {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}