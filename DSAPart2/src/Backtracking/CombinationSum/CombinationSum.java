package Backtracking.CombinationSum;

import javax.swing.*;
import java.util.ArrayList;
import java.util.Collections;

public class CombinationSum {
    public ArrayList<ArrayList<Integer>> combinationSum(ArrayList<Integer> A, int B) {
        ArrayList<ArrayList<Integer>> output= new ArrayList<>();
        Collections.sort(A);
        ArrayList<Integer> uniqueCandidate= new ArrayList<>();
        uniqueCandidate.add(A.get(0));
        for(int i=1;i<A.size();i++){
            if(A.get(i-1)!=A.get(i)){
                uniqueCandidate.add(A.get(i));
            }
        }
        combSum(0,new ArrayList<>(),uniqueCandidate,B,0,output);
        return output;
    }
    public void combSum(int i, ArrayList<Integer> ans, ArrayList<Integer> A, int B, int sum, ArrayList<ArrayList<Integer>> output){
        if(sum>B) return;
        if(sum==B){
            ArrayList<Integer> newAns= new ArrayList<>(ans);
            output.add(newAns);
            return;
        }
        for(int j=i;j<A.size();j++){
            sum+=A.get(j);
            ans.add(A.get(j));
            combSum(j,ans,A,B,sum, output);
            sum-=A.get(j);
            ans.remove(ans.size()-1);
        }

    }
}
