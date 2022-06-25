## Detect Cycle and its Starting Point in LinkedList

So suppose when slow reach to meeting point and it covers x distance, then fast will surely covers 2x distance because it running with double speed.
Now considering slow is about to enter the loop and fast is inside the loop, suppose distance between fast and slow is d, then how many unit of distances slow and fast will meet? Answer is d distance right?, how? Suppose distance between fast and slow is 6, slow moves 1 unit and fast moves 2 unit, now distance between them is 5 and we are calculating this with respect of slow. So when slow moves 1 distance 1 distance is subtracted between fast and slow or we can say d, so after 6 unit distance between them will be 6-6 =0, means they will meet each other.

![DetectCycleLL1](https://user-images.githubusercontent.com/83850703/175769199-273f145a-ad3e-49b6-b68d-ea00d5623d48.PNG)

Now Suppose loop size is N unit, so what is the distance between fast and slow in above diagram?          Its N-X right? So we can say slow and fast will meet each after N-X unit of distance and this calculation is based on when slow is at the position where it is about to enter the loop.

![DetectCycleLL2](https://user-images.githubusercontent.com/83850703/175769242-cfd583cb-0c7d-43d3-9496-3ec4feb5fcc2.PNG)

So slow and fast will meet together after N-X unit of distance from slow pointer position when it is about to enter the loop. So how much distance is left from slow and fast meeting point to point of loop?
N-N-X=>X. 

![DetectCycleLL3](https://user-images.githubusercontent.com/83850703/175769263-06c4953d-91b7-47df-ae3e-5147c970b4f1.PNG)

We can clearly see the distance from head to start of loop (which is X) is same as meeting point to start of the loop(which  is also X).

**So place one pointer at head and another pointer at meeting point and move them with slow speed, then they will again meet each other at starting point of loop.**


![DetectCycleLL4](https://user-images.githubusercontent.com/83850703/175769371-89daf9ab-9559-40de-9300-26747bf05b97.PNG)
