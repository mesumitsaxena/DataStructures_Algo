using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given n non-negative integers A[0], A[1], ..., A[n - 1] , where each represents a point at coordinate(i, A[i]).

    //N vertical lines are drawn such that the two endpoints of line i is at(i, A[i]) and(i, 0).

    //Find two lines, which together with x-axis forms a container, such that the container contains the most water.

    //Note: You may not slant the container.
    //Example Input
    //Input 1:

    //A = [1, 5, 4, 3]
    // 
    //    Input 2:

    //A = [1]


    //    Example Output
    //Output 1:

    // 6
    //Output 2:

    // 0

    internal class ContainerWithMostWater
    {
        // Solution is we want maximum sum between two points, also we need to consider distance as well.
        // So we will get maximum distance, if both the pointers are farthest apart
        // Now between two container, water accumilated will be the container with smaller capacity, because if we fill more water it will overflow.
        // example 1, 5, 4, 3, now if we choose between 1 and 3 as 3, its not possible, becasue if we fill 3 amount of water in container 1, it will overflow
        // So we will always take the min among two pointers, so total water will be min(1,3)*distance between 2 and 3 => 1*3=3
        // now next is where should we move, we have calculated the water accumilation for smallest between two points,
        // if we move the pointer from largest element side(in this case 3), then distance will reduce and we might get lesser container or same conainer,
        // then our answer will become more low.
        // So That is why, we will stick to the current largest container which is 3 as of now, and leave 1 by p1++,
        // and check if there is any other better answer which can be formed with 3
        public int maxArea(List<int> A)
        {
            int left = 0;
            int right = A.Count - 1;
            int ans = 0;
            while(left < right)
            {
                //Calcualte Distance
                int distance = (right - left);
                // check the minimum element amont left and right
                int minValue=Math.Min(A[left], A[right]);
                // calculate the answer
                ans=Math.Max(ans,distance*minValue);
                // keep the pointer with max value and move the pointer with smaller value
                // reason is explained above
                if (minValue == A[left])
                {
                    left++;
                }
                else
                {
                    right--;
                }

            }
            return ans;
        }
    }
}
