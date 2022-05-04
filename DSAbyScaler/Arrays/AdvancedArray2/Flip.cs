using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray2
{
    //You are given a binary string A(i.e., with characters 0 and 1) consisting of characters A1, A2, ..., AN. In a single operation, you can choose two indices, L and R, such that 1 ≤ L ≤ R ≤ N and flip the characters AL, AL+1, ..., AR. By flipping, we mean changing character 0 to 1 and vice-versa.

    //Your aim is to perform ATMOST one operation such that in the final string number of 1s is maximized.

    //If you don't want to perform the operation, return an empty array. Else, return an array consisting of two elements denoting L and R. If there are multiple solutions, return the lexicographically smallest pair of L and R.

    //NOTE: Pair(a, b) is lexicographically smaller than pair(c, d) if a<c or, if a == c and b<d.
    internal class Flip
    {
        // Approach is we are targetting 0's, as more number of 0's are together they can form 1 when we flip,
        // So we will create a new array and mark 0's to 1 and 1 to -1, why -1?
        // we will apply kadane;s here, we will cound number of 1 together, and hwo -1 will help, it will start decreasing the sum,
        // so we will get to know the index till where it is giving max sum or number of 1s
        public List<int> flip(string A)
        {
            // Create new Array 0 to 1 and 1 to -1
            List<int> newArray = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '0')
                {
                    newArray.Add(1);
                }
                else
                {
                    newArray.Add(-1);
                }
            }
            // if all are 1 then we cant flip so return the blank array.
            bool flag = false;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '0')
                {
                    flag = true;
                    break;
                }
            }
            if (!flag) return new List<int>();
            // Prepare local sum
            int sum = 0;
            // Prepare global sum
            int ans = Int32.MinValue;
            // Local max start index
            int startIndex = 0;
            // Local max end index
            int endIndex = 0;
            // global max start index
            int ansStartIndex = 0;
            // global max end index
            int ansEndIndex = 0;
            for (int i = 0; i < newArray.Count; i++)
            {
                // reset start index to current index if it is setted -1 when sum<0
                if (startIndex == -1) startIndex = i;
                // add the upcoming element
                sum += newArray[i];
                // update local end index
                endIndex = i;
                // if local sum is greater than gloabl sum, update the global sum
                if (sum > ans)
                {
                    ans = sum;
                    // Also update the global indexes
                    ansStartIndex = startIndex;
                    ansEndIndex = endIndex;
                }
                // if sum is less then 0 then we cant make number of 1s greater by flipping, so reset sum to 0 and startindex to -1
                if (sum < 0)
                {
                    sum = 0;
                    startIndex = -1;
                }
            }
            return new List<int>() { ansStartIndex + 1, ansEndIndex + 1 };
        }
    }
}
