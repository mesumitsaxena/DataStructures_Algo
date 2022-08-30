package Recursion.Recursion1;

import java.util.Scanner;

//Write a recursive function that, given a string S, prints the characters of S in reverse order.
//Input Format
//        First line of input contains a string S.
//
//
//
//        Output Format
//        Print the character of the string S in reverse order.
//
//
//
//        Example Input
//        Input 1:
//
//        scaleracademy
//        Input 2:
//
//        cool
//
//
//        Example Output
//        Output 1:
//
//        ymedacarelacs
//        Output 2:
//
//        looc
//
//
//        Example Explanation
//        Explanation 1:
//
//        Print the reverse of the string in a single line.
class StringReverse{
    public void reverse(String s,int index){
        if(index>=s.length()){
            return;
        }
        reverse(s,index+1);
        System.out.print(s.charAt(index));
    }
}
public class PrintReverseString {
    public static void main(String[] args) {
        // YOUR CODE GOES HERE
        // Please take input and print output to standard input/output (stdin/stdout)
        // DO NOT USE ARGUMENTS FOR INPUTS
        // E.g. 'Scanner' for input & 'System.out' for output
        Scanner myObj = new Scanner(System.in);  // Create a Scanner object

        String s = myObj.nextLine();  // Read user input
        StringReverse obj= new StringReverse();
        obj.reverse(s,0);

    }
}
