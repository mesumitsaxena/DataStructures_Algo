package GreedyAlgorithm;

import java.util.ArrayList;
import java.util.Map;

//N children are standing in a line. Each child is assigned a rating value.
//
//        You are giving candies to these children subjected to the following requirements:
//
//        Each child must have at least one candy.
//        Children with a higher rating get more candies than their neighbors.
//        What is the minimum number of candies you must give?
//Example Input
//        Input 1:
//
//        A = [1, 2]
//        Input 2:
//
//        A = [1, 5, 2, 1]
//
//
//        Example Output
//        Output 1:
//
//        3
//        Output 2:
//
//        7
//
//
//        Example Explanation
//        Explanation 1:
//
//        The candidate with 1 rating gets 1 candy and candidate with rating 2 cannot get 1 candy as 1 is its neighbor.
//        So rating 2 candidate gets 2 candies. In total, 2 + 1 = 3 candies need to be given out.
//        Explanation 2:
//
//        Candies given = [1, 3, 2, 1]
public class DistributedCandy {
    // We as a distributer of candies wants to minimize the candies, So we being greedy, only distribute the candy
    // which is required keeping the constraints in minds.
    // So 1st constraints says, each children must have 1 candy
    // now 2nd constraints have 2 parts of it-
    // 1. any children at index i, if it has higher number then previous student at index i-1, then
    // ith student should have more candies than i-1th child, So as we want to minimize the candy, we can only increase 1 candy from previous
    // by which our constraints will also be satisfied
    // 2. any children at index i, if it has higher number then next student at index i+1, then
    // ith student should have more candies than i+1th child, So as want to minimize the candy, we can only incremenet 1 candy from next student
    // by which our constraints will be satisfied
    // now considering the above 2 conditions, we can iterate the array from left to right and check the previous student rating or number
    // and make the decision, if i has more rating then i-1, then increase 1 candy from previous child
    // if ith student have less rating then i-1th student, then constraints 2 will not be apply
    // but as per constraints 1, we should give a child atleast 1 candy, so we will give 1 candy only
    // after distributing candies on left to right, prepare the output array which will have
    // number of candies distributed. now apply the same from right to left as well on the same output array
    // NOTE: there are situation, when for given i, child has already got lot many candies because it has greater number than i-1
    // Suppose it got 4 candies, now, ith child also have greater number than i+1, so from right traversal, we might want to change
    // ith value, suppose i+1th child has only 1 candy, so ith child will have 2 candy, but it already have 4 candy, we cant minimize
    // as i-1 might have 3, So in that case, check while right traversal if ith child have more candy then i+1th child
    // then ignore.
    //A = [1, 5, 2, 1] example:
    // left traversal => 1, 2, 1, 1
    // right traversal => 1  3  2  1 => so total 7
    public int candy(ArrayList<Integer> A) {
        ArrayList<Integer> output= new ArrayList<>();
        output.add(1);
        for(int i=1;i<A.size();i++){
            if(A.get(i-1)<A.get(i)){
                output.add(output.get(i-1)+1);
            }
            else{
                output.add(1);
            }
        }
        for(int i=output.size()-2;i>=0;i--){
            if(A.get(i+1)<A.get(i)){
                int val=output.get(i+1)+1;
                val= Math.max(output.get(i),val);
                output.set(i,val);
            }

        }
        int numberofCandies=0;
        for(int i=0;i<output.size();i++){
            numberofCandies+=output.get(i);
        }
        return numberofCandies;
    }
}
