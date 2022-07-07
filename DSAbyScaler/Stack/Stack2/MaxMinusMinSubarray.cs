using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack2
{
    //Given an array of integers A.

    //value of a array = max(array) - min(array).

    //Calculate and return the sum of values of all possible subarrays of A modulo 109+7.
    //Example Input
    //Input 1:

    // A = [1]
    //    Input 2:

    // A = [4, 7, 3, 8]


    //    Example Output
    //Output 1:

    // 0
    //Output 2:

    // 26


    //Example Explanation
    //Explanation 1:

    //Only 1 subarray exists.Its value is 0.
    //Explanation 2:

    //value ( [4] ) = 4 - 4 = 0
    //value ( [7] ) = 7 - 7 = 0
    //value ( [3] ) = 3 - 3 = 0
    //value ( [8] ) = 8 - 8 = 0
    //value ( [4, 7] ) = 7 - 4 = 3
    //value ( [7, 3] ) = 7 - 3 = 4
    //value ( [3, 8] ) = 8 - 3 = 5
    //value ( [4, 7, 3] ) = 7 - 3 = 4
    //value ( [7, 3, 8] ) = 8 - 3 = 5
    //value ( [4, 7, 3, 8] ) = 8 - 3 = 5
    //sum of values % 10^9+7 = 26
    internal class MaxMinusMinSubarray
    {
        // Brute force way is to generate all subarray and then check the max and min of that subarray and take a difference
        // take a total variable and add all the differences.
        // generating all the subarrays will take O(N^2) time complexity, and then we have to find max and min out of it, its like o(N^3)
        // lets focus on other solution - 
        // if we sort the array then we may get max and min? but by this order will be jumble and subarray's are contigeous in nature, So cant Sort
        // We have to find max-min of all the subarray, it is having all world, can we think of CONTRIBUTION technique?
        // but contribution is mostly applied on subsets or subsequences, Lets see how can we use Contribution on subarray-
        // Can we say that we need => Sum of (Max - Min) of all subarray
        // we can also say (Sum of Max of all subarray - Sum of Mins of all subarray)
        // So we can fine Max and Min seperetly.
        // Now how contribution will help in subarrays?
        // lets take an example: array is 3 4 1 6 7 8 2
        // Suppose we are taking about 6, We can ask this question, in how many subarrays 6 is maximum and in how many subarrays 6 is minimum
        // if we see from the example: 3 4 1 6, here 6 is maximum in 4 subarrats([3,4,1,6],[4,1,6],[1,6],[6])
        // now here for minimum : only 6 7 8, 6 is minimum, how? ([6],[6,7],[6,7,8]) so 3, so for 6 answer is 4-3=1
        // How do we calculate above calculation? for 6 to be maximum, if any element around 6 is maximum, then 6 can't be maximum in that subarray right,
        // so 6 to be maximum in subarray, all the other elements in that subarray should be minimum.
        // So in lets move left to 6 and stop where any element is max then 6. also move right to the 6 and stop when element is greater than 6
        // So in 3 4 1 6 7 8 2. we will move left to the 6 and will stop if any element is greater, we dont find any element greater than 6 on left
        // So we can say all the elements on left can be considered in the subarray, So length of the subarray would be i-(-1) => 3-(-1)=4 and we can see, 3 4 1 6 are 4 eleemnts
        // Now lets see on right => 3 4 1 6 7 8 2 => when we move to the right we found the element 7 which is greater than 6 so we will stop there and check the index of 7
        // index of 7 is 4, and index of 6 is 3, so there is only one eleemnt (4-3), which is greater than equal to 6 is 6 itself.
        // Now total number of subarrays which in which 6 is greater => length of left subarray in whihc 6 is greater * length of right subarray in whic 6 is greater.
        // lets understand this with different example: lets talk about 4, we have 3 4 1, here 4, 3,4 4,1 so 3 subarray where 4 is max
        // so 3 can be starting point, 4 can be a starting point and on right only 1 can be ending point, if on right many more items are there then they can be starting point as well.
        // So if we say for a given i, if j is starting point by which A[i] is max and k is the ending point till A[i] is max.
        // then total number of subarrays in which A[i] is max => (i-j]*(k-i).
        // Same way we will also calculate in how many subarray current eleemnt is min, and then subtract from max.
        // So total contribution for an element in MAX-MIN will be (max-min)*A[i].

        // Lets understand how to calculate Max and Min-
        // for calculating in how many subarray element is max, do we iterate on left and right to see the next largest element?
        // No, we have already done this question (prev Largest Element), by using that technique, we will be able to get the prev largest
        // element for current element, but here only catch, do we store value or index in result array while calculting next prev element?
        // we will store index, because then we will be able to get the length (i-j) and k-i etc.
        // Lets understand with an example: 3 4 1 6 7 8 2, prepare result of next largest element on left
        // so from left if no largest element then store -1 as index.
        // result will be -1 -1 -1 -1 -1 -1 5. by this we have store two information, index and value(A[index]).
        // for 6 we can easilt get (i-j), 6 is at index 3, so i=3 and corresponding j will be value from the same index in result
        // of prev largest element, which is -1, so 3-(-1)=4 which is correct.
        // for min, we will calculte next largest element, and if there is no maximum in right then store length of array.
        // why?( because when we calculate (k-i), then k will be length of array -current index means all the elements after i.

        // Conclusion: we need to create Next Largest Array, Next minimum Array
        // Also Previous Largest Array, and Previous Minimum Array.
        // and result array of each will have indexes instead of values

        public List<int> nextLargestArray(List<int> input)
        {
            Stack<int> nextLargestStack= new Stack<int>();
            int[] output = new int[input.Count];
            for(int i = input.Count-1; i >=0; i--)
            {
                while(nextLargestStack.Count>0 && input[nextLargestStack.Peek()] <= input[i])
                {
                    nextLargestStack.Pop();
                }
                if (nextLargestStack.Count == 0) output[i] = input.Count;
                else
                {
                    output[i] = nextLargestStack.Peek();
                }
                nextLargestStack.Push(i);
            }
            return output.ToList();
        }
        public List<int> nextSmallestArray(List<int> input)
        {
            Stack<int> nextSmallestStack = new Stack<int>();
            int[] output= new int[input.Count];
            for(int i = input.Count - 1; i >= 0; i--)
            {
                while(nextSmallestStack.Count>0 && input[nextSmallestStack.Peek()] >= input[i])
                    nextSmallestStack.Pop();
                
                if(nextSmallestStack.Count==0) output[i] = input.Count;
                else output[i]=nextSmallestStack.Peek();
                nextSmallestStack.Push(i);
            }
            return output.ToList();
        }
        public List<int> prevSmallestArray(List<int> input)
        {
            Stack<int> prevSmallestStack = new Stack<int>();
            int[] output = new int[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                while (prevSmallestStack.Count > 0 && input[prevSmallestStack.Peek()] >= input[i])
                    prevSmallestStack.Pop();

                if (prevSmallestStack.Count == 0) output[i] = -1;
                else output[i] = prevSmallestStack.Peek();
                prevSmallestStack.Push(i);
            }
            return output.ToList();
        }
        public List<int> prevLargestArray(List<int> input)
        {
            Stack<int> prevLargestStack = new Stack<int>();
            int[] output = new int[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                while (prevLargestStack.Count > 0 && input[prevLargestStack.Peek()] <= input[i])
                    prevLargestStack.Pop();

                if (prevLargestStack.Count == 0) output[i] = -1;
                else output[i] = prevLargestStack.Peek();
                prevLargestStack.Push(i);
            }
            return output.ToList();
        }

        public int solve(List<int> A)
        {

            int mod = 1000000007;
            // Store all next and previous largest and smallest values indexes
            List<int> nextLargestArr = nextLargestArray(A);
            List<int> nextSmallestArr = nextSmallestArray(A);
            List<int> prevSmallestArr = prevSmallestArray(A);
            List<int> prevLargestArr = prevLargestArray(A);
            long result = 0;
            for(int i = 0; i < A.Count; i++)
            {
                // Calculate (i-j)*(k-i) for max and min

                // i- j(it will be previous largest value's index) * (k(next largest value's index -i)
                long Max = ((long)(i - prevLargestArr[i]) * (long)(nextLargestArr[i] - i))%mod;
                long Min = ((long)(i - prevSmallestArr[i]) * (long)(nextSmallestArr[i] - i))%mod;
                // add the result with (max-min)*A[i]
                result += ((Max - Min+mod)%mod * (long)A[i])%mod;
                result = result % mod;

            }
            return (int)result;
        }
    }
}
