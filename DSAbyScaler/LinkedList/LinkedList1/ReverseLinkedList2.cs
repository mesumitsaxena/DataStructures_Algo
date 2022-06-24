using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList1
{
    //Reverse a linked list A from position B to C.

    //NOTE: Do it in-place and in one-pass.
    //Example Input
    //Input 1:

    // A = 1 -> 2 -> 3 -> 4 -> 5
    // B = 2
    // C = 4

    //Input 2:

    // A = 1 -> 2 -> 3 -> 4 -> 5
    // B = 1
    // C = 5


    //Example Output
    //Output 1:

    // 1 -> 4 -> 3 -> 2 -> 5
    //Output 2:

    // 5 -> 4 -> 3 -> 2 -> 1


    //Example Explanation
    //Explanation 1:

    // In the first example, we want to reverse the highlighted part of the given linked list : 1 -> 2 -> 3 -> 4 -> 5 
    // Thus, the output is 1 -> 4 -> 3 -> 2 -> 5 
    //Explanation 2:

    // In the second example, we want to reverse the highlighted part of the given linked list : 1 -> 4 -> 3 -> 2 -> 5  
    // Thus, the output is 5 -> 4 -> 3 -> 2 -> 1 
    internal class ReverseLinkedList2
    {
        // here, we have to apply the same concept of reversing the LL, but we have to reverse it from B to C
        // in order to reach to B, we have to iterate and move.
        // Now for reversal we need three pointers, curr, nxt and prev.
        // Curr and nxt we can maintain, but prev pointer we have to maintain while traversing till B,
        // because while reversing complete Linked List, we keep prev as null because we start with first node, but here prev will pointing to prev to B position
        // Now when we apply the same concept of reversal to B to C, prev will connecting to curr
        // example: 1->5->3->9->4->8, say B=2, C=4, So after reversal 1->9->3->5->4->8 so prev will be on 1 and after reversal curr will come to 4.
        // few extra info we have to store, one prev which will be fix will stay on 1, another prev will run along in order to reverse the linkedlist, so after reversal
        // 9 will be running prev and 4 will be curr, now we will connect prev to running prev.
        // Also same way we will have curr and running curr, curr will stay on 5 and running curr will run along while reversing
        // So after reversal, curr will be 5 and running current will be on 4 so just connect them.
        // If starting point is 1st index itself, do not connect prev to running prev, because prev will be null and it will give exception
        public ListNode reverseBetween(ListNode A, int B, int C)
        {
            if (A == null) return null;
            // if we have only one element, return the element
            if(A.next == null) return A;
            // Define prev and Curr pointers which will stay once we reach B position
            ListNode prev = null;
            ListNode curr = A;
            // Total length to reverse
            int lengthtoReverse = C - B + 1;
            //Define start index as we will work on it and we do not want to loose its actual value which will be helpfull in future
            int startIndex = B;
            // Iterate on LL and get the curr and prev value in order to start the reversal
            while(curr!=null && startIndex > 1)
            {
                prev = curr;
                curr = curr.next;
                startIndex--;
            }
            // define running curr and running prev as prev and curr will be stay fixed here in order to make connections
            // after LL reversal
            ListNode runningCurr = curr;
            ListNode runningPrev = prev;
            ListNode nxt = null;
            // Reverse the LL with either running curr is null or length is completed 
            while(runningCurr!=null && lengthtoReverse > 0)
            {
                nxt = runningCurr.next;
                runningCurr.next = runningPrev;
                runningPrev = runningCurr;
                runningCurr = nxt;
                lengthtoReverse--;
            }
            // if start point is not first position then connect prev to running prev
            // example: 3->1->2->4->5, if B=1 and C=3, then 3 will be prev and after reversal 4 will be running prev
            // so linkedlist will be like 3 1<-2<-4 5 so in order to connect 3 to 4 we will connect prev to current prev
            if (B > 1) { prev.next = runningPrev; }
            // if Starting point is first position then we cant connect prev to running prev because prev will be null
            else { A = runningPrev; }
            // in above example only 1 is curr and 5 will be running current so connect 1 to 5 by curr.next=runningcurrent
            curr.next = runningCurr;
            return A;
        }
    }
}
