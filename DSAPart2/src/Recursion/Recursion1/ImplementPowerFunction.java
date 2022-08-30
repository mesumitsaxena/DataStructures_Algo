package Recursion.Recursion1;

//Implement pow(A, B) % C.
//        In other words, given A, B and C, Find (AB % C).
//
//        Note: The remainders on division cannot be negative. In other words, make sure the answer you return is non-negative.
//Problem Constraints
//        -109 <= A <= 109
//        0 <= B <= 109
//        1 <= C <= 109
//
//
//        Input Format
//        Given three integers A, B, C.
//
//
//        Output Format
//        Return an integer.
//
//
//        Example Input
//        A = 2, B = 3, C = 3
//
//
//        Example Output
//        2
//
//
//        Example Explanation
//        23 % 3 = 8 % 3 = 2
public class ImplementPowerFunction {
    // normal way is A*pow(A,B-1), means if 2^8=> then it will be like 2*pow(2,8-1=7) => 2*2*pow(2,7-1=6) etc
    // another optimize way is -
    // for 5^4 (answer is 5*5*5*5, 25*5*5, 125*5, 625) => we can write it as 5^2(25)*5^2(25)=625
    // another example: 3^8 can be written as 3^4*3^4
    // 23^16 can be written as 23^8*23*8.
    // but 5^9 can be written as 5^4*5^4*5
    // Sod by this we will recurse only B/2 times and we can use that value to calculate rest of the values
    // So we can say calculate A^B/2 and then check if B is odd or even based on that do the multipication
    // ex: val=pow(A,B/2)
    // if(B is even) then return val*val;
    // if (B is odd) then return val*val*A;
    public int pow(int A, int B, int C) {
        if(A==0) return 0;
        if(B==0) return 1;
        long val=pow(A,B/2,C);
        if(B%2>0){
            return (int)(((val*val)%C*A)%C+C)%C;
        }
        else{
            return (int)((val*val)%C+C)%C;
        }
    }
}
