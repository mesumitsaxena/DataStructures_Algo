using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LinkedList.LinkedList3
{
    //Design and implement a data structure for Least Recently Used(LRU) cache.It should support the following operations: get and set.

    //get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    //set(key, value) - Set or insert the value if the key is not already present.When the cache reaches its capacity, it should invalidate the least recently used item before inserting the new item.
    //The LRUCache will be initialized with an integer corresponding to its capacity.Capacity indicates the maximum number of unique keys it can hold at a time.

    //Definition of "least recently used" : An access to an item is defined as a get or a set operation of the item. "Least recently used" item is the one with the oldest access time.

    //NOTE: If you are using any global variables, make sure to clear them in the constructor.

    //Example :

    //Input : 

    //        capacity = 2

    //        set(1, 10)
    //         set(5, 12)
    //         get(5)        returns 12
    //         get(1)        returns 10
    //         get(10)       returns -1
    //         set(6, 14)    this pushes out key = 5 as LRU is full.
    //         get(5) returns - 1
    internal class LRUCache
    {
        public class LRU
        {
            public int key;
            public int val;
            public LRU next;
            public LRU prev;
            public LRU(int key, int val)
            {
                this.key = key;
                this.val = val;
                this.next = null;
                this.prev = null;
            }
        }
        public LRU head;
        public LRU tail;
        public int capacity;
        public int size;
        public Dictionary<int, LRU> searchMap;
        //declare the values
        public LRUCache(int capacity)
        {
            head = new LRU(-1, -1);
            tail = new LRU(-1, -1);
            head.next = tail;
            tail.prev = head;
            this.capacity = capacity;
            size = 0;
            searchMap = new Dictionary<int, LRU>();
        }
        public int get(int key)
        {
            // if the element is accessed, it means it is recently used
            if (searchMap.ContainsKey(key))
            {
                LRU node = searchMap[key];
                // So if it is recently used than delete the node
                deleteNode(node);
                // and add it to the end
                addtoTail(node);
                return node.val;
            }
            return -1;
        }

        public void set(int key, int value)
        {
            // if key already exist in map, means this data already exists, so update its value
            // delete this node and it to the end(as it is the most recent node)
            if (searchMap.ContainsKey(key))
            {
                LRU node = searchMap[key];
                node.val = value;
                deleteNode(node);
                addtoTail(node);
            }
            // if it is a new key value pair
            else
            {
                // if size is equal to capacity, so delete the least recent node which is head.next (1st node)
                if (size == capacity)
                {
                    searchMap.Remove(head.next.key);
                    deleteNode(head.next);
                    size--;
                }
                // and create a new node and add it to the tail, maintain the map's key and node values as well
                LRU newNode = new LRU(key, value);
                addtoTail(newNode);
                searchMap.Add(key, newNode);
                size++;
            }

        }
        public void addtoTail(LRU node)
        {
            //connect new node prev to tail prev, so by this tail prev link is broken and new node is placed in between
            node.prev = tail.prev;
            // now tails prev will have new node as next node, so by tails prev to tail connection is broken
            tail.prev.next = node;
            // new node next is now tail
            node.next = tail;
            // tail's prev is now new node
            tail.prev = node;

        }
        public void deleteNode(LRU node)
        {
            // node prev next will no longer be current node instead it will be node's next
            node.prev.next = node.next;
            // current node next's prev will no longer be node instead it will be node's prev
            node.next.prev = node.prev;

        }
    }
}
