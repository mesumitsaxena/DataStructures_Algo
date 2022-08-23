package Heaps.Heaps2;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.PriorityQueue;

//Given two integers arrays, A and B, of size N each.
//
//        Find the maximum N elements from the sum combinations (Ai + Bj) formed from elements in arrays A and B.
//The first argument is an integer array A.
//        The second argument is an integer array B.
//        Example Input
//        Input 1:
//
//        A = [1, 4, 2, 3]
//        B = [2, 5, 1, 6]
//        Input 2:
//
//        A = [2, 4, 1, 1]
//        B = [-2, -3, 2, 4]
//
//
//        Example Output
//        Output 1:
//
//        [10, 9, 9, 8]
//        Output 2:
//
//        [8, 6, 6, 5]
//
//
//        Example Explanation
//        Explanation 1:
//
//        4 maximum elements are 10(6+4), 9(6+3), 9(5+4), 8(6+2).
//        Explanation 2:
//
//        4 maximum elements are 8(4+4), 6(4+2), 6(4+2), 5(4+1).
class customPair{
    int sum;
    int first;
    int second;
    customPair(int sum, int first, int second){
        this.sum=sum;
        this.first=first;
        this.second=second;
    }
}
class customPairSort implements Comparator<customPair> {
    @Override
    public int compare(customPair o1, customPair o2) {
        return o2.sum-o1.sum;
    }


}
public class NMaxPairCombination {
    // As we need N maximum pair sum, in order to generate first maximum pair sum, would be max from Array A and B
    // Its better we sort the array, it will help us figuring out the max element and traversal will also be easier
    // So we will sort both the arrays.
    // Now we need something where we store N sums and each time any sum is greater than any of the sum on the box
    // then it should be replace (remove most minimum sum from box). Can you guess the DS?
    // its Min heap because we need to extract min again and again when any greater sum comes up
    // So we will prepare a min heap by taking sum of max of A with all the members of B
    // after that we will start a nested loop, by which we will check each pair from right side(maximum element side)
    // and check if any pair has sum greater than min sum of minheap than extract the min and add the new sum, if any
    // sum is less than min sum, then there will not be any sum greater exist on left side as left has smaller elements
    // So we will break the loop right and there.
    // at the end will pull N elements out of min heap(there are only N elements in min heap) and add it to array and return
    // Important point is nested loop will give TC as O(N^2), So is it a optimized approach?
    // No it will not give O(N^2) approach, as we are breaking the inner loop whenever there is smaller sum exist than min heap min
    // So definetly first iteration when adding sums to minheap will take O(N), after that, nested loop will start
    // in nested loop, first it will take O(N/2) because it will break after comparing half elements,
    // So after that it will take N/4, then N/8, and so on, So n/2+n/4+n/8.... = O(N) only
    // lets take and example and understand -
    //        A = [1, 4, 2, 3]
    //        B = [2, 5, 1, 6]
    // After sorting A = [1, 2, 3, 4]
    // After sorting B = [1, 2 ,5 ,6]
    // So first will prepare minheap as 6+4=10, 6+3=9, 6+2=8, 6+1=7
    // Now nested loop will start, now we will start with N-1 of B, So 5+4=9, 9>minofminheap(7), So remove 7 and add 9
    // minheap= 8,9,9,10
    // now 5+3=8, 8 is not greater than 8, So break the loop
    // Pointer moved to 2, 4+2=6, 6<8, so break
    // Pointer moved to 1, 4+1=5, 5<8, So break
    // So total 4 steps hence its proved that from nested loop with break statement, O(N) time will take in this solution
    // So overall we can say preparing a min heap will take O(N)+ nested loop O(N) => O(2N) => O(N)
    public ArrayList<Integer> solve(ArrayList<Integer> A, ArrayList<Integer> B) {
        Collections.sort(A);
        Collections.sort(B);
        PriorityQueue<Integer> pQ= new PriorityQueue<>();
        int size=A.size()-1;
        for(int i=0;i<B.size();i++){
            pQ.offer(A.get(size)+B.get(i));
        }
        for(int i=size-1;i>=0;i--){
            for(int j=size;j>=0;j--){
                if(A.get(i)+B.get(j)>pQ.peek()){
                    pQ.poll();
                    pQ.offer(A.get(i)+B.get(j));
                }
                else{
                    break;
                }
            }
        }
        ArrayList<Integer> output= new ArrayList<>();
        while(size>=0){
            output.add(pQ.poll());
        }
        Collections.sort(output, new Comparator<Integer>() {
            @Override
            public int compare(Integer o1, Integer o2) {
                return 0;
            }
        });
        return output;
    }
}
