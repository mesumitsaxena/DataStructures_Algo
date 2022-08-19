package Heaps.Heaps1;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;

//This solution is not working solution
class primeFraction{

    double fraction;
    int nominator;
    int denominator;
    primeFraction(double fraction, int nominator, int denominator){
        this.fraction=fraction;
        this.nominator=nominator;
        this.denominator=denominator;
    }
}
class fractionComparator implements Comparator<primeFraction>{

    @Override
    public int compare(primeFraction o1, primeFraction o2) {
        if(o1.fraction>o2.fraction){
            return -1;
        }
        return 1;
    }
}
public class BSmallestPrimeFraction {
    public ArrayList<Integer> solve(ArrayList<Integer> A, int B) {
        PriorityQueue<primeFraction> pQ= new PriorityQueue<>(new fractionComparator());
        int count=0;
        for(int i=0;i<A.size();i++){
            for(int j=A.size()-1;j>i;j--){
                if(pQ.size()<B){
                    pQ.add(new primeFraction(A.get(i)/A.get(j),A.get(i),A.get(j)));
                }
                else{
                    pQ.poll();
                    pQ.add(new primeFraction(A.get(i)/A.get(j),A.get(i),A.get(j)));
                }

//                if(count==B){
//                    return new ArrayList<>(Arrays.asList(A.get(i),A.get(j)));
//                }
//                count++;
            }
        }
        return new ArrayList<>(Arrays.asList(pQ.peek().nominator,pQ.peek().denominator));
    }
}
