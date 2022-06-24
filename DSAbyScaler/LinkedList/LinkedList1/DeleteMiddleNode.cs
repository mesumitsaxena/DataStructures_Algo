using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList1
{
    //Given a singly linked list, delete middle of the linked list.

    //For example, if given linked list is 1->2->3->4->5 then linked list should be modified to 1->2->4->5

    //If there are even nodes, then there would be two middle nodes, we need to delete the second middle element.

    //For example, if given linked list is 1->2->3->4->5->6 then it should be modified to 1->2->3->5->6.

    //Return the head of the linked list after removing the middle node.

    //If the input linked list has 1 node, then this node should be deleted and a null node should be returned.

    //Definition for singly-linked list.
    class ListNode
    { 
        public int val;
        public ListNode next;
        public ListNode(int x) { this.val = x; this.next = null; }
    }

    internal class DeleteMiddleNode
    {
        // Using Slow and Fast pointers, we will be able to find the middle node,
        // but knowing middle node is not sufficient to delete the node.
        // because inorder to delete a particular node, we should be able to link previous node of middle node to next node of middle node
        // by this we break the link and delete the middle node.
        // So by slow pointer we will be able to know the middle node, we still need to know the prev node so that we can break and make a new connection
        // So we will take prev pointer as well
        public ListNode solve(ListNode A)
        {
            // if we have no node and 1 node then return null
            if (A == null || A.next == null) return null;
            //define slow, fast and prev node
            ListNode slow = A;
            ListNode fast = A;
            ListNode prev = null;
            while(fast!=null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            // after fast reached to null, slow reached to middle, and prev reached to prev of middle
            // so just make connection as prev next will be middle's next which means slows next
            prev.next = slow.next;
            return A;
        }
    }
}
