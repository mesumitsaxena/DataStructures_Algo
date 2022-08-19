package Heaps.Heaps1;

import java.util.ArrayList;

//You are given an array A of integers that represent the lengths of ropes.
//
//        You need to connect these ropes into one rope. The cost of joining two ropes equals the sum of their lengths.
//
//        Find and return the minimum cost to connect these ropes into one rope.
//Example Input
//        Input 1:
//
//        A = [1, 2, 3, 4, 5]
//        Input 2:
//
//        A = [5, 17, 100, 11]
//
//
//        Example Output
//        Output 1:
//
//        33
//        Output 2:
//
//        182
//
//
//        Example Explanation
//        Explanation 1:
//
//        Given array A = [1, 2, 3, 4, 5].
//        Connect the ropes in the following manner:
//        1 + 2 = 3
//        3 + 3 = 6
//        4 + 5 = 9
//        6 + 9 = 15
//
//        So, total cost  to connect the ropes into one is 3 + 6 + 9 + 15 = 33.
//        Explanation 2:
//
//        Given array A = [5, 17, 100, 11].
//        Connect the ropes in the following manner:
//        5 + 11 = 16
//        16 + 17 = 33
//        33 + 100 = 133
//
//        So, total cost  to connect the ropes into one is 16 + 33 + 133 = 182.
public class ConnectRopes {
    // as we know, we can choose 2 ropes at a time and then we have to add the length
    // next time when we choose the ropes, added length is also available
    // its like add the length and then carry forward the length for next iteration
    // So minimum cost can be calculated as choosing the minimum length always
    // because those costs are added again and again
    // So first we add the first 2 minimum ropes then add the added rope length into array again
    // repeat the previous steps again till only 1 rope left
    // We can sort the array by which we can have minimum length first
    // but after adding them we need to insert the added length into array and again sort the array
    // So we will use min heap or priority queue
    public int solve(ArrayList<Integer> A) {
        /*PriorityQueue<Integer> pQ= new PriorityQueue<>();
        for(int num: A){
            pQ.add(num);
        }
        int ans=0;
        while(pQ.size()>1){
            int num1=pQ.poll();
            int num2=pQ.poll();

            ans+=num1+num2;
            pQ.add(num1+num2);
        }
        return ans;*/
        MinHeap heap= new MinHeap();
        heap.GenerateHeap(A);
        int ans=0;
        while(A.size()>1){
            int num1=heap.extractMin(A);
            int num2=heap.extractMin(A);

            ans+=num1+num2;
            heap.Insert(A,num1+num2);
        }
        return ans;
    }
}
