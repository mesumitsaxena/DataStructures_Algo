using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given an unsorted integer array A of size N.

    //Find the length of the longest set of consecutive elements from array A.
    //Example Input
    //Input 1:

    //A = [100, 4, 200, 1, 3, 2]
    //    Input 2:

    //A = [2, 1]


    //    Example Output
    //Output 1:

    // 4
    //Output 2:

    // 2


    //Example Explanation
    //Explanation 1:

    // The set of consecutive elements will be[1, 2, 3, 4].
    //Explanation 2:

    // The set of consecutive elements will be[1, 2].
    internal class LongestConsecutiveSequence
    {
        // Brute force way is fix one number and check its next number and keep on checking untill we have next number
        // its time complexity is very high
        // next solution is Sort the array and then check then count the adjecent numbers group, largest group count will be the answer
        // Sorting is nLogn.
        // lets do a little optimization - 
        // Insert all the elements in set and consider every element as starting element.
        // incremeet current element by 1 and check in Set if exist, count ++, do it for every element
        // but by fixing one element we are checking for next elements by incrementing 1 if exist check next and so on,
        // it can be O(N^2) right->
        // example: -1 8 2 3 7 1 4 9
        // -1 -> no element
        // 8 -> 9 ->  no element so count is 2 and answer is 2
        // 2 -> 3 -> 4 -> no element, so count is 3 and answer is 3
        // 3 -> 4 -> no element, so count is 2, but answer is still 3
        // 7 -> 8 ->  no element, so count is 2, but answer is still 3
        // 1 -> 2 -> 3 -> 4 -> no element, so count is 4, and answe will also be 4 and so on
        // So checking each element and its next values will be O(N^2)
        // issue in above approach is we know 1 is the starting point, and if we only check 1 we can get maximum length
        // but we are checking 2 as well, 3 as well, 4 as well, which will never give us greater answer
        // Lets optimize little further, if somehow we can find out if current eleemnt is starting index or not?
        // if yes then we will perform the above operation only on that element
        // how to check? if suppose current element is 15, we can check from set if 14 is there in array or not
        // if 14 is there, then 15 can never be first element and if 14 is not there in set it means it is the first element
        // and lets calculate the number of consecutive sum. so lets take above example and understand
        // example: -1 8 2 3 7 1 4 9
        // -1 -> check if -2 is there or not in set, -2 is not there so consider it so -1 -> no element , count is 1, answer is 1
        // 8 -> check 7 is there in set or not, 7 exist in set, so 8 can not be first element, and it will never give us greater lenght so skip it
        // 2 -> check 1 is there or not, yes 1 exist, so skip it
        // 3 -> 4 -> check 2 exist, yes, skip
        // 7 -> 8 ->  check 6 exist or not, no, so consider it, now 7 -> 8-> no element, so count =2, answer=2
        // 1 -> check 0 is there or not, no 0 is not there, so consider it as first element
        // so 1-> 2-> 3->4-> no element, so count is 4 and answer is also 4
        // Here we are only traversing 1 element at a time, so time complexity will be O(N)
        public int longestConsecutive(List<int> A)
        {
            HashSet<int> checkDupliates = new HashSet<int>();
            int longestConsecutiveCount = 0;
            // maintain Hashset
            for(int i = 0; i < A.Count; i++)
            {
                if (!checkDupliates.Contains(A[i]))
                {
                    checkDupliates.Add(A[i]);
                }
            }
            for(int i = 0; i < A.Count; i++)
            {
                // check if current value is first value or not
                int lastValue = A[i] - 1;
                int count = 0;
                // if yes
                if (!checkDupliates.Contains(lastValue))
                {
                    int nextValue = A[i];
                    // check for next value
                    while (checkDupliates.Contains(nextValue))
                    {
                        count++;
                        nextValue = nextValue + 1;
                    }
                }
                longestConsecutiveCount = Math.Max(longestConsecutiveCount, count);
            }
            return longestConsecutiveCount;
        }
    }
}
