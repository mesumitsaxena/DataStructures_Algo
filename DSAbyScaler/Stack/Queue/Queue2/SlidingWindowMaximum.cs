using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Queue.Queue2
{
    //Given an array of integers A.There is a sliding window of size B, moving from the very left of the array to the very right. You can only see the B numbers in the window. Each time the sliding window moves rightwards by one position. You have to find the maximum for each window.

    //Return an array C, where C[i] is the maximum value in the array from A[i] to A[i+B-1].

    //Refer to the given example for clarity.

    //NOTE: If B > length of the array, return 1 element with the max of the array.
    //Example Input
    //Input 1:

    // A = [1, 3, -1, -3, 5, 3, 6, 7]
    //    B = 3
    //Input 2:

    // A = [1, 2, 3, 4, 2, 7, 1, 3, 6]
    //    B = 6


    //Example Output
    //Output 1:

    // [3, 3, 5, 5, 6, 7]
    //    Output 2:

    // [7, 7, 7, 7]


    //    Example Explanation
    //Explanation 1:

    // Window position     | Max
    // --------------------|-------
    // [1 3 -1] -3 5 3 6 7 | 3
    // 1 [3 -1 -3] 5 3 6 7 | 3
    // 1 3 [-1 -3 5] 3 6 7 | 5
    // 1 3 -1 [-3 5 3] 6 7 | 5
    // 1 3 -1 -3 [5 3 6] 7 | 6
    // 1 3 -1 -3 5 [3 6 7] | 7
    //Explanation 2:

    // Window position     | Max
    // --------------------|-------
    // [1 2 3 4 2 7] 1 3 6 | 7
    // 1 [2 3 4 2 7 1] 3 6 | 7
    // 1 2 [3 4 2 7 1 3] 6 | 7
    // 1 2 3 [4 2 7 1 3 6] | 7
    internal class SlidingWindowMaximum
    {
        // How can we find the maximum element in a given window? We might have to iterate and check in the window for max.
        // but this will take O(N*B).
        // If we take tree map or ordered map, then we can easily accompish the task but in O(N*logB) which is better.
        // do we have any other thing?
        // Lets understand the below approach from an example:
        // 1, 3, -1, -3, 5, 3, 6, 7, B=3
        // Suppose we have a box and we will put the elements in the box and it will give us max whenever we want in this case when window is full.
        // put 1 in the box, window is not yet completed so insert another element, now 3 comes. we have {1} in the box.
        // if 3 is there will 1 can ever be maximum for any window coming forward?
        // No, so remove 1 from left and insert 3. now box is {3}
        // now -1 comes, can we have -1 as maximum for any window coming forward? Yes it can be,
        // suppose after -1 we have -3 and -2, then in a window of 3, -1 will be max among -1,-2,-3.
        // So we will add -1 in the box at the end and do not delete anything, now box is {3,-1}
        // Window size is also completed, So return the max by giving left value of the box.
        // here we are kidn of creating DS in descending order.
        // now next window switch, for next window, previous window left element has to go, so 1 will be out
        // and -3 will enter.
        // we will check 1 is already out So dont do anything, but we have to add -3 in the box
        // can we add -3 in the box, we will check the right eleemnt which is -1, and -3 is more lesser than that, so we can add as this -3 can be max for any other window
        // next window, 3 will be out and 5 will be added, before adding 5, we see, there is -3 and -1 already in box
        // Can -1 and -3 be maximum for any other window if 5 is there in the window? No 5 is greater than -3 and -1.
        // So add 5 in the box on the right but before that remove -1 and -3, and max for this window will be 5.
        // and So on.
        // Do we have any DS byt which we can add in the end, access the end and delete from end?
        // Also we can add in front, delete from front and access from front?
        // We have Array, but deleting from front and adding in front is very costly.
        // We have Stack, but we can only access, delete and add from end.
        // we have queue, we can only access front, delete front, and add from rear.
        // So none of the DS is usefull here, What we can do is create our own custom DS.
        // most usefull DS for this scenario is Queue, but if add more functionality to it like insert from front.
        // delete from rear and access rear, our job is done.
        // we can do it using DEQUE ( Double Ended Queue). refer Deque.cs for its implementation

        public List<int> slidingMaximum(List<int> A, int B)
        {
            List<int> result = new List<int>();
            // take a box which is Queue
            Deque deque = new Deque();
            // create a window and store the elements
            for (int i = 0; i < B; i++)
            {
                while (deque.Size > 0 && deque.PeekRear() < A[i])
                {
                    deque.DequeueRear();
                }
                deque.EnqueueRear(A[i]);
            }
            result.Add(deque.PeekFront());
            for(int i = B; i < A.Count; i++)
            {
                // remove the last element from the window
                if (deque.Size > 0 && deque.PeekFront() == A[i - B])
                {
                    deque.DequeueFront();
                }
                // Add the next eleemnt in the window, but if rear is lesser than remove that eleemnt from rear first
                while (deque.Size > 0 && deque.PeekRear() < A[i])
                {
                    deque.DequeueRear();
                }
                deque.EnqueueRear(A[i]);
                
                result.Add(deque.PeekFront());
            }
            return result;
        }
    }
}
