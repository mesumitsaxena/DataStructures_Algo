using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList3
{
    //Given a singly linked list A, determine if it's a palindrome.
    //Return 1 or 0, denoting if it's a palindrome or not, respectively.
    //Example Input
    //Input 1:

    //A = [1, 2, 2, 1]
    //    Input 2:

    //A = [1, 3, 2]


    //    Example Output
    //Output 1:

    // 1 
    //Output 2:

    // 0 
    class ListNodeP
    {
      public int val;
      public ListNodeP next;
      public ListNodeP(int x) { this.val = x; this.next = null; }
     }
    internal class PallindromicList
    {
        // Simple solution is divide the LinkedList from middle, reverse second half of the LinkedList
        // Now compare first half and second half node by node if any of the node not matched, return 0 else 1
        public ListNodeP reverse(ListNodeP root)
        {
            if (root == null || root.next == null) return root;
            ListNodeP prev = null;
            ListNodeP nxt = null;
            ListNodeP curr = root;
            while (curr != null)
            {
                nxt = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nxt;
            }
            return prev;
        }
        public int lPalin(ListNodeP A)
        {
            if (A == null) return 0;
            if (A.next == null) return 1;
            ListNodeP slow = A;
            ListNodeP fast = A;
            while(fast.next!=null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            ListNodeP head2 = reverse(slow.next);
            slow.next = null;
            while(A!=null && head2 != null)
            {
                if (A.val != head2.val)
                {
                    return 0;
                }
                A = A.next;
                head2 = head2.next;
            }
            return 1;
        }
    }
}
