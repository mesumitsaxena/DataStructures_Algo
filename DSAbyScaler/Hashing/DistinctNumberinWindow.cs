using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //You are given an array of N integers, A1, A2,..., AN and an integer B.Return the of count of distinct numbers in all windows of size B.

    //Formally, return an array of size N-B+1 where i'th element in this array contains number of distinct elements in sequence Ai, Ai+1 ,..., Ai+B-1.

    //NOTE: if B > N, return an empty array.
    //Example Input
    //Input 1:

    // A = [1, 2, 1, 3, 4, 3]
    //    B = 3
    //Input 2:

    // A = [1, 1, 2, 2]
    //    B = 1


    //Example Output
    //Output 1:

    // [2, 3, 3, 2]
    //    Output 2:

    // [1, 1, 1, 1]


    //    Example Explanation
    //Explanation 1:

    // A=[1, 2, 1, 3, 4, 3]
    //    and B = 3
    // All windows of size B are
    // [1, 2, 1]
    // [2, 1, 3]
    //    [1, 3, 4]
    //    [3, 4, 3]
    //    So, we return an array[2, 3, 3, 2].
    //Explanation 2:

    // Window size is 1, so the output array is [1, 1, 1, 1].
    internal class DistinctNumberinWindow
    {
        // So whenever we are given with window size, we can use Sliding Window Technique.
        // Here create an hashmap and store the first windows elements and frequencies, return map.Count into output array
        // then when sliding the window, add the upcoming window, if element exist, increase its frequency if not then add the elemenet
        // Also remove last windows first element, if frequency is more than 1 then reduce the freq, else remove the element
        // and continue this process for every window
        public List<int> dNums(List<int> A, int B)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            //prepare first windows frequency map
            for(int i=0;i<B; i++)
            {
                if (freqMap.ContainsKey(A[i]))
                {
                    freqMap[A[i]]++;
                }
                else
                {
                    freqMap.Add(A[i], 1);
                }
            }
            List<int> output = new List<int>();
            output.Add(freqMap.Count);
            // lets slide the window
            for(int i = B; i < A.Count; i++)
            {
                //Adding the next element in the map
                if (freqMap.ContainsKey(A[i]))
                {
                    freqMap[A[i]]++;
                }
                else
                {
                    freqMap.Add(A[i], 1);
                }
                // remove last element, if freq
                int lastElement = A[i - B];
                if (freqMap.ContainsKey(lastElement))
                {
                    freqMap[lastElement]--;
                    if (freqMap[lastElement] == 0) freqMap.Remove(lastElement);  
                }
                output.Add(freqMap.Count);
            }
            return output;
        }
    }
}
