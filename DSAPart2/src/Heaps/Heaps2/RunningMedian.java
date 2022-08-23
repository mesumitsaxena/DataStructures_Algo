package Heaps.Heaps2;


import java.security.KeyPair;
import java.util.*;

//Given an array of integers, A denoting a stream of integers. New arrays of integer B and C are formed.
//        Each time an integer is encountered in a stream, append it at the end of B and append the median of array B at the C.
//
//        Find and return the array C.
//
//        NOTE:
//
//        If the number of elements is N in B and N is odd, then consider the median as B[N/2] ( B must be in sorted order).
//        If the number of elements is N in B and N is even, then consider the median as B[N/2-1]. ( B must be in sorted order).
//NOTE:
//
//        If the number of elements is N in B and N is odd, then consider the median as B[N/2] ( B must be in sorted order).
//        If the number of elements is N in B and N is even, then consider the median as B[N/2-1]. ( B must be in sorted order).
//Input Format
//        The only argument given is the integer array A.
//
//
//
//        Output Format
//        Return an integer array C, C[i] denotes the median of the first i elements.
//
//
//
//        Example Input
//        Input 1:
//
//        A = [1, 2, 5, 4, 3]
//        Input 2:
//
//        A = [5, 17, 100, 11]
//
//
//        Example Output
//        Output 1:
//
//        [1, 1, 2, 2, 3]
//        Output 2:
//
//        [5, 5, 17, 11]
//
//
//        Example Explanation
//        Explanation 1:
//
//        stream          median
//        [1]             1
//        [1, 2]          1
//        [1, 2, 5]       2
//        [1, 2, 5, 4]    2
//        [1, 2, 5, 4, 3] 3
//        Explanation 2:
//
//        stream          median
//        [5]              5
//        [5, 17]          5
//        [5, 17, 100]     17
//        [5, 17, 100, 11] 11
public class RunningMedian {
    // as we need to find N/2th element each time a new element comes
    // looks like find the N/2th max element considering the array is in sorting order
    // but it is not sure array will be in sorting order.
    // So we need to sort the array again and again when new eleemnt comes, then TC will be: N*NLogN
    // but we know we need to adjust the elements whenever a new element comes, So we can apply Insertion sort as well
    // and TC will reduce to N^2
    // Note that we will find the median after Inserting a new array
    // but N^2 is also not an optimized solution.
    // Now suppose we have to find the Kth smallest element and K is N/2 each time
    // We will create a Max heap and maintain N/2 elements but what about rest of the N/2 elements?
    // we will create a structure such that N/2th element is maximum and left of N/2th element will have lesser element than N/2
    // and right of it are larger than N/2th element
    // So in order to maintain N/2th element as maximum, we will use max heap and right side elements can be in min heap
    // Also we need to make sure, max heaps and min heaps have same number of elements
    // max heap can have 1 extra element in case of number of odd elements.
    // if max heap have more elements than min heap including 1 on left, than transfer 1 element from left to right
    // we can transfer, max element from maxheap and transfer it to min heap
    // why? example
    // 1 2 3 (left)  4 5 (right), so currently 4 is the median and size(left)-size(right)<=1 so its fine
    // but suppose 0 comes then -
    // 0 1 2 3(left) 4 5(right) , if we see overall, then 2 should be median, but median is coming as 3 which is wrong
    // So that is why we will transfer maximum from left to right, because right can have only max eleemnts
    // 0 1 2(left) 3 4 5 (right), now size(left)-size(right)<=1 => So all good
    // Steps:
    // create MaxHeap and MinHeap
    // 1.) Add first element in max heap
    // 2.) check the next element if it is greater than max element in max heap than insert it in min heap
    // (because all the larger element from max in maxheap, should be on right)
    // 3.) if it is lesser than max element in max heap than insert it in max heap
    // 4.) if size(left)-size(right)>1, than check where is the extra element.
    // if it is on right side, than move from min heap to max heap
    // if it is on left side, than move from max heap to min heap
    // Add the max from maxheap in answer array for each step
    public ArrayList<Integer> solve(ArrayList<Integer> A) {
        PriorityQueue<Integer> minHeap= new PriorityQueue<>();
        PriorityQueue<Integer> maxHeap= new PriorityQueue<>(Collections.reverseOrder());
        ArrayList<Integer> output= new ArrayList<>();
        maxHeap.add(A.get(0));
        output.add(A.get(0));
        for(int i=1;i<A.size();i++){
            if(A.get(i)<maxHeap.peek()){
                maxHeap.add(A.get(i));
                if(maxHeap.size()-minHeap.size()>1){
                    int max=maxHeap.poll();
                    minHeap.add(max);
                }
            }
            else{
                minHeap.add(A.get(i));
                if(maxHeap.size()>minHeap.size()){
                    int min=minHeap.poll();
                    maxHeap.add(min);
                }
            }
            output.add(maxHeap.peek());
        }
        return output;
    }
}
