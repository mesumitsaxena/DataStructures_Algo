using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given two arrays of integers A and B of size N each, where each pair(A[i], B[i]) for 0 <= i<N represents a unique point (x, y) in a 2-D Cartesian plane.

    //Find and return the number of unordered quadruplet(i, j, k, l) such that(A[i], B[i]), (A[j], B[j]), (A[k], B[k]) and(A[l], B[l]) form a rectangle with the rectangle having all the sides parallel to either x-axis or y-axis.

    //    Example Input
    //Input 1:

    // A = [1, 1, 2, 2]
    //    B = [1, 2, 1, 2]
    //    Input 1:

    // A = [1, 1, 2, 2, 3, 3]
    //    B = [1, 2, 1, 2, 1, 2]


    //    Example Output
    //Output 1:

    // 1
    //Output 2:

    //3
    internal class CountRectangles
    {
        //For Rectangle, if we know two points then only we can find another two points.
        // There is no way we can find two points with only iterating 1 point.
        // So we will iterate on two points and check if other two points exists or not, if yes then count++
        /*
         * (x1,y1)__________(x2,y2)
         * |                    |
         * |                    |
         * |                    |
         * |                    |
         * (x3,y3)__________(x4,y4)
         * 
         * Here suppose we fix x1,y1 and x4,y4 and found x3,y3 as (x1,y4) and x2,y2 as (x4,y1) so we will say count++
         * but here is one catch, if we are able to find two co-ordiantes[(x3,y3), (x2,y2)] by fixing two points [(x1,y1), (x4,y4)].
         * then we can definetly find two cordinates [(x1,y1), (x4,y4)] by fixing [(x3,y3), (x2,y2)]. So we are counting 1 rectangle twice.
         * So at end half the answer which is count of rectangles.
         * 
         * We will also check that we always pick diagnol points, the points should not be on same line(axis).
        */
        public int solve(List<int> A, List<int> B)
        {
            Dictionary<int, HashSet<int>> allCoordiantes = new Dictionary<int, HashSet<int>>();
            for(int i=0; i<A.Count; i++)
            {
                if (allCoordiantes.ContainsKey(A[i]))
                {
                    allCoordiantes[A[i]].Add(B[i]);
                }
                else
                {
                    HashSet<int> tmp = new HashSet<int>();
                    tmp.Add(B[i]);
                    allCoordiantes.Add(A[i], tmp);
                }
            }
            int countRectangles = 0;
            for(int i = 0; i < A.Count; i++)
            {
                for(int j=i+1;j<B.Count; j++)
                {
                    //check if both the points are not in same axis
                    if (A[i] == A[j] || B[i] == B[j]) continue;
                    if(allCoordiantes[A[i]].Contains(B[j]) && allCoordiantes[A[j]].Contains(B[i]))
                    {
                        countRectangles++;
                    }
                }
            }
            return countRectangles / 2;
        }
    }
}
