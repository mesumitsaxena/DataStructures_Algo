using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList2
{
    //Sort a linked list, A in O(n log n) time using constant space complexity.
    //Example Input
    //Input 1:

    //A = [3, 4, 2, 8]
    //    Input 2:

    //A = [1]


    //    Example Output
    //Output 1:

    //[2, 3, 4, 8]
    //    Output 2:

    //[1]


    //    Example Explanation
    //Explanation 1:

    // The sorted form of[3, 4, 2, 8] is [2, 3, 4, 8].
    //Explanation 2:

    // The sorted form of[1] is [1].
    internal class SortLinkedList
    {
        // we will use merge sort technique
        // divide the LL from Middle, then sort the left side and right side and then merge.
        public ListNode sortList(ListNode A)
        {
            // return if only 1 node is there or no node is there
            if (A == null || A.next==null) return A;
            // find middle 
            ListNode middle = middleNode(A);
            // divide in two parts, middle will be part of 1st list
            ListNode nxt = middle.next;
            //break the connection between 1st and 2nd list
            middle.next = null;
            // merge sort on left list
            ListNode head1 = sortList(A);
            // merge sort on right list
            ListNode head2 = sortList(nxt);
            // merge both lists
            return mergeTwoLists(head1, head2);
        }
        public ListNode middleNode(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode slow = head;
            ListNode fast = head;
            while(fast.next!=null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public ListNode mergeTwoLists(ListNode A, ListNode B)
        {
            // Prepare dummy node
            ListNode h3 = new ListNode(-1);
            //create a tail reference, then we will take this tail pointer forward, as h3 will be needing at the end to return the head
            ListNode tail = h3;
            // while any of them is not null
            while (A != null && B != null)
            {
                // if A is smaller than attach A to h3.
                if (A.val < B.val)
                {
                    tail.next = A;
                    A = A.next;
                    tail = tail.next;
                }
                // if B is smaller, than attach B to h3
                else
                {
                    tail.next = B;
                    B = B.next;
                    tail = tail.next;
                }
            }
            // if A is still left than attach all nodes
            while (A != null)
            {
                tail.next = A;
                A = A.next;
                tail = tail.next;
            }
            // if B is still left than attach all the nodes of B
            while (B != null)
            {
                tail.next = B;
                B = B.next;
                tail = tail.next;
            }
            // return head of new LL, by h3.next
            return h3.next;
        }
    }
}
