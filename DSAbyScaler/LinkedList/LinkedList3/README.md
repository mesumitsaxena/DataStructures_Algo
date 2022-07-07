## LRU Cache Implementation Details

**Problem Statement:**

We know what is cache and why it is been used.  Cache is kind of memory which is used for faster access. Cache is the memory which does not have larger capacity that is why they are faster in accessibility.
So we have to create a LRU Cache (Least Recent Used), whose major functionality is to provide the data quickly and store the data in LRU cache, now storing part is little complex-
As we know cache has limited capacity, so if the capacity is full of the cache, we will remove the item which is least recent used and then place the new data in cache.

**What is Least Recent Used?**

Suppose we have few stream of data coming, as 1 2 3 4. So in Cache 1, 2, 3, 4 is stored, now capacity of cache is 4 only now if 5 comes, than we will insert 5, but will remove least recent used data, which is 1. Now new data set is 2,3,4,5. There is one more scenario, suppose we have data as 1,2,3,4 and capacity is 5. Now new data came with the data as 2. As capacity is not yet full, should we place the data in cache? No. why? Its because 2 already exist in cache, but 2 came just now(recently). So we will remove 2 and place it in the end. So in 1 2 3 4 , 1 is representing least recent used data and 4 is represented as recently used data.

**Summary:**

-	So if incoming element exists in the cache, then delete the element and insert it again at the end of the data structure which we are going to use. 
-	If incoming element does not exists in the cache, then check if the capacity is full or not?
-	If the capacity is full the delete least recent used data (which is 1st element in cache) and then insert the data at the end
-	If capacity is not full then insert the data in the end.

![image](https://user-images.githubusercontent.com/83850703/175812456-ed8e8396-4325-4f09-ab82-b8dbf65547df.png)

**Implementation:**

So basic operations are Insert at end, delete and Search.

**Using Array:**  If we used array, what are its pros and cons-
-	Pros:
   1. As we know capacity of the cache is fixed so we can use a data structure with fixed memory.
   2. Inserting the data in the end is O(1)

-	Cons:
1.	Searching an element in array is O(N)
2.	Deleting the data is O(N) –We will get the data while searching(which is a separate method) but after deleting we have to shift all the elements

**Using SLL (Singly Linked List)-** If we use SLL, what are its Pros and Cons.
-	Pros:
1.	Inserting the data in the end is O(1), by maintaining tail pointer
2.	Deleting the data is O(1), how? First we search the data (which is a separate method) and then we will delete the data in O(1), we will not have to shift the data.
-	Cons:
1.	Searching an element in array is O(N)

**Note: As we can see, SLL is very much promising to implement LRU Cache but only thing is Searching is O(N), Can we improve this as well? Which data structure helps us providing searching in O(1)?
Answer is HashSet/Hashmap, So our next implementation is SLL+Hashmap**

**Using SLL+Hashmap:** If we use SLL, what are its Pros and Cons. 

We will store all the nodes in hashmap and whenever searching needs to do, we will do a lookup in the hashmap.

-	Pros:
1.	Inserting the data in the end is O(1), by maintaining tail pointer
2.	Deleting the data is O(1), how? First we search the data (which is a separate method) and then we will delete the data in O(1), we will not have to shift the data.
3.	Searching an element in array is O(1)

-	Cons:
1.	When we have to delete the node, we will search the element which needs to be deleted using hashmap, but hashmap gives you the exact node address or node which we want to delete, but how can we delete a node if we do not know its prev node, then how would be connect prev to search node’s next pointer?

**Using Doubly Linked List + Hashmap:**

When we use doubly linked list, it will have next and prev pointer to it, Now lets see it pros and cons
-	Pros:
1.	Inserting the data in the end is O(1), by maintaining tail pointer
2.	Searching an element in array is O(1)- using Hashmap.
3.	Deleting the data is O(1), how? First we search the data using Hashmap, we found the node, node will have its prev and next pointer details, so just connect prev node to next node. 

-	Cons:
-	No Cons found

![image](https://user-images.githubusercontent.com/83850703/175813398-5e217da8-3453-4986-89d9-4db280bb04b3.png)

![image](https://user-images.githubusercontent.com/83850703/175813401-cd06e613-ee68-485d-adf4-f6527a9602dd.png)

**Code Implementation**

As we have just see, basic methods are Search, AddtoTail and Delete.
Search will be taken care by hashmap.
So below are the Add to Tail and Delete Methods-

**Add to tail**: 
First of all we will have two dummy pointers head and tail (we can skip many edge cases by taking dummy pointers). We will place all the nodes between them.
Now when we want to add a new node at the tail, it means we have to add a new node before tail pointer.
So suppose this is our LL, head->1->2->3->4->tail,  if we have to add the new node 5, we will say connect 5 prev to 4 and 4 is tail.prev
next, connect 4 next to 5, and 4 is tail.prev and if we have to connect this to 5 we will right tail.prev.next=5
next, connect 5 to tail, so we will say 5.next=tail and finally connect tail.prev to 5

```
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
```

**Delete**: 
In Order to delete the node, we have to find the node which can be retrieved by hashmap in O(1).
we want to break the connection of node from its prev and next and connect node's prev to node's next.
Now node's prev should be connected with node's next  and node's next's prev should be connected node's prev


```
public void deleteNode(LRU node)
{
    // node prev next will no longer be current node instead it will be node's next
    node.prev.next = node.next;
    // current node next's prev will no longer be node instead it will be node's prev
    node.next.prev = node.prev;

}
```
Rest of the code will be as per the diagram, and code is avaiable in LRUCache.cs, please refer
