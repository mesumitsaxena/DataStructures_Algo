package Heaps.Heaps2;

import java.util.*;

//Given a list containing head pointers of N sorted linked lists.
//        Merge these given sorted linked lists and return them as one sorted list.
//Example Input
//        Input 1:
//
//        1 -> 10 -> 20
//        4 -> 11 -> 13
//        3 -> 8 -> 9
//        Input 2:
//
//        10 -> 12
//        13
//        5 -> 6
//
//
//        Example Output
//        Output 1:
//
//        1 -> 3 -> 4 -> 8 -> 9 -> 10 -> 11 -> 13 -> 20
//        Output 2:
//
//        5 -> 6 -> 10 -> 12 ->13
//
//
//        Example Explanation
//        Explanation 1:
//
//        The resulting sorted Linked List formed after merging is 1 -> 3 -> 4 -> 8 -> 9 -> 10 -> 11 -> 13 -> 20.
//        Explanation 2:
//
//        The resulting sorted Linked List formed after merging is 5 -> 6 -> 10 -> 12 ->13.
  class ListNode {
      public int val;
      public ListNode next;
      ListNode(int x) { val = x; next = null; }
  }
  class LinkedListComparator implements Comparator<ListNode>{

      @Override
      public int compare(ListNode o1, ListNode o2) {
          return o1.val-o2.val;
      }
  }
  //We have already solved this question in LinkedList session
  // Lets solve this using different approach
  // we have to first take the minimum out of all the LinkedList.
  // we can get that from head of the LL as all LL are sorted
  // So we can easily check the minimum by looking at all LL's head
  // Now, we can take that min out and move the index or move the pointer to next from the LL from which we took min
  // repeat this process (Compare each head value from LL)
  // Comparing each head value from LL will take O(N^2) time complexity
  // we need some DS from which we can get the min node in minimum TC.
  // we can take min heap from which we can take min node in logn time
  // So we can insert all the heads of all the LL in min heap
  // take the min node out, attach it with dummy node head, and insert minnode.next in min heap
  // continue this process untill min heap is not empty
public class MergeKSortedLinkedLists {
    public ListNode mergeKLists(ArrayList<ListNode> a) {
        PriorityQueue<ListNode> pQ= new PriorityQueue<>(new LinkedListComparator());
        for(int i=0;i<a.size();i++){
            pQ.offer(a.get(i));
        }
        ListNode head= new ListNode(-1);
        ListNode tail=head;
        while(pQ.size()>0) {
            ListNode minLL = pQ.poll();
            if(minLL.next!=null){
                pQ.offer(minLL.next);
            }
            tail.next = minLL;
            tail=tail.next;
        }
        return head.next;
    }
}
