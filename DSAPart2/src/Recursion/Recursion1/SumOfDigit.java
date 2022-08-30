package Recursion.Recursion1;

//Given a number A, we need to find the sum of its digits using recursion.
//Example Input
//        Input 1:
//
//        A = 46
//        Input 2:
//
//        A = 11
//
//
//        Example Output
//        Output 1:
//
//        10
//        Output 2:
//
//        2
//
//
//        Example Explanation
//        Explanation 1:
//
//        Sum of digits of 46 = 4 + 6 = 10
//        Explanation 2:
//
//        Sum of digits of 11 = 1 + 1 = 2
public class SumOfDigit {
    // example:  123 = > 123%10=3+solve(123/10, which means 12)
    // then 3+12%10=2+solve(12/10, which means 1)
    // then 3+2+solve(1/10)
    // here base condition can be, if num is <10 then return that number itself
    // so 3+2+solve(1/10)=> this function return the number itself, it will retunr 1 and ans will be 3+2+1=6
    public int solve(int A) {
        if(A<10) return A;
        return solve(A/10)+A%10;
    }
}
