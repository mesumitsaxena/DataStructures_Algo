package Heaps.Heaps2;

//You are given an array A containing N numbers. This array is called special if it satisfies one of the following properties:
//
//        There exists an element A[i] in the array such that A[i] is equal to the median of elements [A[0], A[1], ...., A[i-1]]
//        There exists an element A[i] in the array such that A[i] is equal to the median of elements [A[i+1], A[i+2], ...., A[N-1]]
//        The Median is the middle element in the sorted list of elements. If the number of elements is even then the median will be (sum of both middle elements) / 2.
//
//        Return 1 if the array is special else return 0.
//
//        NOTE:
//
//        For A[0] consider only the median of elements [A[1], A[2], ..., A[N-1]] (as there are no elements to the left of it)
//        For A[N-1] consider only the median of elements [A[0], A[1], ...., A[N-2]]
//Example Input
//        Input 1:
//
//        A = [4, 6, 8, 4]
//        Input 2:
//
//        A = [2, 7, 3, 1]
//
//
//        Example Output
//        Output 1:
//
//        1
//        Output 2:
//
//        0
//
//
//        Example Explanation
//        Explantion 1:
//
//        Here, 6 is equal to the median of [8, 4].
//        Explanation 2:
//
//        No element satisfies any condition.

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.PriorityQueue;

public class SpecialMedian {
    // we will use same technique as Running median
    // Lets understand with an example:
    // [4, 6, 8, 4] -> first of max heap will be empty, So we will not check anything and insert 4 in maxheap
    // now, 6 comes, check the median, its 4 and 4!=6, Insert 6
    // 6>4, so it will go in min heap.
    // check next, 8 comes, check median, as min heap and max heap size is equal, means number of elements are even
    // So median will be (4+6)/2=5, now 5!=8, So insert 8, 8 will go in min heap, as min heap has eleents greater than maxheap
    // move one element from minheap to max heap, So shift 6 to max heap.
    // now 4 comes , as number of elements are odd, so check the median, median is 6 and 6!=4, so insert 4 into max heap
    // So from left side we didn't get the answer.
    // we will empty the min and max heap and repeat the process from right to left
    public int solve(ArrayList<Integer> A) {
        PriorityQueue<Integer> minHeap= new PriorityQueue<>();
        PriorityQueue<Integer> maxHeap= new PriorityQueue<>(Collections.reverseOrder());
        maxHeap.offer(A.get(0));
        double median=maxHeap.peek();
        for(int i=1;i<A.size();i++){
            // calculate the median and check with A[i]
            // Code of Calculating the median
            if(median==(double) A.get(i)){
                return 1;
            }

            if(A.get(i)<maxHeap.peek()){
                maxHeap.offer(A.get(i));
                if(maxHeap.size()-minHeap.size()>1){
                    minHeap.offer(maxHeap.poll());
                }
            }
            else{
                minHeap.offer(A.get(i));
                if(minHeap.size()>maxHeap.size()){
                    maxHeap.offer(minHeap.poll());
                }
            }
            if(maxHeap.size()==minHeap.size()){
                median=(maxHeap.peek()+minHeap.peek())/2.0;
            }
            else{
                median=maxHeap.peek();
            }
        }
        minHeap= new PriorityQueue<>();
        maxHeap= new PriorityQueue<>(Collections.reverseOrder());
        maxHeap.offer(A.get(A.size()-1));
        median=maxHeap.peek();
        for(int i=A.size()-2;i>=0;i--){
            // calculate the median and check with A[i]
            // Code of Calculating the median
            if(median==(double) A.get(i)){
                return 1;
            }
            if(A.get(i)<maxHeap.peek()){
                maxHeap.offer(A.get(i));
                if(maxHeap.size()-minHeap.size()>1){
                    minHeap.offer(maxHeap.poll());
                }
            }
            else{
                minHeap.offer(A.get(i));
                if(minHeap.size()>maxHeap.size()){
                    maxHeap.offer(minHeap.poll());
                }
            }
            if(maxHeap.size()==minHeap.size()){
                median=(maxHeap.peek()+minHeap.peek())/2.0;
            }
            else{
                median=maxHeap.peek();
            }
        }
        return 0;
    }

}
