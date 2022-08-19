package Heaps.Heaps1;

import java.util.ArrayList;
import java.util.PriorityQueue;

//Given an array of integers A and an integer B. You must modify the array exactly B number of times. In a single modification, we can replace any one array element A[i] by -A[i].
//
//        You need to perform these modifications in such a way that after exactly B modifications, sum of the array must be maximum.
//Example Input
//        Input 1:
//
//        A = [24, -68, -29, -9, 84]
//        B = 4
//        Input 2:
//
//        A = [57, 3, -14, -87, 42, 38, 31, -7, -28, -61]
//        B = 10
//
//
//        Example Output
//        Output 1:
//
//        196
//        Output 2:
//
//        362
//
//
//        Example Explanation
//        Explanation 1:
//
//        Final array after B modifications = [24, 68, 29, -9, 84]
//        Explanation 2:
//
//        Final array after B modifications = [57, -3, 14, 87, 42, 38, 31, 7, 28, 61]
public class MaximumArraySumafterBNegation {
    // we have to perform exactly B operations, So if we negate numbers from beginning of array then it wont give us maximum sum
    // we only have to negate the negative numbers(or smaller numbers)
    // what if there is less negative numbers then B operations
    // then we have to negate some positive numbers, which can lead us to less sum
    // but we have to perform B operations
    // So if we have to negate the positive number, then it should be smallest number, so that we can get maximum sum
    // So we will sort the array and negate the numbers so that they will become +ve
    // by this -ve numbers will become +ve and if needed smallest +ve number will become -ve
    // but again what if the number which just become +ve is still the smallest number
    // So that is why we will use min heap
    // take smallest numbers and negate them and add them back in minheap
    public int solve(ArrayList<Integer> A, int B) {
        PriorityQueue<Integer> pQ= new PriorityQueue<>();
        for(int i=0;i<A.size();i++){
            pQ.add(A.get(i));
        }
        while(B>0){
            int val=pQ.poll();
            pQ.add(-val);
            B--;
        }
        int ans=0;
        for(int item:pQ){
            ans+=item;
        }
        return ans;
    }
}
