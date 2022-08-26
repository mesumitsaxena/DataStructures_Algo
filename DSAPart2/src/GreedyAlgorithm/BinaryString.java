package GreedyAlgorithm;

//You are given a string A consisting of 1's and 0's. Now the task is to make the string consisting of only 1's. But you are allowed to perform only the following operation:
//
//        Take exactly B consecutive string elements and change 1 to 0 and 0 to 1.
//        Each operation takes 1 unit time, so you have to determine the minimum time required to only make the string of 1's. If not possible, return -1.
//Input Format
//        The first argument is a string A consisting of 1's and 0's.
//        The second argument is an integer B which represents the number of consecutive elements which can be changed.
//
//
//
//        Output Format
//        Return an integer which is the minimum time to make the string of 1's only or -1 if not possible.
//
//
//
//        Example Input
//        Input 1:
//
//        A = "00010110"
//        B = 3
//        Input 2:
//
//        A = "011"
//        B = 3
//
//
//        Example Output
//        Output 1:
//
//        3
//        Output 2:
//
//        -1
//
//
//        Example Explanation
//        Explanation 1:
//
//        You can get 1 by first changing the leftmost 3 elements, getting to 11110110, then the rightmost 3, getting to 11110001,
//        and finally the 3 left out 0's to 11111111; In 3 unit time.
//        Explanation 2:
//
//        It's not possible to convert the string into string of all 1's.
public class BinaryString {
    //Solution is for each bit, check if it is 0, then flip next B chars and in the end check if all the bits are 1 or not
    // but it is O(N*B) TC, if B is near to N, then TC will be O(N^2)
    // Solution 2: take an extra space, an extra array and a variable called XOR, which represents if bit is flipped or not
    // extra array will check if for an i in A if bit is flipped then make 1 at i+B element in temp array
    // by this we will know that from i-B to i-1 bits are flipped
    // if XOR is 0 and A[i] is also 0, it means bit is not yet flipped so flip the bit, by XOR=XOR^1
    // as 0^1=1 and 1^1=1, so by this we will be able to know if bit is flipped or not
    // after changing the bit means after updating xor,
    // update the bit in temp array as well at i+Bth position so that we will get to know till when bits are changed
    // and once we reach there xor will again change back to 0 again.
    // we will check that condition by doing xor^=temp[i], each time
    // at the end, if xor^A[i] is 0 at any point means bits are not yet changed and it is 0 So return -1
    // else number of operation
    // refer below code
    public int solve(String A, int B) {
        int[] temp= new int[A.length()];
        int xor=0;
        int count=0;
        for(int i=0;i<=A.length()-B;i++){
            xor^=temp[i];
            if((xor==0 && A.charAt(i)=='0') || (xor==1 && A.charAt(i)=='1')){
                xor^=1;
                if(i+B <A.length()){
                    temp[i+B]=1;
                }
                count++;
            }
        }
        for(int j=A.length()-B+1;j<A.length();j++){
            xor^=temp[j];
            int val=A.charAt(j)-'0';
            if((xor^val)==0){
                return -1;
            }
        }
        return count;
    }
}
