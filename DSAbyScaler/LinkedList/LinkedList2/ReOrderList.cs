using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList2
{
    //Given a singly linked list A

    // A: A0 → A1 → … → An-1 → An
    //reorder it to:

    // A0 → An → A1 → An-1 → A2 → An-2 → … 
    //You must do this in-place without altering the nodes' values.
    //Example Input
    //Input 1:

    // A = [1, 2, 3, 4, 5]
    //Input 2:

    // A = [1, 2, 3, 4]


    //Example Output
    //Output 1:

    // [1, 5, 2, 4, 3]
    //Output 2:

    // [1, 4, 2, 3]


    //Example Explanation
    //Explanation 1:

    // The array will be arranged to [A0, An, A1, An-1, A2].
    //Explanation 2:

    // The array will be arranged to [A0, An, A1, An-1, A2].
    internal class ReOrderList
    {
        // As we can see, first node will connected to last, second node to second last etc.
        // So if we just find the middle node and reverse the linkedlist of second half, then we can connect 
        // first node of first LL with second node of second LL and so on.

        // find middle node, here we are including middle node in first LL even if it is odd or even.
        // example : 1->2->3->4, 2 is middle node, if it is 1->2->3->4->5, then 3 is middle node
        // so if we move our fast pointer like we used to do previously like fast !=null or fast.next !=null break, but by this
        // for even, middle node comes as 3.
        // So our fast pointer will work differently here.
        public ListNode middleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while(fast.next!=null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        // Normal reversal LL program
        public ListNode reverseLL(ListNode head)
        {
            ListNode nxt = null;
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                nxt=curr.next;
                curr.next = prev;
                prev = curr;
                curr = nxt;
            }
            return prev;
        }
        public ListNode reorderList(ListNode A)
        {
            // find the middle node
            ListNode middle = middleNode(A);
            // pass the middle node as head and reverse the LL from middle node to end
            // and return the new head after reversal
            ListNode head2 = reverseLL(middle.next);
            // break the first linkedlist from middle
            middle.next = null;
            ListNode head1 = A;
            while (head2 != null)
            {
                // store reversed ll head in temp
                ListNode temp = head2;
                // move to next so that next time its easier to get the next
                head2 = head2.next;
                // connect second LL head to first LL next pointer
                temp.next = head1.next;
                // now connect first ll head to second LL
                head1.next = temp;
                // move to head.next.next, as we have already temp, so move to temp.next
                head1 = temp.next;

            }
            return A;
        }
    }
}
