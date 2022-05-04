using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray2
{
    internal class PickfromBothSides
    {
        public int solve(List<int> A, int B)
        {
            int ans = Int32.MinValue;
            int sum = 0;
            for (int i = 0; i < B; i++)
            {
                sum += A[i];
                ans = sum;
            }
            for (int j = 1; j <= B; j++)
            {
                sum = sum - A[B - j] + A[A.Count - j];
                ans = Math.Max(sum, ans);
            }
            return ans;
        }
        // Solution

        /*
                Understand the Question - We have to select B elements from either side to create maximum sum.
            example : 5, -2, 3 , 1, 2 and B=3
            first we will choose between 5 and 2, our instinct will directly say in order to maximize the answer pick 
            largest number so we will pick 5
            now array which is available to us is -2 3 1 2. now we have to pick between -2 and 2 as 2 is largest we will
            add 2 in our answer so sum=5+2 now available array -2 3 1
            choose -2 or 1 will choose 1  so sum = 5+2+1=8 .now we have choosen 3 elements so sum=8 which is greatest

            This is Called Greedy Algorithm because at every step we are greedy about the maximum answer for that moment
            and we are not thinking there might be other possible sum as well. example

            5 2 4 21 -1 and B=3
            max(5,-1) = 5
            max(2,-1) = 2
            max(4,-1) = 4
            means 5+2+4 = 11, are you sure the maximum answer is 11. No, how? 
            we have 5+21-1 = 25.

            So greedy will not work at all.

            Optimize Approach -

            We should check all the possible answers -
            example: 5 2 4 21 -1 and B=3
            how can pick the elements?

            1st way to choose-

            5 2 4 21 -1 ( take first 3 elements 5 2 4) = 5+2+4 = 11, so Ans = 11

            2nd way to choose-

            5 2 4 21 -1 (take first 2 elments and last element which is 5 2 and -1) = 5+2-1 = 6, but Ans =max(11,6) =11

            3rd way to choose-

            5 2 4 21 -1 (take first element and last 2 elements which is 5 21 and -1) = 5+21-1=25 but Ans=max(11,25) =25

            4th way to choose-

            5 2 4 21 -1 (take last 3 elements which is 4 21 and -1) = 4+21-1=24 but Ans=max(24,25) =25

            There are no other way to choose 3 elements picking from both ends.

            So if B=3 there are B+1 ways to pick  the elements.

            Now if we see carefully, in first way we are taking sum of all first B elements.
            Then in 2nd way we are subracting A[B-1] element and adding last(A[N-1]) element
            Then in 3rd way we are subtracting A[B-2] element and adding A[N-2] element
            Then in final way we are subtracting A[B-3] element and adding A[N-3] element.

            So generalize way is subtract A[B-i] and add A[N-i] to the sum and check maximum answer each time.


            */
    }
}
