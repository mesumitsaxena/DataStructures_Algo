using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Shaggy has an array A consisting of N elements.We call a pair of distinct indices in that array a special if elements at those indices in the array are equal.

    //Shaggy wants you to find a special pair such that the distance between that pair is minimum.Distance between two indices is defined as |i-j|. If there is no special pair in the array, then return -1.
    //Example Input
    //Input 1:

    //A = [7, 1, 3, 4, 1, 7]
    //    Input 2:

    //A = [1, 1]


    //    Example Output
    //Output 1:

    // 3
    //Output 2:

    // 1
    internal class ShaggyandDistances
    {
        // In Order to solve this, we will store the value and index in hashmap, and if the same element comes.
        // create the difference, store in answer(check if it is minimum or not) and then update elements index to new index in hashmap
        public int solve(List<int> A)
        {
            // Define Map
            Dictionary<int, int> distanceMap = new Dictionary<int, int>();
            int minDistance = Int32.MaxValue;
            for(int i = 0; i < A.Count; i++)
            {
                // If duplicate found
                if (distanceMap.ContainsKey(A[i]))
                {
                    //Calculte the distance
                    int distance = i-distanceMap[A[i]];
                    //Update map
                    distanceMap[A[i]] = i;
                    // Store the minimum answer
                    minDistance = Math.Min(distance, minDistance);
                }
                else
                {
                    // if not duplicate then add the element in map
                    distanceMap.Add(A[i], i);
                }
            }
            // if there is no duplicate, return -1
            if (minDistance == Int32.MaxValue) return -1;
            return minDistance;
        }
    }
}
