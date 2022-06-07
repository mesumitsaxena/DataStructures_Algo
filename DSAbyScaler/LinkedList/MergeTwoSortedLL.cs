using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    internal class MergeTwoSortedLL
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode h3 = new ListNode(-1);
            

            ListNode tail = h3;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }
            while (list1 != null)
            {
                tail.next = list1;
                list1 = list1.next;
                tail = tail.next;
            }
            while (list2 != null)
            {
                tail.next = list2;
                list2 = list2.next;
                tail = tail.next;
            }
            return h3.next;
        }
    }
}
