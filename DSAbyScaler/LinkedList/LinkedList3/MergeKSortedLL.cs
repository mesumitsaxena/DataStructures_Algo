using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList3
{
    //Given a list containing head pointers of N sorted linked lists.
    //Merge these given sorted linked lists and return them as one sorted list.
    //Example Input
    //Input 1:

    // 1 -> 10 -> 20
    // 4 -> 11 -> 13
    // 3 -> 8 -> 9
    //Input 2:

    // 10 -> 12
    // 13
    // 5 -> 6


    //Example Output
    //Output 1:

    // 1 -> 3 -> 4 -> 8 -> 9 -> 10 -> 11 -> 13 -> 20
    //Output 2:

    // 5 -> 6 -> 10 -> 12 ->13


    //Example Explanation
    //Explanation 1:

    // The resulting sorted Linked List formed after merging is 1 -> 3 -> 4 -> 8 -> 9 -> 10 -> 11 -> 13 -> 20.
    //Explanation 2:

    // The resulting sorted Linked List formed after merging is 5 -> 6 -> 10 -> 12 ->13.
    internal class MergeKSortedLL
    {
        // Approach is we have to merge lists in chunk of 2. for example : if we have 6 lists, then merge a pair then another pair etc
        // once that is completed, again merge rest of lists using same technique.
        // In which order should we merge? take 1st and last as a pair, then 2nd and second last as another pair etc.
        // if we are left with only 1 head and not able to form a pair then  we will not merge.
        // In the end we will be left with 2 LL, then merge them and return.

        // In Detail: example we have 6 LL, we will merge index 0 and 5 and after merge store the head in index 0
        // same way merge index 1 and 4, after merge store the head in index 1
        // merge index 2 and 3 and store in 2. Now we are left with 3 LL.
        // after 1 iteration, we will again start with index 0, but last index will be 2, so it like if i=0 and j=5 then next j will be j/2=2
        // and so on.
        public ListNode1 mergeKLists(List<ListNode1> A)
        {
            // Initiaze your pointers to first and last
            int i = 0;
            int last = A.Count - 1;
            // if last is 0, means there is no lists left all the lists are merged
            while (last > 0)
            {
                // reinitialize i to 0 and j to last, we will always store merge LL to left side of the array.
                // after merginng LL with inde 0 and 5, we will store the merge list to 0.
                // So for the next iteration, we will again start with zero, thats why i=0
                i = 0;
                int j = last;
                // if i>j means we have considered all the pairs, if i==j(means odd list) means same LL so skip that
                while (i < j)
                {
                    // merge 0 to 5 and store it in 0, merge 1 and 4 and store it back in 1 etc
                    A[i] = mergeLL(A[i], A[j]);
                    i++;
                    j--;
                }
                // if all pairs are formed, then reset last to j
                // example: i=0, j=5, t=1, j=4, i=2, j=3, now i=3 and j=2 dont execute the loop
                // now when i=0 and j=5, merge and store in 0.
                // i=1 and j=4, merge and store in 1
                // i=2 and j=3, merge and store in 2
                // i=3, j=2, false condition do not execute loop
                // So all pairs are merged and new lists are stored in 0 to 2, so that is why we are resetting
                // last to j
                if (i >= j)
                {
                    last = j;
                }
            }
            // at the end ony list will be available, so return 0
            return A[0];
        }
        public ListNode1 mergeLL(ListNode1 head1, ListNode1 head2)
        {
            if (head1 == null || head2 == null) return null;
            //Create a dummy pointer
            ListNode1 dummyHead = new ListNode1(-1);
            //maintain Tail pointer to move forward
            ListNode1 tail = dummyHead;
            // maintain head pointers of both LL
            ListNode1 tempHead1 = head1;
            ListNode1 tempHead2 = head2;
            // if any of the list is empty stop right there
            while(tempHead1!=null && tempHead2 != null)
            {
                // if head1 is smaller than head2, then head1 should be included
                // for that, attach head1 to tail
                // move forward in tail so that you can attach more element to it
                // also head 1 node is considered and attach, move forward
                if (tempHead1.val < tempHead2.val)
                {
                    tail.next = tempHead1;
                    tail = tail.next;
                    tempHead1 = tempHead1.next;
                }
                //else do the same thing for head2
                else
                {
                    tail.next = tempHead2;
                    tail = tail.next;
                    tempHead2 = tempHead2.next;
                }
            }
            // if any of the head is still left with nodes, then attach those nodes to tail
            while (tempHead1 != null)
            {
                tail.next = tempHead1;
                tail = tail.next;
                tempHead1 = tempHead1.next;
            }
            while (tempHead2 != null)
            {
                tail.next = tempHead2;
                tail = tail.next;
                tempHead2 = tempHead2.next;
            }
            // return head of new LL, as dummy node is dummy and has value -1, adummynode.next has actual head
            return dummyHead.next;
        }
    }
}
