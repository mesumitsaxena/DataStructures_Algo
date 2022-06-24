using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList1
{
    //Given a sorted linked list, delete all duplicates such that each element appears only once.

    //Example Input
    //Input 1:

    // 1->1->2
    //Input 2:

    // 1->1->2->3->3


    //Example Output
    //Output 1:

    // 1->2
    //Output 2:

    // 1->2->3


    //Example Explanation
    //Explanation 1:

    // Each element appear only once in 1->2.
    internal class RemoveDuplicatesfromSortedLis
    {
        // Approach is, as List is sorted, we know all the duplicate elements will together.
        // So check each time if next is same, if yes then connect curr next to curr next to next,
        // but do not move curr to curr next, by this we will check again if still duplicate exist or not.
        // if they are not same then move curr to curr next
        public ListNode deleteDuplicates(ListNode A)
        {
            if (A == null || A.next == null) return A;
            ListNode curr = A;
            // check if curr or curr next is null, we will stop, because we will checking curr with curr next
            while(curr != null && curr.next != null)
            {
                // if they are same, then connect curr to next to next
                if (curr.val == curr.next.val)
                {
                    curr.next=curr.next.next;
                }
                //else move current to next
                else
                {
                    curr = curr.next;
                }
            }
            //return head
            return A;
        }
    }
}
