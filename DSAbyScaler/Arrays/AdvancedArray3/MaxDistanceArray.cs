using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    //Given an array, A of integers of size N.Find the maximum value of j - i such that A[i] <= A[j].
    internal class MaxDistanceArray
    {
        // one of the condition is A[i]<=A[j], So if we sort the array, we can get this kind of arrangement
        // but if we sort, we will loose the order because we also need to calculate j-i.
        // what we can do, we can create another list with their indexes and then sort them as per their value
        // now as we need j-i, so we will iterate from right and check what is maximum j and what is maximum difference
        
        public int maximumGap(List<int> A)
        {
            // create an another list to store value and index, we can take keyvalue pair
            List<KeyValuePair<int, int>> sortedArray = new List<KeyValuePair<int, int>>();
            for(int i=0;i<A.Count; i++)
            {
                //Add array element as key and index as value
                KeyValuePair<int, int> keyValuePair = new KeyValuePair<int, int>(A[i], i);
                sortedArray.Add(keyValuePair);
            }
            // Sort the Array based on its key(array element)
            sortedArray.Sort((x, y) => x.Key.CompareTo(y.Key));
            int maxj = -1;// initiaze maxj value to -1 because no index can be -1
            // now iterate on the sorted list from the back
            int maxDiff = 0;// if answe is coming as -ve then we should return 0
            for(int index = sortedArray.Count - 1; index >= 0; index--)
            {
                //current difference
                int diff = maxj - sortedArray[index].Value;
                //compare with maxdiff
                maxDiff=Math.Max(maxDiff, diff);
                //update maximum j value if any
                maxj=Math.Max(maxj,sortedArray[index].Value);
            }
            return maxDiff;
        }
        //example: 3, 5, 4, 2 => new array will be 3,0 5,1 4,2 2,3. after sorting => 2,3 3,0 4,2 5,1 => so if we move from back
        // 4,2 can give us maxj and it will give max diff with 3,0
    }
}
