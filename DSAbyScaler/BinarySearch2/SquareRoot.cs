using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch2
{
    //Given an integer A.

    //Compute and return the square root of A.

    //If A is not a perfect square, return floor(sqrt(A)).

    //DO NOT USE SQRT FUNCTION FROM THE STANDARD LIBRARY.

    //NOTE: Do not use the sqrt function from the standard library.Users are expected to solve this in O(log(A)) time.
    internal class SquareRoot
    {
        // brute force way is start a number say i with 1 and say i*i<=N or not, if yes go on increment i
        // ex: 56
        // i=1 i*i = 1*1 < =56 so 1 can be my answer
        // i=2 i*i = 2*2 <=56 so 2 can be my answer
        // i=3 i*i = 3*3 < =56 so 3 can be my answer
        // i=4 i*i = 4*4 <=56 so 4 can be my answer
        // i=5 i*i = 5*5 < =56 so 5 can be my answer
        // i=6 i*i = 6*6 <=56 so 6 can be my answer
        // i=7 i*i = 7*7 < =56 so 7 can be my answer
        // i=8 i*i = 8*8 >56 so 8 cannt be my answer
        // SO we can say answer is 7
        // how do I define the upper limit, upper limit can be N, we will always find the answer before we reach to N
        // so this O(SquaerootN) Approach, we want logn approach

        // Instead of checking our answer linearly, lets check the answer by binary search,
        // example - say 1 to 56 mid=28, is 28*28<=56, no so can anything after 28 can be my answer? no becasue 
        // any number greater than 28 will give more higher value
        // so we will look at left side of the answer means r=mid-1
        // suppose mid=4, then 4*4<=56 , we can say 4 can be my answer but there will be better answer as we know answer is 7
        // so we will store the current answer and look for better answer on right hand side

        public int sqrt(int A)
        {
            //define search space
            int left = 1;
            int right = A;
            //initialize sqrt=0
            int sqrt = 0;
            while (left < right)
            {
                
                int mid=(left+right)/2;
                // if mid*mid==A, return mid, that is the square root
                if (A == mid * mid) return mid;
                // if mid*mid>A then no other value after mid wll be answer, so check in left side
                else if(A<mid*mid) { right = mid - 1; }
                //if mid*mid<A it means, this can be answer, but check for better answer on right side
                else { sqrt = mid; left = mid + 1; }
            }
            //return sqrt
            return sqrt;
        }
    }
}
