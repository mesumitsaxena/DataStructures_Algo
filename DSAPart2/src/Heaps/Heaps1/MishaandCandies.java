package Heaps.Heaps1;

import java.util.ArrayList;
import java.util.PriorityQueue;

//Misha loves eating candies. She has been given N boxes of Candies.
//
//        She decides that every time she will choose a box having the minimum number of candies, eat half of the candies and put the remaining candies in the other box that has the minimum number of candies.
//        Misha does not like a box if it has the number of candies greater than B so she won't eat from that box. Can you find how many candies she will eat?
//
//        NOTE 1: If a box has an odd number of candies then Misha will eat the floor(odd / 2).
//
//        NOTE 2: The same box will not be chosen again.
//Example Input
//        Input 1:
//
//        A = [3, 2, 3]
//        B = 4
//        Input 2:
//
//        A = [1, 2, 1]
//        B = 2
//
//
//        Example Output
//        Output 1:
//
//        2
//        Output 2:
//
//        1
//
//
//        Example Explanation
//        Explanation 1:
//
//        1st time Misha will eat from 2nd box, i.e 1 candy she'll eat and will put the remaining 1 candy in the 1st box.
//        2nd time she will eat from the 3rd box, i.e 1 candy she'll eat and will put the remaining 2 candies in the 1st box.
//        She will not eat from the 3rd box as now it has candies greater than B.
//        So the number of candies Misha eat is 2.
//        Explanation 2:
//
//        1st time Misha will eat from 1st box, i.e she can't eat any and will put the remaining 1 candy in the 3rd box.
//        2nd time she will eat from the 3rd box, i.e 1 candy she'll eat and will put the remaining 1 candies in the 2nd box.
//        She will not eat from the 2nd box as now it has candies greater than B.
//        So the number of candies Misha eat is 1.
public class MishaandCandies {
    // Take the minimum value out, add the half into answer, then take another minimum out, add remaining into it
    // and add it back.
    // So minheap will help us to get minimum each time
    public int solve(ArrayList<Integer> A, int B) {
        PriorityQueue<Integer> pQ= new PriorityQueue<>();

        for(int item: A){
            pQ.add(item);
        }
        int numberOfCandies=0;
        while(pQ.size()>1){
            int val=pQ.poll();
            if(val>B){
                return numberOfCandies;
            }
            int CandiesAte=val/2;
            int remaining=val-CandiesAte;
            numberOfCandies+=val/2;
            int val2=pQ.poll();
            pQ.add(remaining+val2);
        }
        if(pQ.size()==1){
            int val=pQ.poll();
            if(val>B){
                return numberOfCandies;
            }
            else{
                return numberOfCandies+val/2;
            }
        }
        return numberOfCandies;
    }
}
