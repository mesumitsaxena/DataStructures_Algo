using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given two arrays of integers A and B, Sort A in such a way that the relative order among the elements will be the same as those are in B.
    //For the elements not present in B, append them at last in sorted order.

    //Return the array A after sorting from the above method.

    //NOTE: Elements of B are unique.
    internal class SortArrayinGivenOrder
    {
        // We want to retain the relative order of B, So we will Sort the List A.
        // then Add all the elements in hashmap, with their frequencies.
        // first add B elements in output array and also decrease the frequency from map so that they should not be added from Array A.
        // Also if any element which is not exist in A should not be added, that is also be checked using map.
        // Lets see this in action
        public List<int> solve(List<int> A, List<int> B)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            A.Sort();
            // Add all the eleemnts from A into map
            for(int i = 0; i < A.Count; i++)
            {
                if (frequencyMap.ContainsKey(A[i]))
                {
                    frequencyMap[A[i]]++;
                }
                else
                {
                    frequencyMap.Add(A[i], 1);
                }
            }
            //now prepare output array and add B's element which is there in map in their relative order, how?
            // iterate on B, check if B[i] exist in map, add in output array
            List<int> result = new List<int>();
            for(int i = 0; i < B.Count; i++)
            {
                while (frequencyMap.ContainsKey(B[i]))
                {
                    result.Add(B[i]);
                    // after adding this to answer array, reduce the frequency
                    frequencyMap[B[i]]--;
                    // Immediatly check if frequency of the element is 0?
                    // so that it should not be added twice while adding from A
                    if (frequencyMap[B[i]] == 0) { frequencyMap.Remove(B[i]); }
                }
            }
            // Now iterate on A, and add those elements which are there in map,
            // Note: we have updated the map as elements which are being picked from B are already removed.
            // A will be in sorted order, how? will iterate on A and add values in output
            for(int i = 0; i < A.Count; i++)
            {
                if (frequencyMap.ContainsKey(A[i]))
                {
                    result.Add(B[i]);
                    // after adding this to answer array, reduce the frequency
                    frequencyMap[B[i]]--;
                    // Immediatly check if frequency of the element is 0?
                    // so that it should not be added twice while adding from A
                    if (frequencyMap[B[i]] == 0) { frequencyMap.Remove(B[i]); }
                }
            }
            return result;

        }
    }
}
