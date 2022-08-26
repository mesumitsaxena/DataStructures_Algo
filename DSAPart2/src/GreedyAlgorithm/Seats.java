package GreedyAlgorithm;

import java.util.ArrayList;

public class Seats {
    public int seats(String A) {
        ArrayList<Integer> medianArray= new ArrayList<Integer>();
        for(int i=0;i<A.length();i++){
            if(A.charAt(i)=='x'){
                medianArray.add(i);
            }
        }
        int median=medianArray.get(medianArray.size()/2);
        int cost=0;
        int left=medianArray.size()/2-1;
        int m=median;
        while(left>=0){
            cost+=m-medianArray.get(left)-1;
            m=m-1;
            left--;
        }
        int right=medianArray.size()/2+1;
        m=median;
        while(right<medianArray.size()){
            cost+=medianArray.get(right)-m-1;
            m=m+1;
            right++;
        }
        return cost;
    }
}
