package Recursion.Recursion2.GrayCode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

//The gray code is a binary numeral system where two successive values differ in only one bit.
//
//        Given a non-negative integer A representing the total number of bits in the code, print the sequence of gray code.
//
//        A gray code sequence must begin with 0.
//
//Example Input
//        Input 1:
//
//        A = 2
//        Input 1:
//
//        A = 1
//
//
//        Example Output
//        output 1:
//
//        [0, 1, 3, 2]
//        output 2:
//
//        [0, 1]
//
//
//        Example Explanation
//        Explanation 1:
//
//        for A = 2 the gray code sequence is:
//        00 - 0
//        01 - 1
//        11 - 3
//        10 - 2
//        So, return [0,1,3,2].
//        Explanation 1:
//
//        for A = 1 the gray code sequence is:
//        00 - 0
//        01 - 1
//        So, return [0, 1].
public class GrayCode {
    public ArrayList<Integer> grayCode(int a) {
        if(a==1) return new ArrayList<>(Arrays.asList(0,1));
        List<Integer> valList= grayCode(a-1);
        List<Integer> rev= new ArrayList<>(valList);
        Collections.reverse(rev);
        ArrayList<Integer> output= new ArrayList<>();
        for(int i=0;i<valList.size();i++){
            output.add(valList.get(i)*2);
        }
        for(int i=0;i<rev.size();i++){
            output.add(rev.get(i)*2+1);
        }
        return output;
    }
}
