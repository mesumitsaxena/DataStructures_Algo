using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList1
{
    //Given a linked list A, remove the B-th node from the end of the list and return its head.

    //For example, Given linked list: 1->2->3->4->5, and B = 2.After removing the second node from the end, the linked list becomes 1->2->3->5.

    //NOTE: If B is greater than the size of the list, remove the first node of the list.

    //NOTE: Try doing it using constant additional space.
    //Example Input
    //Input 1:

    //A = [1, 2, 3, 4, 5]
    //    B = 2
    //Input 2:

    //A = [1]
    //    B = 1


    //Example Output
    //Output 1:

    //[1, 2, 3, 5]
    //    Output 2:

    // []


    //    Example Explanation
    //Explanation 1:

    //In the first example, 4 is the second last element.
    //Explanation 2:

    //In the second example, 1 is the first and the last element.

    internal class RemoveNthNodefromLL
    {
        // Simple solution is count total number of nodes and then total-B, will give me the position of node which needed
        // to be deleted from start
        // This is already mentioned in the question that if B is greater than A lenght then remove first node(A)
        public ListNode removeNthFromEnd(ListNode A, int B)
        {
            // if A is null or next is null then return because if single element is there after deletion it will be null
            if (A == null || A.next == null) return null;
            //Count all the elements
            int count = 0;
            ListNode temp = A;
            while (temp != null)
            {
                temp = temp.next;
                count++;
            }
            //calculate index from start to delete the node
            int indexfromstart = count - B;
            if (B >= count)
            {
                A = A.next;
                return A;
            }
            // decalre previous pointer inorder to maintain previous node when found node to be deleted
            // So that we can easily link the node after found node
            ListNode prev = null;
            temp = A;
            while (indexfromstart > 0 && temp != null)
            {
                prev = temp;
                temp = temp.next;
                indexfromstart--;
            }
            //connect prev node to next of deleted node
            prev.next = temp.next;
            return A;
        }
    }
}
