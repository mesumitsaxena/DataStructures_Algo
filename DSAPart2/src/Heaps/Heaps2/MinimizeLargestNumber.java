package Heaps.Heaps2;

import java.util.*;

//Given an array A of N numbers, you have to perform B operations. In each operation, you have to pick any one of the N elements and add the original value(value stored at the index before we did any operations) to its current value. You can choose any of the N elements in each operation.
//
//        Perform B operations in such a way that the largest element of the modified array(after B operations) is minimized.
//        Find the minimum possible largest element after B operations.
//Example Input
//        Input 1:
//
//        A = [1, 2, 3, 4]
//        B = 3
//        Input 2:
//
//        A = [5, 1, 4, 2]
//        B = 5
//
//
//        Example Output
//        Output 1:
//
//        4
//        Output 2:
//
//        5
//
//
//        Example Explanation
//        Explanation 1:
//
//        Apply operation on element at index 0, the array would change to [2, 2, 3, 4]
//        Apply operation on element at index 0, the array would change to [3, 2, 3, 4]
//        Apply operation on element at index 0, the array would change to [4, 2, 3, 4]
//        Minimum possible largest element after 3 operations is 4.
//        Explanation 2:
//
//        Apply operation on element at index 1, the array would change to [5, 2, 4, 2]
//        Apply operation on element at index 1, the array would change to [5, 3, 4, 2]
//        Apply operation on element at index 1, the array would change to [5, 4, 4, 2]
//        Apply operation on element at index 1, the array would change to [5, 5, 4, 2]
//        Apply operation on element at index 3, the array would change to [5, 5, 4, 4]
//        Minimum possible largest element after 5 operations is 5.
class SortPair implements Comparator<Map.Entry<Integer,Integer>>{

    @Override
    public int compare(Map.Entry<Integer, Integer> o1, Map.Entry<Integer, Integer> o2) {
        return o1.getKey()-o2.getKey();
    }
}
public class MinimizeLargestNumber {
    // To minimize the answer, we need to pick the minimum value from the list
    // but we need to check what will be the value after adding up
    // So we will be needing an extra array where we can update the values and we will keep the original array so that
    // we can get original value whenever it is required to add up
    // Now we need something by which we can get which element to choose when adding its original value
    // obviously we need the minimum value after add up, So we can have minheap and insert all possible added values
    // then pick the minimum value and extract min, add that value in the state array
    // and push it back in the min heap.
    // for example: 1, 2, 3, 4
    // we will add 2, 4 , 6, 8 in minheap, we will also maintain state array 1,2,3,4
    // from minheap, we will get 2 by extract min, replace it in state array, So state array would be 2,2,3,4
    // now add 2+1(original value) and add it in min heap and continue the process
    // until B times, after that iterate on state array and return max value
    public int solve(ArrayList<Integer> A, int B) {
        ArrayList<Integer> stateList= new ArrayList<>(A);
        PriorityQueue<Map.Entry<Integer,Integer>> pQ= new PriorityQueue<>(new SortPair());
        for(int i=0;i<A.size();i++){
            pQ.add(new AbstractMap.SimpleEntry<>(2*A.get(i),i));
        }
        while(B-- > 0){
            Map.Entry<Integer,Integer> entry=pQ.poll();
            stateList.set(entry.getValue(),entry.getKey());
            pQ.add(new AbstractMap.SimpleEntry<>(entry.getKey()+A.get(entry.getValue()),entry.getValue()));
        }
        int max=stateList.get(0);
        for(int i=1;i<stateList.size();i++){
            max=Math.max(max,stateList.get(i));
        }
        return max;

    }
}
