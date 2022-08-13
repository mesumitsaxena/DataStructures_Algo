package Tries.Tries2;

import java.util.List;

//Given an array of integers A, find and return the maximum result of A[i] XOR A[j], where i, j are the indexes of the array.
//
//       Input Format
//        The only argument given is the integer array A.
//
//
//
//        Output Format
//        Return an integer denoting the maximum result of A[i] XOR A[j].
//
//
//
//        Example Input
//        Input 1:
//
//        A = [1, 2, 3, 4, 5]
//        Input 2:
//
//        A = [5, 17, 100, 11]
//
//
//        Example Output
//        Output 1:
//
//        7
//        Output 2:
//
//        117
public class MaximumXOR {
    // First way is brute force, check all pairs, which is O(N^2)
    // Second way - Observe when the result will be maximum? In XOR, bit is 1 when there is opposite bit
    // when will number be maximum when MSB is 1, So we need to pick a number check its MSB then check for another
    // number whose MSB is opposite, after that same thing for next bit
    // but checking each number leads us O(N^2)
    // OPTIMIZAZTION:
    // Trie can help us here, we can store each numbers bit in the TRIE
    // but dont Insert all the numbers at once
    // there is a 3 step process:
    // 1. Insert the first number
    // 2. pick next number, check bit by bit, if opposite MSB available in the TRIE or not
    // if availble move there, otherwise move to whatever available
    // 3. take the maximum with selected number from TRIE and current number
    // 4. Insert the current number in Trie
    private class Trie{
        int number;
        Trie zero;
        Trie one;
        boolean isEnd;
        Trie(int number){
            this.number=number;
            zero=null;
            one=null;
            isEnd=false;
        }
    }
    public int getNumberofBits(int number){
        int count=0;
        while(number!=0){
            count++;
            number=number>>1;
        }
        return count;
    }
    public void Insert(Trie root, int number, int numberofBits){
        Trie node=root;
        for(int i=numberofBits-1;i>=0;i--){
            if(((1<<i)&number)>0){
                if(node.one==null){
                    node.one= new Trie(1);
                }
                node=node.one;
            }
            else{
                if(node.zero==null){
                    node.zero= new Trie(0);
                }
                node=node.zero;
            }
        }
        node.isEnd=true;
    }
    public int Query(Trie root, int number, int numberOfBits){
        Trie node=root;
        int ans=0;
        for(int i=numberOfBits-1;i>=0;i--){
            if(((1<<i)&number)>0){
                if(node.zero!=null){
                    node=node.zero;
                }
                else{
                    node=node.one;
                }
            }
            else{
                if(node.one!=null){
                    node=node.one;
                }
                else{
                    node=node.zero;
                }
            }
            ans+=(1<<i)*node.number;
        }
        return ans;
    }
    public int solve(List<Integer> A) {
        Trie root= new Trie(-1);
        int maxNumber=Integer.MIN_VALUE;

        for(int num:A){
            maxNumber=Math.max(maxNumber,num);
        }
        int MaxXor=Integer.MIN_VALUE;
        int numberOfBits=getNumberofBits(maxNumber);
        Insert(root, A.get(0),numberOfBits);
        for(int i=1;i<A.size();i++){
            int result=Query(root,A.get(i),numberOfBits);
            result=result^A.get(i);
            MaxXor=Math.max(MaxXor,result);
            Insert(root,A.get(i),numberOfBits);
        }
        return MaxXor;
    }
}
