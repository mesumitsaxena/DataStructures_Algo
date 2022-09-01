package Backtracking;

import java.util.ArrayList;
import java.util.Collections;

//Given an integer array A of size N denoting collection of numbers , return all possible permutations.
//
//        NOTE:
//
//        No two entries in the permutation sequence should be the same.
//        For the purpose of this problem, assume that all the numbers in the collection are unique.
//        Return the answer in any order
//Example Input
//        A = [1, 2, 3]
//
//
//        Example Output
//        [ [1, 2, 3]
//        [1, 3, 2]
//        [2, 1, 3]
//        [2, 3, 1]
//        [3, 1, 2]
//        [3, 2, 1] ]
//
//
//        Example Explanation
//        All the possible permutation of array [1, 2, 3].
public class Permutation {
    ArrayList<ArrayList<Integer>> output;
    public ArrayList<ArrayList<Integer>> permute(ArrayList<Integer> A) {
        output = new ArrayList<>();
        PnC(0,A.size(),A);
        return output;
    }
    //Swap the element with ith index with lth index l can start from i to size of array
    //Traverse it, when i==n, then Add the A into output
    // Now swap back the elements at its original place.
    public void PnC(int i,int n,ArrayList<Integer> A){
        if(i==n){
            output.add(new ArrayList<>(A));
            return;
        }
        for(int l=i;l<A.size();l++){
            Collections.swap(A,i,l);
            PnC(i+1,n,A);
            Collections.swap(A,i,l);
        }
    }
}
