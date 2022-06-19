using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given two arrays of integers A and B of size N each, where each pair(A[i], B[i]) for 0 <= i<N represents a unique point (x, y) in 2D Cartesian plane.

    //Find and return the number of unordered triplets (i, j, k) such that (A[i], B[i]), (A[j], B[j]) and (A[k], B[k]) form a right-angled triangle with the triangle having one side parallel to the x-axis and one side parallel to the y-axis.

    //NOTE: The answer may be large so return the answer modulo (109 + 7).
    //Example Input
    //Input 1:

    // A = [1, 1, 2]
    //    B = [1, 2, 1]
    //    Input 2:

    // A = [1, 1, 2, 3, 3]
    //    B = [1, 2, 1, 2, 1]


    //    Example Output
    //Output 1:

    // 1
    //Output 2:

    // 6


    //Example Explanation
    //Explanation 1:

    // All three points make a right angled triangle.So return 1.
    //Explanation 2:

    // 6 triplets which make a right angled triangle are:    (1, 1), (1, 2), (2, 2)
    //                                                       (1, 1), (3, 1), (1, 2)
    //                                                       (1, 1), (3, 1), (3, 2)
    //                                                       (2, 1), (3, 1), (3, 2)
    //                                                       (1, 1), (1, 2), (3, 2)
    //                                                       (1, 2), (3, 1), (3, 2)
    internal class CountRightAngleTriangle
    {
        // Approach 1: 
        // Fix one dimension, and iterate on other 2 and check if they are right angle triangle or not,
        // How to check if with given dimension, it is formaing, right angle?
        /* (x3,y3)
            | \
            |   \
            |_____\(x2, y2)
        (x1, y1)*/
        // Here if it is right angle, then x1==x3 and y1==y2 then only it will form right angle triangle
        // but we need to make sure, that all 3 points should be distinct
        public int Approach1(List<int> A, List<int> B)
        {
            // suppose we have 1,2 1,3 and 2,3, we can not consider same element again, like 1,2 and 1,2, so that is why i!=j
            // same 1,2 and 1,3 both should not be equal to 2,3 then only we can say its a triangle(selecting 3 different points)
            // cant we say j=i+1 and k=j+1, it will always make sure, 3 points are different
            // but by this once we consider 3 points, we are moving forward, it is quite possible, that other points with previous points also can make triangle
            // example : 1,2 , 1,3  2,3 , 3,4. so by this logic, we will never consider, 2,3 3,4 with 1,2 because k is j+1
            // so that is why reseting k=0 and j=0 so that we get all possible distinct combination

            int count = 0;
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A.Count; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < A.Count; k++)
                        {
                            if (i != k && j != k)
                            {
                                if (A[i] == A[k] && B[j] == B[k])
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }
        // Approach 2:
        /* (x3,y3)-(x2,y3)
            | \    |
            |   \  | 
            |_____\(x2, y2)
        (x3, y2)*/
        // in the above example, instead of fixing all 3 points, if we just fix 2 points x3,y3 and x2,y2 
        // and we check if (x3,y2) or (x2,y3) exist in the list then it is forming a right angle traingle
        // how do we check that?
        // using hashset, store all the points into hashset, and now just check all possible pair of points 
        // if x3,y2 or x2, y3  exist in hashset, count++
        // but here we always needs to check if the two coordinates are diagonal line, not a vertical and horizontal line
        // example : 1,3 and 4,3 this is a horizontal line, and we can form a coordinate with our logic is 1,3(x3,y2)
        // but this is not right. so we will take care of this edge case
        public int Approach2(List<int> A, List<int> B)
        {
            int count = 0;
            HashSet<string> dimensionSet = new HashSet<string>();
            for(int i = 0; i < A.Count; i++)
            {
                dimensionSet.Add(A[i].ToString() + "_" + B[i].ToString());
            }
            // create pair
            for(int i = 0; i < A.Count; i++)
            {
                for(int j = i + 1; j < A.Count; j++)
                {
                    if(A[i]==A[j] || B[i] == B[j])
                    {
                        continue;
                    }
                    string x3y2 = A[i].ToString() + "_" + B[j].ToString();
                    string x2y3 = A[j].ToString() + "_" + B[i].ToString();
                    if (dimensionSet.Contains(x3y2))
                    {
                        count++;
                    }
                    if (dimensionSet.Contains(x2y3))
                    {
                        count++;
                    }
                }
            }
            return count;

        }
        //Approach 3:
        // Most optimized Approach-
        // we will work around only 1 co-ordinate.
        // consider every co-ordinate as middle point.
        // then check how many x and y are there with same value, those many combinations can be formed different triangle
        /*              |
         *              |(x,_)
         *              |
         *              |        
         * ----(,y)----(x,y)-------(-,y)----------      
         *              |    
         *              |(x,_)    
         *              |
         */  
        // So all those combinations can form right angle triangle considering (x,y) as middle co-ordinate
        // if we have same x with different Y's we can consider those many (x-1) elements
        // if we have same y with different X's we can consider those many (y-1)  elements
        // So all possible combination which can form triangle would be (no of x-1)*(no of y-1), excluding current element
        // because with (x,y) any (x,something) can form a right angle triangle with (any x, y)
        // how to get number of xs and ys in O(1)
        // hashmap
        public int Approach3(List<int> A, List<int> B)
        {
            Dictionary<int, int> frequencyX = new Dictionary<int, int>();
            Dictionary<int, int> frequencyY = new Dictionary<int, int>();
            for(int i = 0; i < A.Count; i++)
            {
                if (frequencyX.ContainsKey(A[i]))
                {
                    frequencyX[A[i]]++;
                }
                else
                {
                    frequencyX.Add(A[i], 1);
                }
            }
            for (int i = 0; i < B.Count; i++)
            {
                if (frequencyY.ContainsKey(B[i]))
                {
                    frequencyY[B[i]]++;
                }
                else
                {
                    frequencyY.Add(B[i], 1);
                }
            }
            int count = 0;
            for(int i = 0; i < A.Count; i++)
            {
                int noX = frequencyX[A[i]];
                int noY = frequencyY[B[i]];
                count += (noX - 1) * (noY);
            }
            return count;

        }
    }
}
