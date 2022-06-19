using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given an array A of length N.You have to answer Q queries.

    //Each query will contain four integers l1, r1, l2, and r2. If sorted segment from [l1, r1] is the same as the sorted segment from [l2 r2], then the answer is 1 else 0.


    //NOTE The queries are 0-indexed.

    //Example Input
    //Input 1:

    // A = [1, 7, 11, 8, 11, 7, 1]
    //    B = [
    //          [0, 2, 4, 6]
    //     ]
    //Input 2:

    // A = [1, 3, 2]
    //    B = [
    //          [0, 1, 1, 2]
    //     ] 


    //Example Output
    //Output 1:

    // [1]
    //    Output 2:

    // [0]
    internal class CompareSortedSubarray
    {
        // Basic and Brute force way is just sort the array from given index for each query and check by comparing [O(Q*NLogN)]
        // Another way is store the values from l1 to r1 in hashmap, and then check each value from l2 to r2 and remove from hashmap
        // if hashmap is empty after r2, it means they were same [O(Q*N)]
        public List<int> solve1(List<int> A, List<List<int>> B)
        {
            List<int> output = new List<int>();
            for (int i = 0; i < B.Count; i++)
            {
                int l1 = B[i][0];
                int r1 = B[i][1];
                int l2 = B[i][2];
                int r2 = B[i][3];
                Dictionary<int, int> dupMap = new Dictionary<int, int>();
                for (int j = l1; j <= r1; j++)
                {
                    if (dupMap.ContainsKey(A[j]))
                    {
                        dupMap[A[j]]++;
                    }
                    else
                    {
                        dupMap.Add(A[j], 1);
                    }
                }
                for (int k = l2; k <= r2; k++)
                {
                    if (dupMap.ContainsKey(A[k]))
                    {
                        dupMap[A[k]]--;
                        if (dupMap[A[k]] == 0)
                        {
                            dupMap.Remove(A[k]);
                        }
                    }
                }
                if (dupMap.Count > 0)
                {
                    output.Add(0);
                }
                else
                {
                    output.Add(1);
                }
            }
            return output;
        }
        // Most Optimized approach is prefix sum
        // if 1 2 3 4 2 3 1 and l1=0, r1=2 and l2=4 and r2=6, then sumof l1 to r1=1+2+3=6 and l2 and l2= 2+3+1=6
        // so after creating prefix sum this can be done in O(N) just by iterating prefix sum
        // But the issue is 5+4=9 but 6+3 also = 9. so we cant do just simply addition, we need define each value with some
        // bigger number or random hashvalue which give us unique values and when we add those bigger numbers we always get bigger numbers
        // what is possibility that 21345765+567423144 will equal to 34561734+76538434, its very less, so that is we will represent each number 
        // to a very big larger values which are very far away from each other so that when we add there will be no possibility that their some can be duplicated.

        public List<int> OptimizedApproach(List<int> A, List<List<int>> B)
        {
            // we will use random class to generate random number to generate hashvalues
            Random r = new Random();
            List<int> output = new List<int>();
            //create hashvalues set so that we will not use same hashvalue for different element
            HashSet<long> hashValues = new HashSet<long>();
            // create hashvalues map so that we will get to know for each element what is the hashvalue generated
            Dictionary<int, long> elementsHashingMap = new Dictionary<int, long>();
            List<long> prefixArray = new List<long>();
            //prefixArray.Add(0);
            
            for (int i = 0; i < A.Count; i++)
            {
                // if map contains hashvalue, then we will not change, if it doesnt have then generate the hashvalue
                // and store against that element
                // by this we will ensure that each element is using unque hashvalue
                if (!elementsHashingMap.ContainsKey(A[i]))
                {
                    // create hashvalue
                    long hashValue = r.Next();
                    // if it is already been generated than generate next
                    while (hashValues.Contains(hashValue))
                    {
                        hashValue = r.Next();
                    }
                    //if it is unique then add in set, so that next time no one can use it
                    hashValues.Add(hashValue);
                    //add the hashvalue against the element
                    elementsHashingMap.Add(A[i], hashValue);
                }
                // use common prefix sum technique, if element is 1st eleemnt than just store the hashvalue against A[i]
                if (i == 0)
                {
                    prefixArray.Add(elementsHashingMap[A[i]]);
                }
                // else previous hashvalue + hashvalue against A[i]
                else
                {
                    prefixArray.Add(prefixArray[i - 1] + elementsHashingMap[A[i]]);
                }

            }
            for (int i = 0; i < B.Count; i++)
            {
                // Self explainable code below, simple prefix sum technique
                int l1 = B[i][0];
                int r1 = B[i][1];
                int l2 = B[i][2];
                int r2 = B[i][3];
                long sum1 = prefixArray[r1] - prefixArray[l1]+elementsHashingMap[A[l1]];
                long sum2 = prefixArray[r2] - prefixArray[l2]+elementsHashingMap[A[l2]];
                if (sum1 == sum2)
                {
                    output.Add(1);
                }
                else
                {
                    output.Add(0);
                }
            }
            return output;
        }
    }
}
