package Backtracking;

import java.util.ArrayList;
import java.util.Collections;

//Problem Description
//        Given a set of distinct integers A, return all possible subsets.
//
//        NOTE:
//
//        Elements in a subset must be in non-descending order.
//        The solution set must not contain duplicate subsets.
//        Also, the subsets should be sorted in ascending ( lexicographic ) order.
//        The list is not necessarily sorted.
//
//
//        Problem Constraints
//        1 <= |A| <= 16
//        INTMIN <= A[i] <= INTMAX
//
//
//        Input Format
//        First and only argument of input contains a single integer array A.
//
//
//
//        Output Format
//        Return a vector of vectors denoting the answer.
//
//
//
//        Example Input
//        Input 1:
//
//        A = [1]
//        Input 2:
//
//        A = [1, 2, 3]
//
//
//        Example Output
//        Output 1:
//
//        [
//        []
//        [1]
//        ]
//        Output 2:
//
//        [
//        []
//        [1]
//        [1, 2]
//        [1, 2, 3]
//        [1, 3]
//        [2]
//        [2, 3]
//        [3]
//        ]
public class GeneratingAllSubsets {
    public ArrayList<ArrayList<Integer>> subsets(ArrayList<Integer> A) {
        Collections.sort(A);
        ArrayList<ArrayList<Integer>> gList= new ArrayList<>();
        generatSubsets(0,A.size(),A,new ArrayList<>(),gList);
        Collections.sort(gList,(ArrayList<Integer> first, ArrayList<Integer> second) ->{
            for(int i=0;i<first.size() && i<second.size();i++){
                if(first.get(i)<second.get(i)){
                    return -1;
                }
                if(first.get(i)>second.get(i)){
                    return 1;
                }
            }
            if(first.size()>second.size()){
                return 1;
            }
            return -1;
        });
        return gList;
    }
    public void generatSubsets(int i, int n,ArrayList<Integer> A, ArrayList<Integer> list, ArrayList<ArrayList<Integer>> gList){
        if(i==n){
            gList.add(new ArrayList<>(list));
            return;
        }
        list.add(A.get(i));
        generatSubsets(i+1,n,A,list,gList);
        list.remove(A.size()-1);
        generatSubsets(i+1,n,A,list,gList);
    }
}
