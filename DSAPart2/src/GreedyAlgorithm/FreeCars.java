package GreedyAlgorithm;

import java.util.ArrayList;
import java.util.Collections;
import java.util.PriorityQueue;

//Given two arrays, A and B of size N. A[i] represents the time by which you can buy the ith car without paying any money.
//
//        B[i] represents the profit you can earn by buying the ith car. It takes 1 minute to buy a car, so you can only buy the ith car when the current time <= A[i] - 1.
//
//        Your task is to find the maximum profit one can earn by buying cars considering that you can only buy one car at a time.
//
//        NOTE:
//
//        You can start buying from time = 0.
//        Return your answer modulo 109 + 7.
//Example Input
//        Input 1:
//
//        A = [1, 3, 2, 3, 3]
//        B = [5, 6, 1, 3, 9]
//        Input 2:
//
//        A = [3, 8, 7, 5]
//        B = [3, 1, 7, 19]
//
//
//        Example Output
//        Output 1:
//
//        20
//        Output 2:
//
//        30
//
//
//        Example Explanation
//        Explanation 1:
//
//        At time 0, buy car with profit 5.
//        At time 1, buy car with profit 6.
//        At time 2, buy car with profit 9.
//        At time = 3 or after , you can't buy any car, as there is no car with deadline >= 4.
//        So, total profit that one can earn is 20.
//        Explanation 2:
//
//        At time 0, buy car with profit 3.
//        At time 1, buy car with profit 1.
//        At time 2, buy car with profit 7.
//        At time 3, buy car with profit 19.
//        We are able to buy all cars within their deadline. So, total profit that one can earn is 30.
class pairCar implements Comparable<pairCar>{
    int time;
    int rewards;
    pairCar(int time, int rewards){
        this.time=time;
        this.rewards=rewards;
    }
    @Override
    public int compareTo(pairCar o) {
        return this.time-o.time;
    }
}
//Buying 1 car take 1 minute, and we need to maximize the profit as well
// but we also need to buy the car before the time mentioned in array A
// So if we take a current time variable, which will contain the current time
// we can sort both array based on time, so that we dont miss the lesser timeline/deadline
// So we will consider the minimum time slot and add the reward in some box
// next time will be same or greater, if it is same, we can't buy because time is over for that slot
// So we will check if for the same time, reward is greater than previous one, than remove the min time from box
// and insert the new reward in box, now move to next slot, and if time slot is greater than current time
// considert the slot and add the reward in the box
// lets understand with an example:
//        A = [1, 3, 2, 3, 3]
//        B = [5, 6, 1, 3, 9], sort both based on time(A)
// A= 1,2,3,3,3
// B= 5,1,6,3,9
// So current time is 0, so we can consider first slot, So reward box has 5 and current time ++
// so currenttime is 1 now, move to next time is 2, current time is 1, so consider the slot
// reward box has 1 and 5
// move to next, current time is 2, and slot time is 3, so consider it, reward box has 1,5,6
// current time is 3
// next slot has time as 3, So we cant do this task, but check if its reward is greater than any other reward in the box
// yes, its greater than reward 1, so remove and insert 3
// again current time is 3 and slot time is 3, so we cant consider this pair
// but check if its reward is greater than minimum reward in box, yes, its greater than 3
// so remove 3 and enter 9
// at the end, make a sum of box and that is the maximum reward you can get
// what is this box? we are checking min element each time, and if its min that other reward than extract min
// So it is Min Heap.

public class FreeCars {
    public int solve(ArrayList<Integer> A, ArrayList<Integer> B) {
        PriorityQueue<Integer> rewardHeap= new PriorityQueue<>();
        ArrayList<pairCar> timeRewards= new ArrayList<>();
        for(int i=0;i<A.size();i++){
            timeRewards.add(new pairCar(A.get(i),B.get(i)));
        }
        Collections.sort(timeRewards);
        int currentTime=0;
        for(int i=0;i<A.size();i++){
            if(currentTime<timeRewards.get(i).time){
                rewardHeap.offer(timeRewards.get(i).rewards);
                currentTime++;
            }
            else{
                if(timeRewards.get(i).rewards>rewardHeap.peek()){
                    rewardHeap.poll();
                    rewardHeap.offer(timeRewards.get(i).rewards);
                }
            }
        }
        long rewards=0;
        while(rewardHeap.size()>0){
            rewards+=rewardHeap.poll();
        }
        return (int)(rewards%1000000007);

    }
}
