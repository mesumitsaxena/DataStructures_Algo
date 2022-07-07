using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList3
{
    //You are given two linked lists, A and B, representing two non-negative numbers.

    //The digits are stored in reverse order, and each of their nodes contains a single digit.

    //Add the two numbers and return it as a linked list.
    //Example Input
    //Input 1:


    // A = [2, 4, 3]
    //    B = [5, 6, 4]
    //    Input 2:


    // A = [9, 9]
    //    B = [1]


    //    Example Output
    //Output 1:


    // [7, 0, 8]
    //    Output 2:


    // [0, 0, 1]


    //    Example Explanation
    //Explanation 1:

    // A = 342 and B = 465.A + B = 807.
    //Explanation 2:

    // A = 99 and B = 1.A + B = 100.
    class ListNode1
    {
        public int val;
        public ListNode1 next;
        public ListNode1(int x) { this.val = x; this.next = null; }
    }
    internal class AddTwoNumbersAsLists
    {
        // As Lists are stored in reverse format, then we dont have woory about going right to left
        // Any carry will be added on the right
        // So we will first Add two numbers of head and check if number%10<10 then its fine so carry will be 0, else number=number%10 and carry=number/10
        // So create a node with (number+carry)%10.
        // Lets see the code in action
        // In order to skip few edge cases, lets take a dummy pointer
        public ListNode1 addTwoNumbers(ListNode1 A, ListNode1 B)
        {
            ListNode1 dummyHead = new ListNode1(-1);
            ListNode1 head = dummyHead;
            int carry = 0;
            while(A!=null && B != null)
            {
                int number=(A.val+B.val+carry);
                carry = number / 10;
                ListNode1 newNode = new ListNode1(number % 10);
                dummyHead.next = newNode;
                dummyHead = dummyHead.next;
                A = A.next;
                B = B.next;
            }
            while (A != null)
            {
                int number = (A.val + carry) ;
                carry = number / 10;
                ListNode1 newNode = new ListNode1(number % 10);
                dummyHead.next = newNode;
                dummyHead = dummyHead.next;
                A = A.next;
            }
            while (B != null)
            {
                int number = (B.val + carry) ;
                carry = number / 10;
                ListNode1 newNode = new ListNode1(number % 10);
                dummyHead.next = newNode;
                dummyHead = dummyHead.next;
                B = B.next;
            }
            if (carry > 0)
            {
                ListNode1 newNode = new ListNode1(carry);
                dummyHead.next = newNode;
                dummyHead = dummyHead.next;
            }
            return head.next;
        }
    }
}
