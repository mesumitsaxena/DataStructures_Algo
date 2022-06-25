using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList2
{
    //You are given a linked list that contains a loop.
    //You need to find the node, which creates a loop and break it by making the node point to NULL.
    //Input 1:


    //1 -> 2
    //^    |
    //| - - 
    //Input 2:

    //3 -> 2 -> 4 -> 5 -> 6
    //          ^         |
    //          |         |    
    //          - - - - - -


    //Example Output
    //Output 1:

    // 1 -> 2 -> NULL
    //Output 2:

    // 3 -> 2 -> 4 -> 5 -> 6 -> NULL
    internal class RemoveCyclefromLinkedList
    {
        //refer ListCycle.cs file to know more about how to detect cycle and the starting point
        // Now once we know the cycle and we just need to have a prev pointer when moving from meeting with slow speed.
        // when both pointer meet each other, just prev.next=null.
        public ListNode solve(ListNode head)
        {
            if (head == null) return head;
            ListNode slow = head;
            ListNode fast = head;
            //move slow and fast pointers one with 1x and another with 2x speed. if they meet each other, cycle detected
            // this loop will terminate due to two reasons-
            // 1.) cycle detected so we will break the loop at that meeting point
            // 2.) if there is no cycle so fast or fast.next will be null
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                // if slow and fast are same means cycle detected so break the loop as we will need the meeting point later
                if (slow == fast)
                {
                    break;
                }
            }
            // now check if there is no cycle, as loop might end due to fast or fast.next is null, so we will
            // check if slow and fast are not same means there is no cycle so return head as there is no cycle
            if (slow != fast) return head;
            //So place one pointer at head and another pointer is already at meeting point and move them with slow speed,
            //then they will again meet each other at starting point of loop.
            slow = head;
            // have one more pointer which will point to fast, as we want to track the last point before meeting point 
            // within cycle and fast pointer is within cycle. so assign fast to prev
            ListNode prev = fast;
            while (slow != fast)
            {
                prev = fast;
                slow = slow.next;
                fast = fast.next;
            }
            // loop will terminate when slow =fast and it means and of the pointer slow or fast is starting point of loop
            // Now break the loop by prev.next=null
            prev.next = null;
            return head;
        }
    }
}
