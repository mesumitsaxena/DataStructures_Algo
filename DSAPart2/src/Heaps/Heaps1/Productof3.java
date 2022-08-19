package Heaps.Heaps1;

import java.util.ArrayList;
import java.util.PriorityQueue;

//Given an integer array A of size N.
//
//        You have to find the product of the three largest integers in array A from range 1 to i, where i goes from 1 to N.
//
//        Return an array B where B[i] is the product of the largest 3 integers in range 1 to i in array A. If i < 3, then the integer at index i in B should be -1.
//        Example Input
//        Input 1:
//
//        A = [1, 2, 3, 4, 5]
//        Input 2:
//
//        A = [10, 2, 13, 4]
//
//
//        Example Output
//        Output 1:
//
//        [-1, -1, 6, 24, 60]
//        Output 2:
//
//        [-1, -1, 260, 520]
//
//
//        Example Explanation
//        Explanation 1:
//
//        For i = 1, ans = -1
//        For i = 2, ans = -1
//        For i = 3, ans = 1 * 2 * 3 = 6
//        For i = 4, ans = 2 * 3 * 4 = 24
//        For i = 5, ans = 3 * 4 * 5 = 60
//
//        So, the output is [-1, -1, 6, 24, 60].
//
//        Explanation 2:
//
//        For i = 1, ans = -1
//        For i = 2, ans = -1
//        For i = 3, ans = 10 * 2 * 13 = 260
//        For i = 4, ans = 10 * 13 * 4 = 520
//
//        So, the output is [-1, -1, 260, 520].
public class Productof3 {
    // Simple solution can be, for each i, add the element in the box
    // maintain only 3 items in the box, for each i if box.count==3, return product of 3 elements in the box
    // for next i, add the ith element and remove the minimum element, as we need product of 3 maximum values till i
    // As we guesed right, we can take min heap or priority queue in reverse order
    // add the element for each i, check if count is 3 or not, if not return -1
    // if yes return the product of 3.
    // now for next i, add the element in queue and extract min, continue till last
    public ArrayList<Integer> solve(ArrayList<Integer> A) {
        ArrayList<Integer> output= new ArrayList<>();
        PriorityQueue<Integer> minHeap= new PriorityQueue<>();
        for(int i=0;i<A.size();i++){
            minHeap.add(A.get(i));
            if(minHeap.size()>3){
                minHeap.poll();
            }
            if(minHeap.size()==3){
                int ans=1;
                for(int item:minHeap){
                    ans=ans*item;
                }
                output.add(ans);
            }
            else{
                output.add(-1);
            }
        }
        return output;
    }
}
