package Heaps.Heaps2;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.PriorityQueue;

//N people having different priorities are standing in a queue.
//
//        The queue follows the property that each person is standing at most B places away from its position in the sorted queue.
//
//        Your task is to sort the queue in the increasing order of priorities.
//NOTE:
//
//        No two persons can have the same priority.
//        Use the property of the queue to sort the queue with complexity O(NlogB).
//Example Input
//        Input 1:
//
//        A = [1, 40, 2, 3]
//        B = 2
//        Input 2:
//
//        A = [2, 1, 17, 10, 21, 95]
//        B = 1
//
//
//        Example Output
//        Output 1:
//
//        [1, 2, 3, 40]
//        Output 2:
//
//        [1, 2, 10, 17, 21, 95]
//
//
//        Example Explanation
//        Explanation 1:
//
//        Given array A = [1, 40, 2, 3]
//        After sorting, A = [1, 2, 3, 40].
//        We can see that difference between initial position of elements amd the final position <= 2.
//        Explanation 2:
//
//        After sorting, the array becomes [1, 2, 10, 17, 21, 95].
public class KPlacesApart {
    // Simple solution is Sort the Entire Array :D
    // But we have to solve this without using sorting
    // we know that each sorted position of an element is B(or K) distance apart
    // and we want the minimum element first and then 2nd min and 3rd etc
    // So if we create a min heap of size B(or K), then min element of the minheap for that index will be correct position of that element
    // example: 1, 40, 2, 3, B=2, So we know for index 0 the correct element willl be max B distance apart
    // So for index 0, correct element can be 1 or 40 or 2.
    // So we will add 1, 40 and 2 in min heap and so extract min will give us 1, so 1 was at the correct index
    // now 40 comes, for index 1, correct element can be 40 or 2 or 3 (why not 1, distance can be backwards as well?
    // its because we have already processed the previous elements and if that can be our answer then it will be in our heap)
    // So min of 40, 2 and 3 is 2, So for ind=1, 2 is correct answer, now for index 2, correct can be 3 and 40, because they are in the heap only
    // So min is 3 and at last 40
    // So steps can be -
    // 1. Create a Min Heap of size B+1(B distance apart means distance from current index)
    // 2. now extract the min element from heap add into answer array
    // 3. Add the next element in heap
    // 4. continue this until all the elements are not added into heap
    // 5. extract min ... extract min... until heap is empty
    // TC: (N-K)LogK, SC: O(K)
    // we can do one more thing, add all the elements in minheap and then extract min each time
    // for that TC: NLogN and SC: O(N)
    public ArrayList<Integer> solve(ArrayList<Integer> A, int B) {
        PriorityQueue<Integer> pQ= new PriorityQueue<>();
        for(int i=0;i<=B;i++){
            pQ.offer(A.get(i));
        }
        ArrayList<Integer> output= new ArrayList<>();
        for(int i=B+1;i<A.size();i++){
            output.add(pQ.poll());
            pQ.add(A.get(i));
        }
        while(pQ.size()>0){
            output.add(pQ.poll());
        }
        return output;
    }
}
