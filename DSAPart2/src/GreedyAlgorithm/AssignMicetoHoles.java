package GreedyAlgorithm;

import java.util.ArrayList;
import java.util.Collections;

//N Mice and N holes are placed in a straight line. Each hole can accommodate only one mouse.
//
//        The positions of Mice are denoted by array A, and the position of holes is denoted by array B.
//
//        A mouse can stay at his position, move one step right from x to x + 1, or move one step left from x to x − 1. Any of these moves consume 1 minute.
//
//        Assign mice to holes so that the time when the last mouse gets inside a hole is minimized.
//
//Example Input
//        Input 1:
//
//        A = [-4, 2, 3]
//        B = [0, -2, 4]
//        Input 2:
//
//        A = [-2]
//        B = [-6]
//
//
//        Example Output
//        Output 1:
//
//        2
//        Output 2:
//
//        4
//
//
//        Example Explanation
//        Explanation 1:
//
//        Assign the mouse at position (-4 to -2), (2 to 0) and (3 to 4).
//        The number of moves required will be 2, 2 and 1 respectively.
//        So, the time taken will be 2.
//        Explanation 2:
//
//        Assign the mouse at position -2 to -6.
//        The number of moves required will be 4.
//        So, the time taken will be 4.
public class AssignMicetoHoles {
    // we need, minimum time for all the mouse reach to holes.
    // If mouse with minimum distance and hole at minimum distance are assigned then time will be less
    // So, if we sort both the arrays and assign ith mice to ith hole, will give us minimum time
    // Also update the time if any larger time exist, because if any mice enteres the hole in 10 mins, and it is max time,
    // then all other mice already enytered hole before 10 mins only
    public int mice(ArrayList<Integer> A, ArrayList<Integer> B) {
        Collections.sort(A);
        Collections.sort(B);
        int cost=0;
        for(int i=0;i<A.size();i++){
            int val=Math.abs(A.get(i)-B.get(i));
            cost=Math.max(cost,val);
        }
        return cost;
    }
}
