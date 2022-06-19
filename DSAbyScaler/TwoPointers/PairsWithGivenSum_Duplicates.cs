using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given a sorted array of integers (not necessarily distinct) A and an integer B, find and return how many pair of integers ( A[i], A[j] ) such that i != j have sum equal to B.

    //Since the number of such pairs can be very large, return number of such pairs modulo(109 + 7).

    //Example Input
    //Input 1:

    //A = [1, 1, 1]
    //    B = 2
    //Input 2:

 
    //A = [1, 1]
    //    B = 2


    //Example Output
    //Output 1:

    // 3
    //Output 2:

    // 1
    internal class PairsWithGivenSum_Duplicates
    {
        // This is exact same question as Count of Pais with given Sum, only thing is here we might have duplicates as well
        // How duplicates effect our solution, lets take the example:
        // ex: 1 2 3 3 3 3 4 5, and B= 7, how many count of pairs with sum=7, we can see, there are 4 3s and 1 4 which make sum 7.
        // Also we have 5 and 2 which make sum 7, so (5,2) and (3,4), (3,4) , (3,4), (3,4) will make the count as 5
        // As per our solution once we consider 3 and 4 as pair, we will move further from right as right-- and right will point to next 3
        // and we will not check another pair with 4.
        // Also there are other examples: 1 2 2 2 3 3 3 4  and B=5.
        // Another example is 1 2 3 4 4 4 5 5 5 6 6 7 and B=10, here 3 5s are there, so only 2 wll make sum=10, also 3 4s and 2 6s will make sum as 10
        // So in order to solve this question, rest of solution will same as previous
        // only thing which will change is when we found the sum, so when we found the sum, above edge cases needs to be considered
        // lets talk about different element with repetition giving the sum
        // then we will simply count from left and count from right and multiply them, why example 2 2 3 3 3 and B=5, so first 2 will make a pair with all 3,
        // another 2 will make sum with all 3, 3*2=6 pairs
        // next is if 5 5 5 5 5 and B=10, then count the numbers(right-left) and say (count*count-1)/2, like subarray
        // how to identify the above pattern?? if the array is sorted and we got the sum and A[left]==A[right],
        // it means there are same elements between left and right
        public int solve(List<int> A, int B)
        {
            // refer Count of pairs with given sum questions for rest of the code behaviour
            int mod = 1000000007;
            int l = 0;
            int r = A.Count - 1;
            long ans = 0;
            while (l < r)
            {
                // when we find the exact sum
                if (A[l] + A[r] == B)
                {
                    // we will check the pattern of 5 5 5 5 5
                    if (A[l] == A[r])
                    {
                        // calculate count as right-left +1
                        long count = r - l + 1;
                        // calculate count as below formula, becasue number of pairs will be like subarray
                        // 5 will make pair with next 4 5s, then next 5 will make pair with next 3 5s and so on.
                        count = ((count % mod) * ((count - 1) % mod) / 2) % mod;
                        ans += count;
                        l++;
                        r--;
                    }
                    // if pattern is not 5 5 5 5, then there can be normal sum or 2 2 4 5 5 kind of situation also happend
                    else
                    {
                        // So count all occurances of left pointers
                        long count0 = 0;
                        int x = A[l];
                        while (l < r && x == A[l])
                        {
                            count0++;
                            l++;
                        }
                        // count all the occurances of right pointer
                        long count1 = 0;
                        int x1 = A[r];
                        while (l <= r && x1 == A[r])
                        {
                            count1++;
                            r--;
                        }
                        // and multiply them
                        long count = (count0 % mod * count1 % mod) % mod;
                        ans += count;
                    }
                }
                else if (A[l] + A[r] > B)
                {
                    r--;
                }
                else if (A[l] + A[r] < B)
                {
                    l++;
                }
            }
            return (int)(ans % mod);
        }
    }
}
