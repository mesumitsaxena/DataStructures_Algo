using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Queue.Queue2
{
    //Given an array A of both positive and negative integers.

    //Your task is to compute the sum of minimum and maximum elements of all sub-array of size B.

    //NOTE: Since the answer can be very large, you are required to return the sum modulo 109 + 7.



    //Problem Constraints
    //1 <= size of array A <= 105

    //-109 <= A[i] <= 109

    //1 <= B <= size of array
    //        Example Input
    //Input 1:

    // A = [2, 5, -1, 7, -3, -1, -2]
    // B = 4
    //Input 2:

    // A = [2, -1, 3]
    // B = 2


    //Example Output
    //Output 1:

    // 18
    //Output 2:

    // 3


    //Example Explanation
    //Explanation 1:

    // Subarrays of size 4 are : 
    //    [2, 5, -1, 7], min + max = -1 + 7 = 6
    //    [5, -1, 7, -3], min + max = -3 + 7 = 4
    //    [-1, 7, -3, -1], min + max = -3 + 7 = 4
    //    [7, -3, -1, -2], min + max = -3 + 7 = 4
    //    Sum of all min & max = 6 + 4 + 4 + 4 = 18
    //Explanation 2:

    // Subarrays of size 2 are : 
    //    [2, -1], min + max = -1 + 2 = 1
    //    [-1, 3], min + max = -1 + 3 = 2
    //    Sum of all min & max = 1 + 2 = 3
    internal class SumofMaxMinusMin
    {
        // it is the same question as Sliding window maximum, only thing is we have to add Max+Min in result set.
        // So in order to get the max from each subarray of length B, we used deque.
        // but here we have to find max + min, So here we will have 2 deque.
        public int solve(List<int> A, int B)
        {
            int m = 1000000007;
            long result = 0;
            Deque deque1 = new Deque();
            Deque deque2 = new Deque();
            for(int i = 0; i < B; i++)
            {
                while(deque1.Size>0 && deque1.PeekRear() < A[i])
                {
                    deque1.DequeueRear();
                }
                deque1.EnqueueRear(A[i]);
                
                while(deque2.Size>0 && deque2.PeekRear() > A[i])
                {
                    deque2.DequeueRear();
                }
                deque2.EnqueueRear(A[i]);
                
            }
            long max = deque1.PeekFront() ;
            long min = deque2.PeekFront() ;
            result = (result % m + max % m + min % m + m) % m;
            for (int i = B; i < A.Count; i++)
            {
                //remove last window element from front
                
                while (deque1.Size > 0 && deque1.PeekRear() < A[i])
                {
                    deque1.DequeueRear();
                }
                deque1.EnqueueRear(A[i]);

                
                while (deque2.Size > 0 && deque2.PeekRear() > A[i])
                {
                    deque2.DequeueRear();
                }
                deque2.EnqueueRear(A[i]);
                if (deque1.Size > 0 && deque1.PeekFront() == A[i - B])
                {
                    deque1.DequeueFront();
                }
                if (deque2.Size > 0 && deque2.PeekFront() == A[i - B])
                {
                    deque2.DequeueFront();
                }

                long max1 = deque1.PeekFront();
                long min1 = deque2.PeekFront();
                result = (result % m + max1 % m + min1 % m + m) % m;
            }
            return (int)result;
            
        }
    }
}
