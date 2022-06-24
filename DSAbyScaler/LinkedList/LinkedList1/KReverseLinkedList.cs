using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList1
{
    //K reverse linked list
    //Given a singly linked list A and an integer B, reverse the nodes of the list B at a time and return the modified linked list.
    //Example Input
    //Input 1:

    // A = [1, 2, 3, 4, 5, 6]
    //    B = 2
    //Input 2:

    // A = [1, 2, 3, 4, 5, 6]
    //    B = 3


    //Example Output
    //Output 1:

    // [2, 1, 4, 3, 6, 5]
    //    Output 2:

    // [3, 2, 1, 6, 5, 4]


    //    Example Explanation
    //Explanation 1:

    // For the first example, the list can be reversed in groups of 2.
    //    [[1, 2], [3, 4], [5, 6]]
    // After reversing the K-linked list
    //    [[2, 1], [4, 3], [6, 5]]
    //Explanation 2:

    // For the second example, the list can be reversed in groups of 3.
    //    [[1, 2, 3], [4, 5, 6]]
    // After reversing the K-linked list
    //    [[3, 2, 1], [6, 5, 4]]
    internal class KReverseLinkedList
    {
        // here we have to reverse lists for every B eleemnts.
        // what we can do reverse first B elements, and before returning the prev, we can do the reversal for other using recusrion
        // here we can pass the curr pointer as head in the recursion function and then return prev
        // so by this before returning the prev, reverse all the other B elements and when curr becomes null means we reached at the end
        // then we can return null which will be pointing to the reveresed B elements lists curr's next
        // example : 1->2->3->4->5->6 and B=2 then we will do reversal recursively  as 1<-2 3<-4 5<-6
        // so 5 and 6 is reversed and then call the recusive function again with curr which is null it return null to previous function call
        // and head.next will be null, head was 5 which means 6->5->null from here prev will be return to previous fucntion call
        // prev was 6 here so 6 will be return to previous function which was 3<-4 and it will say head.next=returnred prev value (6), so i will be 4->3->6->5 etc.
        public ListNode reverseList(ListNode A, int B)
        {
            // if there is only one or no node then return same
            if (A == null || A.next==null) return A;
            // prepare previous, next and current pointer
            ListNode prev = null;
            ListNode nxt = null;
            ListNode curr = A;
            // Store the B value in K as we will use B in further recursion calls
            int k = B;
            // reverse the List
            while(k>1 && curr != null)
            {
                nxt = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nxt;
                k--;
            }
            // Connect head to previous using recusrion
            A.next = reverseList(curr, B);
            return prev;
        }
    }
}
