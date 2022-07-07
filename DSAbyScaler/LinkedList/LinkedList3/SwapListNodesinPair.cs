using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList3
{
    //Given a linked list A, swap every two adjacent nodes and return its head.

    //NOTE: Your algorithm should use only constant space.You may not modify the
    //values in the list; only nodes themselves can be changed.
    //Example Input
    //Input 1:

    // A = 1 -> 2 -> 3 -> 4
    //Input 2:

    // A = 7 -> 2 -> 1


    //Example Output
    //Output 1:

    // 2 -> 1 -> 4 -> 3
    //Output 2:

    // 2 -> 7 -> 1


    //Example Explanation
    //Explanation 1:

    // In the first example(1, 2) and(3, 4) are the adjacent nodes.Swapping them will result in 2 -> 1 -> 4 -> 3
    //Explanation 2:


    //In the second example, 3rd element i.e. 1 does not have an adjacent node, so it won't be swapped.
    internal class SwapListNodesinPair
    {
        // If you see the question closely, its like reversing the LL after every 2 nodes, means Reverse the LL of the period of 2
        // We have already solve this problem by just reversing the LL of every chunk of 2 and when curr becomes null then 
        // connect its heads back with the help of recursion
        public ListNode1 swapPairs(ListNode1 A)
        {
            if (A == null || A.next==null) return A;
            ListNode1 prev = null;
            ListNode1 nxt = null;
            ListNode1 curr = A;
            int count = 2;
            while(count>0 && curr != null)
            {
                nxt = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nxt;
                count--;
            }
            //current head's next will be prev of next recusive call
            A.next = swapPairs(A);
            // it will return prev to previous recursive call which will be connected to previous head's next
            return prev;
        }
    }
}
