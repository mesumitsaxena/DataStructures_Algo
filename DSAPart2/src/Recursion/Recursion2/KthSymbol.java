package Recursion.Recursion2;

//On the first row, we write a 0. Now in every subsequent row, we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.
//
//        Given row number A and index B, return the Bth indexed symbol in row A. (The values of B are 1-indexed.).
//Input Format
//        First argument is an integer A.
//
//        Second argument is an integer B.
//
//
//
//        Output Format
//        Return an integer denoting the Bth indexed symbol in row A.
//
//
//
//        Example Input
//        Input 1:
//
//        A = 2
//        B = 1
//        Input 2:
//
//        A = 2
//        B = 2
//
//
//        Example Output
//        Output 1:
//
//        0
//        Output 2:
//
//        1
//
//
//        Example Explanation
//        Explanation 1:
//
//        Row 1: 0
//        Row 2: 01
//        Explanation 2:
//
//        Row 1: 0
//        Row 2: 01
public class KthSymbol {
    public int solve(int A, int B) {
        if(A==1 || B==0) return 0;
        if(B< 1<<(A-2)){
            return solve(A-1,B);
        }
        else{
            return 1-solve(A-1,B-(1<<(A-2)));
        }
    }
}
