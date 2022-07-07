using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList3
{
    //A linked list A is given such that each node contains an additional random pointer which could point to any node in the list or NULL.

    //Return a deep copy of the list.
    //Example Input
    //Given list
    //   1 -> 2 -> 3
    //with random pointers going from
    //  1 -> 3
    //  2 -> 1
    //  3 -> 1



    //Example Output
    //   1 -> 2 -> 3
    //with random pointers going from
    //  1 -> 3
    //  2 -> 1
    //  3 -> 1



    //Example Explanation
    //You should return a deep copy of the list.The returned answer should not contain the same node as the original list, but a copy of them.The pointers in the returned list should not link to any node in the original input list.

    public class RandomListNode
    {
        public int label;
        public RandomListNode next, random;
        public RandomListNode(int x) { this.label = x; }
    };

    internal class CopyList
    {
        /* ###### HashMap Approach ###### Store old node and new node in hm.
        then look for the random value of the current node it will contain its associated random node.
        Ex: 10->2->15 and 10 is connected to 15 as random pointer.
        Now we will create new node 10->2->15 also maintain hashmap while creating this list, how?
        when create a new node store old node as key and new node as value.
        Now iterate again on old list check for its random value in hashmap, example curr=10, its random is 15
        so curr.random is 15 hm[curr.random] will have new node of 15 as value for key 15, by this we will attach.
        see below code for complete understanding.*/
        public RandomListNode copyRandomList_HashMapApproach(RandomListNode head)
        {
            // Create Hashmap to store old and corresponding new node addresses
            Dictionary<RandomListNode, RandomListNode> nodeMap = new Dictionary<RandomListNode, RandomListNode>();
            //create temp head pointer
            RandomListNode tempHead = head;
            //Create new Lists dummy node
            RandomListNode dummyhead = new RandomListNode(-1);
            // maintain the tail, so that we can move forward and dummyHead will keep the head of new List
            RandomListNode tail = dummyhead;
            // go till the end of LL
            while (tempHead != null)
            {
                // create a new List using old node value
                RandomListNode node = new RandomListNode(tempHead.label);
                //Connect dummy node to new created node
                tail.next = node;
                //move the pointer
                tail = tail.next;
                // Add old node which is temphead and new node which is node in map
                nodeMap.Add(tempHead, node);
                // move the pointer
                tempHead = tempHead.next;
            }
            // Now new List is created go back to its head
            tail = dummyhead.next;
            // go back to original list head
            tempHead = head;
            // while both of them are not null
            while (tempHead != null && tail != null)
            {
                // if Old list random is not null then only we have to make the connection in new node
                if (tempHead.random != null)
                {
                    // take the new node using hashmap, in map we will pass oldnode random pointer, it will give us
                    // new corresponding node which will be random pointer for new node
                    RandomListNode node = nodeMap[tempHead.random];
                    //connect random
                    tail.random = node;
                }
                //move both the pointers
                tail = tail.next;
                tempHead = tempHead.next;
            }
            return dummyhead.next;
        }
        // Optimized Approach, or we can say O(1) space complexity approach.
        /* If we are not allowed to use additional space then we can look for the options which we already have.
        So currently we have a node which has next and random pointer.
        Hashmap was giving the new node reference by old node, if we can some how point to old node to new node for
        each node.
        example - 10->8->15 old list and 10->15 random pointer
                  10->8->15 new list now we can somehow create a pointer from old 10 to new 10, old 8 to new 8 and so on
        then can directly get its random value, but can we use existing random pointer from class to make connection?
        No, because then we might lost connection of random pointers. But, Next pointer can be use to make connection between
        old node and new node.
        so - 
        10 8 15
        | /| /|
        10 8 15
        so by this we have access to old and new node also old node random access is also maintain.
        so above example can be written as 10-10-8-8-15-15
        so now if want new 10 to new 15 connection, we can say- curr10.next.random=curr10.random.next
        because new random will be after old random.
        */
        public RandomListNode copyRandomList_SpaceOptimizedApproach(RandomListNode head)
        {
            //Connect old and new nodes, then it is easy to find random from old, random for new will next to old's random
            // So it is easy to connect
            // First create new nodes and add in between old nodes
            RandomListNode tempHead = head;
            while (tempHead != null)
            {
                RandomListNode node = new RandomListNode(tempHead.label);
                node.next=tempHead.next;
                tempHead.next = node;
                tempHead = tempHead.next.next;
            }
            tempHead = head;
            while (tempHead != null)
            {
                //connect random if old lists have random
                if (tempHead.random != null)
                {
                    tempHead.next.random = tempHead.random.next;
                }
                tempHead = tempHead.next.next;
            }
            //now break the old and new lists
            tempHead = head;
            RandomListNode newHead = tempHead.next;
            RandomListNode tail = newHead;
            while (tempHead != null)
            {
                // connect old lists
                tempHead.next = tempHead.next.next;
                tempHead = tempHead.next;
                // if new old list is at null, then new list next is null, so for new list no next element so stop
                if (tempHead != null)
                {
                    tail.next = tail.next.next;
                    tail = tail.next;
                }
            }
            return newHead;
        }

    }
}
