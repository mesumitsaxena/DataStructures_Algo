using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given two arrays of integers A and B describing a pair of (A[i], B[i]) coordinates in a 2D plane. A[i] describe x coordinates of the ith point in the 2D plane, whereas B[i] describes the y-coordinate of the ith point in the 2D plane.

    //Find and return the maximum number of points that lie on the same line.
    //Example Input
    //Input 1:

    // A = [-1, 0, 1, 2, 3, 3]
    //    B = [1, 0, 1, 2, 3, 4]
    //    Input 2:

    // A = [3, 1, 4, 5, 7, -9, -8, 6]
    //    B = [4, -8, -3, -2, -1, 5, 7, -4]


    //    Example Output
    //Output 1:

    // 4
    //Output 2:

    // 2


    //Example Explanation
    //Explanation 1:

    // The maximum number of point which lie on same line are 4, those points are {0, 0}, { 1, 1}, { 2, 2}, { 3, 3}.
    //Explanation 2:

    // Any 2 points lie on a same line.
    internal class MaxPointsonSameLine
    {
        // It is a Leetcode Hard problem.
        // Intituion is not direct.
        // So in order to find points which lies on same line, we need to know about slope between two points.
        // Slope between two points can be calculated as (x2-x1)/(y2-y1), how it will be helpful.
        // if slope between two points are same slope between other point by fixing one point then it means these 3 points are forming same line.
        // example: if x1,y1 and x2,y2 have slope d, and x1,y1 and x3,y3 also have a slope d, it means these 3 points are on same line.
        // y2-y1 can be 0 then we can get divide by zero exception, so what we can do is, check if we have unique combination of
        // (x2-x1) and (y2-y1) how? we can multiply (x2-x1)*10^7 and add (y2-y1) so that we will get unique combination.
        // So what we can do, we will fix one point and check the slop of each element with fixed point and if slopes are same we will count those points
        // we will use two for loops to generate pairs and then count the slope.
        // we can also get the values which are not exactly equal (x2-x1) and (y2-y1). So we can do one thing which is divide x2-x1 and y2-y1 with gcd of [(x2-x1) and (y2-y1)]
        // example: 11/6 and 22/12 has same slope which is 1.something, but as these are two different numbers we can consider them as different slope.
        // So gcd of 11 and 6 is 1, and 22 and 2, so (11/1)/(6/1) = (22/2)/(12/2)= 11/6
        // we can also have duplicate points so we will consider them as well
        public int __gcd(int x, int y)
        {
            if (x == 0)
                return y;
            return __gcd(y % x, x);
        }
        public int solve(List<int> A, List<int> B)
        {
            int ans = 0;
            // fix one point
            for (int i = 0; i < A.Count; i++)
            {
                Dictionary<long, int> pointsCounterMap = new Dictionary<long, int>();
                int duplicate = 1;
                
                for(int j = i + 1; j < A.Count; j++)
                {
                    if (A[i] == A[j] && B[i] == B[j]) duplicate++;
                    else
                    {
                        int dx = A[j] - A[i];
                        int dy=B[j] - B[i];
                        int g = __gcd(dx, dy);
                        dx = dx / g;
                        dy = dy / g;
                        long tmp = dx * (10000000) + dy;
                        if (pointsCounterMap.ContainsKey(tmp))
                        {
                            pointsCounterMap[tmp]++;
                        }
                        else
                        {
                            pointsCounterMap.Add(tmp, 1);
                        }
                    }
                    
                }
                ans = Math.Max(ans, duplicate);
                foreach (var item in pointsCounterMap)
                {
                    ans = Math.Max(ans, item.Value + duplicate);
                }
            }
            return ans;
        }
    }
}
