using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList3
{
    //Given a linked list where every node represents a linked list and contains two pointers of its type:

    //Pointer to next node in the main list(right pointer)
    //Pointer to a linked list where this node is head (down pointer). All linked lists are sorted.
    //You are asked to flatten the linked list into a single list. Use down pointer to link nodes of the flattened list. The flattened linked list should also be sorted.

    //Example Input
    //Input 1:

    //   3 -> 4 -> 20 -> 20 ->30
    //   |    |    |     |    |
    //   7    11   22    20   31
    //   |               |    |
    //   7               28   39
    //   |               |
    //   8               39
    //Input 2:

    //   2 -> 4 
    //   |    |       
    //   7    11    
    //   |            
    //   7


    //Example Output
    //Output 1:

    // 3 -> 4 -> 7 -> 7 -> 8 -> 11 -> 20 -> 20 -> 20 -> 22 -> 28 -> 30 -> 31 -> 39 -> 39 
    //Output 2:

    // 2 -> 4 -> 7 -> 7 -> 11


    //Example Explanation
    //Explanation 1:

    // The return linked list is the flatten sorted list.
    class ListNode
    {
        public int val;
        public ListNode right, down;
        public ListNode(int x)
        {
            val = x;
            right = null;
            down = null;
        }
    }
    internal class FlattenLinkedList
    {
        // Here we will apply the concept of merging two LL, but important point is the order.
        // we need to merge sequencel LL and after merge keep it index 0 then 0 and 2 then keep it at 0 then 0 and 3 and keep it in 0 etc
        // why not the previous way like we did in merge K Sorted lists, its because we dont have lists stored in array
        // we are given with a head of LL and all other LL are connected. So cant take 0 and 6 or 1 and 5 etc.
        // So we have to go with sequencel approach, So if we apply recusrive approach, we can merge last list and store it in 2nd last
        // then again last 2 and store in 3rd last etc, that way we can merge or flatten the List
        // here we dont have to flatten the LL in horizontal manner, instead we have to do it in vertical manner

        //Lets write the code to merge two lists in vertical manner
        ListNode mergeVertical(ListNode head1, ListNode head2)
        {
            if (head1 == null || head2 == null) return null;

            ListNode dummyNode = new ListNode(-1);
            ListNode tail = dummyNode;
            while(head1!=null && head2 != null)
            {
                if (head1.val < head2.val)
                {
                    tail.down = head1;
                    tail = tail.down;
                    head1 = head1.down;
                }
                else
                {
                    tail.down = head2;
                    tail = tail.down;
                    head2 = head2.down;
                }
            }
            while (head1 != null)
            {
                tail.down = head1;
                tail = tail.down;
                head1 = head1.down;
            }
            while (head2 != null)
            {
                tail.down = head2;
                tail = tail.down;
                head2 = head2.down;
            }
            return dummyNode.down;
        }
        ListNode flatten(ListNode root)
        {
            // if root right is null, return the root
            // example : L1->L2->L3->L4, suppose we are L4 so L4 right is null, so return L4 to previous function call.
            // in previous function call root will be L3.
            if (root == null || root.right == null) return root;
            // here we will call this method till we found root right=null, then it will start giving us previous roots
            root.right = flatten(root.right);
            // as we know right is not null, so merge root and root right.
            // means merge L3 and L4 and store the head in L3
            root= mergeVertical(root, root.right);
            // return merged L3 to L2 which consist merge of L3 and L4
            return root;
        }
    }
}
