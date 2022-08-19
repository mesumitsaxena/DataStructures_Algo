package Heaps.Heaps1;

import java.util.ArrayList;
import java.util.Collections;
import java.util.PriorityQueue;

//Given N bags, each bag contains Bi chocolates. There is a kid and a magician.
//        In a unit of time, the kid can choose any bag i, and eat Bi chocolates from it, then the magician will fill the ith bag with floor(Bi/2) chocolates.
//
//        Find the maximum number of chocolates that the kid can eat in A units of time.
//
//        NOTE:
//
//        floor() function returns the largest integer less than or equal to a given number.
//        Return your answer modulo 109+7
//Example Input
//        Input 1:
//
//        A = 3
//        B = [6, 5]
//        Input 2:
//
//        A = 5
//        b = [2, 4, 6, 8, 10]
//
//
//        Example Output
//        Output 1:
//
//        14
//        Output 2:
//
//        33
//
//
//        Example Explanation
//        Explanation 1:
//
//        At t = 1 kid eats 6 chocolates from bag 0, and the bag gets filled by 3 chocolates.
//        At t = 2 kid eats 5 chocolates from bag 1, and the bag gets filled by 2 chocolates.
//        At t = 3 kid eats 3 chocolates from bag 0, and the bag gets filled by 1 chocolate.
//        so, total number of chocolates eaten are 6 + 5 + 3 = 14
//        Explanation 2:
//
//        Maximum number of chocolates that can be eaten is 33.
public class MagiciannChocolate {
    // We are picking the maximum item and then adding the half of it
    // and we are doing it for each iteration of A
    // its kind of extracting maximum each time
    // So we can use Max heap or Priority Queue in reverse order
    public int nchoc(int A, ArrayList<Integer> B) {
        //Priority Queue
        PriorityQueue<Integer> pQ= new PriorityQueue<>(Collections.reverseOrder());
        for(int item:B){
            pQ.add(item);
        }

        long ans=0;
        for(int i=0;i<A;i++){
            int val=pQ.poll();
            ans+=val;
            pQ.add(val/2);
        }
        return (int)(ans % 1000000007);
//        MaxHeap heap= new MaxHeap();
//        heap.GenerateHeap(B);
//        long ans=0;
//        for(int i=0;i<A;i++){
//            int val=heap.extractMax(B);
//            ans+=val;
//            heap.Insert(B,val/2);
//        }
//        return (int)(ans % 1000000007);
    }
}
