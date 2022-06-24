using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList1
{
    //You are given a singly linked list having head node A. You have to reverse the linked list and return the head node of that reversed list.

    //NOTE: You have to do it in-place and in one-pass.
    //Example Input
    //Input 1:

    // A = 1 -> 2 -> 3 -> 4 -> 5 -> NULL
    //Input 2:

    // A = 3 -> NULL


    //Example Output
    //Output 1:

    // 5 -> 4 -> 3 -> 2 -> 1 -> NULL
    //Output 2:

    // 3 -> NULL


    //Example Explanation
    //Explanation 1:

    // The linked list has 5 nodes.After reversing them, the list becomes : 5 -> 4 -> 3 -> 2 -> 1 -> NULL
    //Expalantion 2:

    // The linked list consists of only a single node.After reversing it, the list becomes : 3 -> NULL
    internal class ReverseLinkedList
    {
        // In Order to reverse the linkedlist, we have to break the links and connect them in reverse manner.
        // how can we do it?
        // maintain three pointers, nxt, prev and curr. store the curr-> next in nxt, connect curr to prev
        // now make curr a prev(prev=curr) and we already stored the next value as curr, so curr=nxt
        // example: 1->2->3->4
        // so prev is null, curr as 1 and nxt as null
        // now store 2 in nxt, connect 1 to prev, make 1 prev(prev=1) and now curr=2(nxt)
        // now store 3(curr.next) in nxt. connect 2(curr)->1(prev). make 2 as prev(prev=2) and make curr=3(nxt) and so on 
        public ListNode reverseList(ListNode A)
        {
            ListNode prev = null;
            ListNode nxt = null;
            ListNode curr = A;
            while(curr != null)
            {
                // store nxt information so that in next iteration we can make it curr
                nxt = curr.next;
                // break the existing connection, and connect it to prev(reversal happens here)
                curr.next = prev;
                // make curr a pev, because curr is going to change so store it in prev in order to connect to prev in next iteration
                prev = curr;
                // current will be next
                curr = nxt;
            }
            // at the end, last node will prev, because curr will become null.
            return prev;
        }
    }
}
