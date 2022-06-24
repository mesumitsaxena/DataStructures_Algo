using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList1
{
    //Given a linked list of integers, find and return the middle element of the linked list.

    //NOTE: If there are N nodes in the linked list and N is even then return the(N/2 + 1)th element.
    //Example Input
    //Input 1:

    // 1 -> 2 -> 3 -> 4 -> 5
    //Input 2:

    // 1 -> 5 -> 6 -> 2 -> 3 -> 4


    //Example Output
    //Output 1:

    // 3
    //Output 2:

    // 2


    //Example Explanation
    //Explanation 1:

    // The middle element is 3.
    //Explanation 2:

    // The middle element in even length linked list of length N is ((N/2) + 1)th element which is 2.
    internal class FindMiddleNode
    {
        // we can find middle element using slow and fast pointer technique
        // fast pointer will run as double as slow, so when fast will reach to N, slow will be at N/2, and that is our middle node
        public int solve(ListNode A)
        {
            ListNode slow = A;
            ListNode fast = A;
            // run both pointer till if fast becomes null(in case of odd nodes)
            // or fast.next becomes null(in case of even nodes)
            while(fast!=null && fast.next != null)
            {
                slow=slow.next;
                fast=fast.next.next;
            }
            return slow.val;
        }
    }
}
