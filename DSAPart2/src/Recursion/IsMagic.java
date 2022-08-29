package Recursion;

//Given a number A, check if it is a magic number or not.
//
//        A number is said to be a magic number if the sum of its digits is calculated till a single digit recursively by adding the sum of the digits after every addition. If the single digit comes out to be 1, then the number is a magic number.
//Example Input
//        Input 1:
//
//        A = 83557
//        Input 2:
//
//        A = 1291
//
//
//        Example Output
//        Output 1:
//
//        1
//        Output 2:
//
//        0
//
//
//        Example Explanation
//        Explanation 1:
//
//        Sum of digits of (83557) = 28
//        Sum of digits of (28) = 10
//        Sum of digits of (10) = 1.
//        Single digit is 1, so it's a magic number. Return 1.
//        Explanation 2:
//
//        Sum of digits of (1291) = 13
//        Sum of digits of (13) = 4
//        Single digit is not 1, so it's not a magic number. Return 0.
public class IsMagic {
    // Code is self explanatory
    public int sumOfDigit(int num){
        if(num<10){
            return num;
        }
        return sumOfDigit(num/10)+num%10;
    }
    public int solve(int A) {

        int val=sumOfDigit(A);
        if(val<10){
            if(val==1){
                return 1;
            }
            else{
                return 0;
            }
        }
        return solve(val);
    }
}
