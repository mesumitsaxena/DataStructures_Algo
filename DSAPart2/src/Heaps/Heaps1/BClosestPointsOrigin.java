package Heaps.Heaps1;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.PriorityQueue;
//We have a list A of points (x, y) on the plane. Find the B closest points to the origin (0, 0).
//
//        Here, the distance between two points on a plane is the Euclidean distance.
//
//        You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in.)
//
//        NOTE: Euclidean distance between two points P1(x1, y1) and P2(x2, y2) is sqrt( (x1-x2)2 + (y1-y2)2 ).
//Example Input
//        Input 1:
//
//        A = [
//        [1, 3],
//        [-2, 2]
//        ]
//        B = 1
//        Input 2:
//
//        A = [
//        [1, -1],
//        [2, -1]
//        ]
//        B = 1
//
//
//        Example Output
//        Output 1:
//
//        [ [-2, 2] ]
//        Output 2:
//
//        [ [1, -1] ]
//
//
//        Example Explanation
//        Explanation 1:
//
//        The Euclidean distance will be sqrt(10) for point [1,3] and sqrt(8) for point [-2,2].
//        So one closest point will be [-2,2].
//        Explanation 2:
//
//        The Euclidean distance will be sqrt(2) for point [1,-1] and sqrt(5) for point [2,-1].
//        So one closest point will be [1,-1].
//class sqrtSquareSum implements Comparator<ArrayList<Integer>>{
//
//
//    @Override
//    public int compare(ArrayList<Integer> o1, ArrayList<Integer> o2) {
//        return (o2.get(0)*o2.get(0)+o2.get(1)*o2.get(1)) - (o1.get(0)*o1.get(0)+o1.get(1)*o1.get(1));
//    }
//}
class sqrtSquareSumforArray implements Comparator<ArrayList<Integer>>{


    @Override
    public int compare(ArrayList<Integer> o1, ArrayList<Integer> o2) {
        return (o1.get(0)*o1.get(0)+o1.get(1)*o1.get(1)) - (o2.get(0)*o2.get(0)+o2.get(1)*o2.get(1));
    }
}
// in order to get the minimum SQRT((X1-X2)^2+(Y1-Y2)^2) from origin, we need to sort the array as a pair
// Also, we know we need to check the distance from origin it means we need to check the instance from co-ordinate (0,0)
// So formula will be SQRT((0-X2)^2+(0-Y2)^2), as SQRT of 3 is always smaller than SQRT of 5 so we just need to check the number
//no need to check for SQRT, So create a custom comparator class and implement accordingly
// we can also use a heap but here 2d array can also work
public class BClosestPointsOrigin {
    public ArrayList<ArrayList<Integer>> solve(ArrayList<ArrayList<Integer>> A, int B) {

        ArrayList<ArrayList<Integer>> output= new ArrayList<>();
        Collections.sort(A, new sqrtSquareSumforArray());
        for(int i=0;i<B;i++){
            output.add(A.get(i));
        }
        return output;
//        PriorityQueue<ArrayList<Integer>> pQ= new PriorityQueue<>(Collections.reverseOrder(new sqrtSquareSum()));
//        for(int i=0;i<A.size();i++){
//            pQ.add(A.get(i));
//        }
//        for(int i=0;i<B;i++){
//            ArrayList<Integer> val=pQ.poll();
//            output.add(val);
//        }
//        return output;
    }
}
