using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Sorting.Sorting2
{
    //We have a list A of points(x, y) on the plane.Find the B closest points to the origin(0, 0).

    //Here, the distance between two points on a plane is the Euclidean distance.

    //You may return the answer in any order.The answer is guaranteed to be unique (except for the order that it is in.)

    //NOTE: Euclidean distance between two points P1(x1, y1) and P2(x2, y2) is sqrt((x1-x2)2 + (y1-y2)2 ).
    internal class BClosestPointsToOrigin
    {
        // As we know we we are calculating the distance with 0,0, so whenever we are calculating distance from Euclidean Equation
        // one of the coordiante will be 0,0, so sqrt((x1-x2)2 + (y1-y2)2 ) => sqrt((x1-0)^2 + (y1-0)^2 )=> sqrt((x1)^2 + (y1)^2 )
        // So we just need to sort the 2D matrix in ascending order but with this above equation and will give first B element
        // How do we sort the list with additional constraints as above equation, we use comparitor function
        public List<List<int>> solve(List<List<int>> A, int B)
        {
            // Sort the list using comparitor
            A.Sort((List<int> x, List<int> y)=> (x[0]*x[0]+x[1]*x[1]).CompareTo(y[0] * y[0] + y[1] * y[1]));
            List<List<int>> output= new List<List<int>>();
            for(int i = 0; i < B; i++)
            {
                output.Add(A[i]);
            }
            // return first B elements
            return output;
        }
    }
}
