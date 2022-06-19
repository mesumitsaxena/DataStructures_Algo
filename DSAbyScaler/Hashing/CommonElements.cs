using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given two integer arrays, A and B of size N and M, respectively.Your task is to find all the common elements in both the array.

    //NOTE:

    //Each element in the result should appear as many times as it appears in both arrays.
    //The result can be in any order.
    //    Example Input
    //Input 1:

    // A = [1, 2, 2, 1]
    // B = [2, 3, 1, 2]
    //Input 2:

    // A = [2, 1, 4, 10]
    // B = [3, 6, 2, 10, 10]


    //Example Output
    //Output 1:

    // [1, 2, 2]
    //Output 2:

    // [2, 10]
    internal class CommonElements
    {
        // focus on this line: Each element in the result should appear as many times as it appears in both arrays.
        // it means, the common elements, if 2 is there in 1st array 2 times and 3 times in second array, then print it on 2 times
        //Simple soluton could be, store the other array with their frequency in hashmap and
        // then iterrate on first array, if we found the element, reduce the frequency also if freq becomes 0 then remove the eleemnt from map
        public List<int> solve(List<int> A, List<int> B)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            for (int i = 0; i < B.Count; i++)
            {
                if (freqMap.ContainsKey(B[i]))
                {
                    freqMap[B[i]]++;
                }
                else
                {
                    freqMap.Add(B[i], 1);
                }
            }
            List<int> output = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                if (freqMap.ContainsKey(A[i]))
                {
                    output.Add(A[i]);
                    freqMap[A[i]]--;
                    if (freqMap[A[i]] == 0)
                    {
                        freqMap.Remove(A[i]);
                    }
                }
            }
            return output;
        }
    }
}
