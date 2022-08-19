package Heaps.Heaps1;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class HeapTest {
    public static void main(String[] args) {
        ArrayList<Integer> A= new ArrayList<>(Arrays.asList(283, 671, 338, 462, 399, 834, 450, 727, 671 ));
//        MinHeap heap= new MinHeap();
//        heap.GenerateHeap(A);
//        int ans=0;
//        while(A.size()>1){
//            int num1=heap.extractMin(A);
//            int num2=heap.extractMin(A);
//
//            ans+=num1+num2;
//            heap.Insert(A,num1+num2);
//        }
//        System.out.println(ans);
//        MishaandCandies obj= new MishaandCandies();
//        obj.solve(A,858);
//        KthSmallestElementin2DArray obj= new KthSmallestElementin2DArray();
//        ArrayList<ArrayList<Integer>> aList= new ArrayList<>();
//        aList.add(new ArrayList<>(Arrays.asList(3, 5, 7, 9)));
//        aList.add(new ArrayList<>(Arrays.asList(4, 6, 9, 12)));
//        aList.add(new ArrayList<>(Arrays.asList(5, 9, 12, 16)));
//        aList.add(new ArrayList<>(Arrays.asList(6, 10, 14, 19)));
//        obj.solve(aList,15);

        BSmallestPrimeFraction obj2= new BSmallestPrimeFraction();
        obj2.solve(new ArrayList<>(Arrays.asList(1, 719, 983, 9293, 11321, 14447, 16411, 17881, 22079, 28297)),42);
    }
}
