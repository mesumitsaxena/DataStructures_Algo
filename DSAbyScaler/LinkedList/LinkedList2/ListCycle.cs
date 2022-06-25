using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList2
{
    //Given a linked list, return the node where the cycle begins.If there is no cycle, return null.
    //Try solving it using constant additional space.
    //Example:
    //Input: 
    //                  ______
    //                 |     |
    //                 \/    |
    //        1 -> 2 -> 3 -> 4
    //Return the node corresponding to node 3. 
    internal class ListCycle
    {
        // So here we will use the concept of slow and fast pointer.
        // As we know fast runs as double speed as of slow, so if there is a cycle, slow and fast will definetly meet each other
        // at any point of time. because fast is runing as double speed and if there is cycle, maybe after 1 circle or many circle, they meet definetly
        // it is because suppose, slow and fast are both in cycle and in cycle there are 6 nodes,
        // now slow at 1 fast will be at 3, slow 2, fast 6, slow 3, fast will also be on 3, how is this happening, if we flatten the list.
        // when fast reach to N, slow reach to N/2, now when slow reach to N, fast will reach to 2N, right, but here there is cycle, so instead of 2N, fast will be at N only.
        // So we now know that if there is cycle, slow and fast will meet each other at any point, if they never met and fast becomes null or fast next becomes null, means there is no cycle
        // Now how do we know the start point of cycle?

        // Here is what we will do, After slow and fast meet together, take one pointer(slow) at head and another pointer(fast) at meeting point.
        // move these pointer with slow speed, they will again meet at starting point of Loop.
        // To know more how is above solution working?, refer readme file in this folder only
        public ListNode detectCycle(ListNode head)
        {
            if (head == null) return head;
            ListNode slow = head;
            ListNode fast = head;
            //move slow and fast pointers one with 1x and another with 2x speed. if they meet each other, cycle detected
            // this loop will terminate due to two reasons-
            // 1.) cycle detected so we will break the loop at that meeting point
            // 2.) if there is no cycle so fast or fast.next will be null
            while(fast!=null && fast.next != null)
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
            // check if slow and fast are not same means there is no cycle so return null.
            if (slow != fast) return null;
            //So place one pointer at head and another pointer is already at meeting point and move them with slow speed,
            //then they will again meet each other at starting point of loop.
            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            // loop will terminate when slow =fast and it means and of the pointer slow or fast is starting point of loop
            return slow;
        }
    }
}
