package Heaps.Heaps2;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.PriorityQueue;

//Given an integer array B of size N.
//
//        You need to find the Ath largest element in the subarray [1 to i], where i varies from 1 to N. In other words, find the Ath largest element in the sub-arrays [1 : 1], [1 : 2], [1 : 3], ...., [1 : N].
//
//        NOTE: If any subarray [1 : i] has less than A elements, then the output should be -1 at the ith index.
//Example Input
//        Input 1:
//
//        A = 4
//        B = [1 2 3 4 5 6]
//        Input 2:
//
//        A = 2
//        B = [15, 20, 99, 1]
//
//
//        Example Output
//        Output 1:
//
//        [-1, -1, -1, 1, 2, 3]
//        Output 2:
//
//        [-1, 15, 20, 20]
//
//
//        Example Explanation
//        Explanation 1:
//
//        for i <= 3 output should be -1.
//        for i = 4, Subarray [1:4] has 4 elements 1, 2, 3 and 4. So, 4th maximum element is 1.
//        for i = 5, Subarray [1:5] has 5 elements 1, 2, 3, 4 and 5. So, 4th maximum element is 2.
//        for i = 6, Subarray [1:6] has 6 elements 1, 2, 3, 4, 5 and 6. So, 4th maximum element is 3.
//        So, output array is [-1, -1, -1, 1, 2, 3].
//
//        Explanation 2:
//
//        for i <= 1 output should be -1.
//        for i = 2 , Subarray [1:2] has 2 elements 15 and 20. So, 2th maximum element is 15.
//        for i = 3 , Subarray [1:3] has 3 elements 15, 20 and 99. So, 2th maximum element is 20.
//        for i = 4 , Subarray [1:4] has 4 elements 15, 20, 99 and 1. So, 2th maximum element is 20.
//        So, output array is [-1, 15, 20, 20].
public class AthLargestElement {
    // will create a min heap, insert A elements into it, and peek the min element, it will Ath largest element for that window
    // for next window, check the next element and compare it with min element from minheap, if it is greater than min element then
    // extract min and add this element only
    // if the next element is smaller than we will not do anything, because if it is smaller than the element is heap, then it cant be Ath largest
    // when we build the min heap with A elements we are actually having A largest elements, Ath largest will be smaller among them
    // because most largest will 1st largest, after than 2nd largest and if we have box of A, then smallest will be Ath largest
    // when next element comes, and if it is greater than smaller in heap, it should be replaced, because current smaller can be more smaller
    // and current element can be 1st laregest or 2nd largest or Ath largest, and current min can not stand the chance to claim Ath largest
    // if upcoming element is smaller than current min, then upcoming element can not replace the current element
    // because it will be way more smaller than current min
    public ArrayList<Integer> solve(int A, ArrayList<Integer> B) {
        PriorityQueue<Integer> pQ= new PriorityQueue<>();
        for(int i=0;i<A;i++){
            pQ.offer(B.get(i));
        }
        ArrayList<Integer> output= new ArrayList<>();
        for(int i=0;i<A-1;i++){
            output.add(-1);
        }
        for(int i=A;i<B.size();i++){
            output.add(pQ.peek());
            if(pQ.peek()<B.get(i)){
                pQ.poll();
                pQ.offer(B.get(i));
            }
        }
        if(pQ.size()>0){
            output.add(pQ.peek());
        }
        return output;
    }
}
