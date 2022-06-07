using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Sorting3
{
    //Given an integer array, A of size N.
    //You have to find all possible non-empty subsequences of the array of numbers and then,
    //for each subsequence, find the difference between the largest and smallest numbers in that subsequence.Then add up all the differences to get the number.

    //As the number may be large, output the number modulo 1e9 + 7 (1000000007).

    //NOTE: Subsequence can be non-contiguous.
    internal class SumtheDifferenceMaxminusMinSubsets
    {
        //In Order to find all the subsequance it will be take 2^n time complexity.
        // So what we can use here is contribution technique.
        // As we need max - min of all subsequence, so we can say max of all subsequence - min of all subsequence
        // A number is max in any subsequence when all the other memebers are smaller than that number.
        // Same way A number is min in any subsequence when all the other memebers are greater than that number.
        // how do we get this, if we sort the array then we will get the numbers which are smaller or greater,
        // but by this subsequance will change? yes , but will this matter? lets see
        // 4 1 5 2 7. here suppose subsequnce is 4 2 7 => max is 7, if we sort =>  2 4 7=> max is still 7.
        // So by sorting our max will not change. and by sorting we will get to know how many subsequance, we have that element max or min
        // so lets sort we will say 1 2 4 5 7. now lets start with 1, how many subsequence 1 is max=> only 1
        // move to 2 => how many subsequnce 2 is max, answer is 2(1,2 and 2 itself).
        // move to 4 =>  how many subsequnce 4 is max, answer is 4, how 4, 4,1, 4,1,2, 4,2(So fix 4 and combination of rest of the element with 4),
        // which is 2^(i-1) or 2^i(with 0 based indexing) in sorted list, sorted list is 1 2 4, so we have 3 elements so if we fix 4 we will be leaving 2 elements, and 2^2=4 and 
        // you can see from above example 4 is having 4 subsequence where it is maximum. and sorting is helping the smaller elements on left
        // So by this we will get the count of max element in which they are maximum, so we say max*A[i]
        // Same way for minimum but minimum will be counted from back of the array.
        public long power(long x, int y)
        {
            long result = 1;
            int mod = 1000000007;
            while (y > 0)
            {

                // y is even
                if (y % 2 == 0)
                {
                    x = (x * x)%mod;
                    y = y / 2;
                }

                // y isn't even
                else
                {
                    result = (result * x)%mod;
                    y = y - 1;
                }
            }
            return result;
        }
        public int solve(List<int> A)
        {
            int mod = 1000000007;
            A.Sort();
            long ans = 0;
            int length = A.Count - 1;
            for (int i = 0; i < A.Count; i++)
            {
                long maxcontri = power(2, i);
                long mincontri = power(2, length - i);
                ///long val = ((A[i] * (1 << i)) % mod - (A[i] * (1 << A.Count - i - 1)) % mod) % mod;

                long maxminusmin = (maxcontri - mincontri) * A[i];
                ans += maxminusmin;
            }
            return (int)((ans+mod) % mod);
        }
    }
}
