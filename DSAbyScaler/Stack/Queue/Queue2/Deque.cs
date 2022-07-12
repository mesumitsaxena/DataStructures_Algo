using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Queue.Queue2
{
    // Deque is the Double ended Queue.
    // we can access front and rear in deque
    // we can insert and delete the data from front and rear
    // How can we do that?
    // We can take Doubly LinkedList.
    // we can maintain head and tail pointer.
    // by this we will be able to access front and rear
    // we can easily insert and delete the data from front and rear.
    public class DequeDLL
    {
        public int val { get; set; }
        public DequeDLL Next { get; set; }
        public DequeDLL prev { get; set; }
        public DequeDLL(int val)
        {
            this.val = val;
            this.Next = null;
            this.prev = null;
        }
    }
    internal class Deque
    {
        public DequeDLL head;
        public DequeDLL tail;
        public int Size;

        public Deque()
        {
            head = new DequeDLL(-1);
            tail = new DequeDLL(-1);
            head.Next = tail;
            tail.prev = head;
            Size = 0;
        }
        public void EnqueueRear(int val)
        {
            DequeDLL temp= new DequeDLL(val);
            temp.Next = tail;
            tail.prev.Next = temp;
            temp.prev = tail.prev;
            tail.prev = temp;
            Size++;
        }
        public void EnqueueFront(int val)
        {
            DequeDLL temp = new DequeDLL(val);
            head.Next.prev = temp;
            temp.Next = head.Next;
            head.Next = temp;
            temp.prev = head;
            Size++;
        }
        public int DequeueFront()
        {
            if (Size>0)
            {
                int front = head.Next.val;
                head.Next.Next.prev = head;
                head.Next = head.Next.Next;
                Size--;
                return front;
            }
            return -1;            
        }
        public int DequeueRear()
        {
            if (Size > 0)
            {
                DequeDLL node = tail.prev;
                node.prev.Next = tail;
                tail.prev = node.prev;
                Size--;
                return node.val;
            }
            return -1;
        }
        public int PeekRear()
        {
            if (Size > 0)
            {
                return tail.prev.val;
            }
            return -1;
        }
        public int PeekFront()
        {
            if (Size > 0)
            {
                return head.Next.val;
            }
            return -1;
        }
    }
}
