package Tries.Tries2;

import java.util.*;

//Rishabh was sitting ideally in his office and then suddenly his boss gave him some operations to perform.
//
//        You being his friend tried to help him in finishing the task fast.
//
//        So you have to perform Q operation of two types:
//
//        Operation 1: INSERT : You are given an pair of (string, integer).The string represents the key and the integer represents the value. Insert the key-value pair in the hash and If the key already exists in hash, then the original key-value pair will be overridden to the new one.
//        Operation 2: SUM : you'll be given an pair of (string, -1) where string representing the prefix, and you need to return the sum of all the pairs' value in the hash whose key starts with the prefix.
//First argument is an string array A of size Q denoting the first parameter of each operations.
//
//        Seond argument is an integer array B of size Q denoting the second parameter of each operations.
//
//        NOTE: ith query will be like (A[i], B[i])
//Example Input
//
//        Input 1:
//
//        A = ["apple", "ap", "app", "ap"]
//        B = [3, -1, 2, -1]
//        Input 2:
//
//        A = ["ban", "banana", "ba"]
//        B = [10, -1, -1]
//
//
//        Example Output
//
//        Output 1:
//
//        [3, 5]
//        Output 2:
//
//        [0, 10]
//
//
//        Example Explanation
//
//        Explanation 1:
//
//        1. (A[0], B[0]) is a type-1 operation as B[0] != -1 so we will insert "apple" in our hash and store its value as 3.
//        2. (A[1], B[1]) is a type-2 operation as B[1] == -1 so we will search for every string inserted in our
//        hash whose prefix is  "ap". Only "apple" has its prefix as "ap" so we will return 3
//        3. (A[2], B[2]) is a type-1 operation as B[2] != -1 so we will insert "app" in our hash and store its value as 2.
//        4. (A[3], B[3]) is a type-2 operation as B[3] == -1 so we will search for every string inserted in our
//        hash whose prefix is  "ap". So both ["apple", "app"] has its prefix as "ap" so we will return 3 + 2 i.e 5
//        Explanation 2:
//
//        1. (A[0], B[0]) is a type-1 operation as B[0] != -1 so we will insert "ban" in our hash and store its value as 10.
//        2. (A[1], B[1]) is a type-2 operation as B[1] == -1 so we will search for every string inserted in our
//        hash whose prefix is  "banana". So there doesn't exist any string whose prefix is "banana" so we will return 0
//        3. (A[2], B[2]) is a type-2 operation as B[2] == -1 so we will search for every string inserted in our
//        hash whose prefix is  "ba". Only "ban" has its prefix as "ba" so we will return 10.
public class MapSumPairs {
    private class Trie{
        char data;
        int weight;
        Trie[] children;
        boolean isEnd;
        Trie(char data, int val){
            this.data=data;
            this.weight=val;
            children= new Trie[26];
        }
    }
    public void Insert(Trie root, String word, int val){
        Trie node=root;
        for(int i=0;i<word.length();i++){
            int idx=word.charAt(i)-'a';
            if(node.children[idx]==null){
                node.children[idx]= new Trie(word.charAt(i),val);
            }
            else{
                node.children[idx].weight+=val;
            }
            node=node.children[idx];
        }
        node.isEnd=true;
    }
    public int Search(Trie root, String word){
        Trie node=root;
        for(int i=0;i<word.length();i++){
            int idx=word.charAt(i)-'a';
            if(node.children[idx]==null){
                return 0;
            }
            node=node.children[idx];
        }
        return node.weight;
    }
    public ArrayList<Integer> solve(ArrayList<String> A, ArrayList<Integer> B) {
        Trie root= new Trie('#',-1);
        ArrayList<Integer> ans= new ArrayList<>();
        Map<String, Integer> map= new HashMap<>();
        for(int i=0;i<B.size();i++){
            if(B.get(i)==-1){
                ans.add(Search(root,A.get(i)));
            }
            else{
                if(map.containsKey(A.get(i))){
                    int weight=map.get(A.get(i));
                    Insert(root, A.get(i),weight- B.get(i));
                    map.put(A.get(i),B.get(i));
                }
                else{
                    map.put(A.get(i),B.get(i));
                    Insert(root, A.get(i),B.get(i));
                }

            }
        }
        return ans;
    }
}
