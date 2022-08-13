package Tries.Tries1;

import java.util.ArrayList;

//Given an array of words A (dictionary) and another array B (which contain some words).
//
//        You have to return the binary array (of length |B|) as the answer where 1 denotes that the word is present in the dictionary and 0 denotes it is not present.
//
//        Formally, for each word in B, you need to return 1 if it is present in Dictionary and 0 if not.
//
//        Such problems can be seen in real life when we work on any online editor (like Google Documnet), if the word is not valid it is underlined by a red line.
//
//        NOTE: Try to do this in O(n) time complexity.
//Example Input
//        Input 1:
//
//        A = [ "hat", "cat", "rat" ]
//        B = [ "cat", "ball" ]
//        Input 2:
//
//        A = [ "tape", "bcci" ]
//        B = [ "table", "cci" ]
//
//
//        Example Output
//        Output 1:
//
//        [1, 0]
//        Output 2:
//
//        [0, 0]
//
//
//        Example Explanation
//        Explanation 1:
//
//        Only "cat" is present in the dictionary.
//        Explanation 2:
//
//        None of the words are present in the dictionary.
public class SpellingChecker {
    private class Trie{
        public char data;
        public boolean isEnd;
        public Trie[] children;
        public Trie(char data){
            this.data=data;
            isEnd=false;
            children= new Trie[26];
        }
    }
    public void createTrie(String str, Trie root){
        Trie temp=root;
        for(int i=0;i<str.length();i++){
            int idx=str.charAt(i)-'a';
            if(temp.children[idx]==null){
                temp.children[idx]= new Trie(str.charAt(i));
            }
            temp=temp.children[idx];
        }
        temp.isEnd=true;
    }
    public boolean Search(Trie root, String str){
        Trie node=root;
        for(int i=0;i<str.length();i++){
            int idx=str.charAt(i)-'a';
            if(node.children[idx]==null){
                return false;
            }
            node=node.children[idx];
        }
        if(node.isEnd==true) return true;
        return false;
    }
    //first create Trie
    // then search each word in Trie
    public ArrayList<Integer> solve(ArrayList<String> A, ArrayList<String> B) {
        Trie root= new Trie('#');
        for(String str: A){
            createTrie(str,root);
        }
        ArrayList<Integer> output= new ArrayList<>();
        for(String str:B){
            if(Search(root,str)){
                output.add(1);
            }
            else{
                output.add(0);
            }
        }
        return output;
    }
}
