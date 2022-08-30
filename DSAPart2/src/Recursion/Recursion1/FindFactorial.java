package Recursion.Recursion1;

//Write a program to find the factorial of the given number A.
//Example Input
//        Input 1:
//
//        A = 4
//        Input 2:
//
//        A = 1
//
//
//        Example Output
//        Output 1:
//
//        24
//        Output 2:
//
//        1
//
//
//        Example Explanation
//        Explanation 1:
//
//        Factorial of 4 = 4 * 3 * 2 * 1 = 24
//        Explanation 2:
//
//        Factorial of 1 = 1
public class FindFactorial {
    public int solve(int A) {
        if(A==1) return 1;
        return A*solve(A-1);
    }
}
