using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList2
{
    //Merge two sorted linked lists, A and B, and return it as a new list.

    //The new list should be made by splicing together the nodes of the first two lists and should also be sorted.
    //Example Input
    //Input 1:

    // A = 5 -> 8 -> 20
    // B = 4 -> 11 -> 15
    //Input 2:

    // A = 1 -> 2 -> 3
    // B = Null


    //Example Output
    //Output 1:

    // 4 -> 5 -> 8 -> 11 -> 15 -> 20
    //Output 2:

    // 1 -> 2 -> 3
    internal class MergeTwoSortedList
    {
        // Its same as Merging two sorted Lists.
        // The nodes are sorted so we will have the node which is smaller first and move that pointer.
        // exactly like with merge List, but here we have LL, so we will move the head pointer to next.
        // here we will use dummy node pointer technique, by this we will be skipping many edge cases, like if A is null or B is null etc

        public ListNode mergeTwoLists(ListNode A, ListNode B)
        {
            // Prepare dummy node
            ListNode h3 = new ListNode(-1);
            //create a tail reference, then we will take this tail pointer forward, as h3 will be needing at the end to return the head
            ListNode tail = h3;
            // while any of them is not null
            while(A!=null && B != null)
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
