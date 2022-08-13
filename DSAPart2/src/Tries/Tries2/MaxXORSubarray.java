package Tries.Tries2;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

//Given an array, A of integers of size N. Find the subarray AL, AL+1, AL+2, ... AR with 1<=L<=R<=N, which has maximum XOR value.
//
//NOTE: If there are multiple subarrays with the same maximum value, return the subarray with minimum length. If the length is the same, return the subarray with the minimum starting index.
//Example Input
//        Input 1:
//
//        A = [1, 4, 3]
//        Input 2:
//
//        A = [8]
//
//
//        Example Output
//        Output 1:
//
//        [2, 3]
//        Output 2:
//
//        [1, 1]
//
//
//        Example Explanation
//        Explanation 1:
//
//        There are 6 possible subarrays of A:
//        subarray            XOR value
//        [1]                     1
//        [4]                     4
//        [3]                     3
//        [1, 4]                  5 (1^4)
//        [4, 3]                  7 (4^3)
//        [1, 4, 3]               6 (1^4^3)
//
//        [4, 3] subarray has maximum XOR value. So, return [2, 3].
//        Explanation 2:
//
//        There is only one element in the array. So, the maximum XOR value is equal to 8 and the only possible subarray is [1, 1].
public class MaxXORSubarray {
    // Here Sub arrays can be formed as prefix array as  we can commulate the subarray in 1 value of XOR from left
    // after that we just need to find the maximum XOR of a pair from prefix array
    private class Trie{
        int number;
        Trie zero;
        Trie one;
        boolean isEnd;
        int index;
        Trie(int number){
            this.number=number;
            zero=null;
            one=null;
            isEnd=false;
            this.index=-1;
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
    public void Insert(Trie root, int number, int numberofBits, int ind){
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
        node.index=ind;
    }
    public List<Integer> Query(Trie root, int number, int numberOfBits){
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
        return new ArrayList<>(Arrays.asList(ans,node.index));
    }
    public List<Integer> solve(List<Integer> A) {
        Trie root= new Trie(-1);
        List<Integer> prefixArray= new ArrayList<>();
        prefixArray.add(0);
        for(int i=0;i<A.size();i++){
            prefixArray.add(prefixArray.get(i)^A.get(i));
        }
        int maxNumber=Integer.MIN_VALUE;

        for(int num:prefixArray){
            maxNumber=Math.max(maxNumber,num);
        }
        int MaxXor=Integer.MIN_VALUE;
        int numberOfBits=getNumberofBits(maxNumber);
        int l=0;
        int r=0;
        Insert(root, prefixArray.get(0),numberOfBits,0);
        for(int i=1;i<prefixArray.size();i++){
            List<Integer> result=Query(root,prefixArray.get(i),numberOfBits);
            int val=result.get(0)^prefixArray.get(i);
            if(MaxXor<val){
                MaxXor=val;
                l=result.get(1);
                r=i;
            }
            Insert(root,prefixArray.get(i),numberOfBits,i);
        }
        return new ArrayList<>(Arrays.asList(l+1,r));
    }
}
