package Heaps.Heaps1;

import java.util.ArrayList;
import java.util.Collections;
import java.util.PriorityQueue;

public class KthSmallestElementin2DArray {
    public int solve(ArrayList<ArrayList<Integer>> A, int B) {
        ArrayList<Integer> pQ= new ArrayList<>();
        for(int i=0;i<A.size();i++){
            for(int j=0;j<A.get(i).size();j++){
                pQ.add(A.get(i).get(j));
            }
        }
        Collections.sort(pQ);
        return pQ.get(B-1);
    }
}
