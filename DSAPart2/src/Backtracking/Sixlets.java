package Backtracking;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;

//Given a array of integers A of size N and an integer B.
//
//        Return number of non-empty subsequences of A of size B having sum <= 1000
//Input Format
//        The first argument given is the integer array A.
//
//        The second argument given is the integer B.
//
//
//
//        Output Format
//        Return number of subsequences of A of size B having sum <= 1000.
//
//
//
//        Example Input
//        Input 1:
//
//        A = [1, 2, 8]
//        B = 2
//        Input 2:
//
//        A = [5, 17, 1000, 11]
//        B = 4
//
//
//        Example Output
//        Output 1:
//
//        3
//        Output 2:
//
//        0
//
//
//        Example Explanation
//        Explanation 1:
//
//        {1, 2}, {1, 8}, {2, 8}
//        Explanation 1:
//
//        No valid subsequence
public class Sixlets {
    int count=0;
    public int solve(ArrayList<Integer> A, int B) {
        Sixlets(0,A,B,0,0);
        return count;
    }
    public void Sixlets(int i, ArrayList<Integer> A, int B, int l, int sum){
        if(i==A.size()){
            if(l==B && sum<=1000){
                count++;
            }
            return;
        }
        sum+=A.get(i);
        l++;
        Sixlets(i+1,A,B,l,sum);
        sum-=A.get(i);
        l--;
        Sixlets(i+1,A,B,l,sum);

    }
}
