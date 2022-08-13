package Tries.Tries1;

import java.util.ArrayList;

//Given a list of N words, find the shortest unique prefix to represent each word in the list.
//
//        NOTE: Assume that no word is the prefix of another. In other words, the representation is always possible
//Example Input
//        Input 1:
//
//        A = ["zebra", "dog", "duck", "dove"]
//        Input 2:
//
//        A = ["apple", "ball", "cat"]
//
//
//        Example Output
//        Output 1:
//
//        ["z", "dog", "du", "dov"]
//        Output 2:
//
//        ["a", "b", "c"]
//
//
//        Example Explanation
//        Explanation 1:
//
//        Shortest unique prefix of each word is:
//        For word "zebra", we can only use "z" as "z" is not any prefix of any other word given.
//        For word "dog", we have to use "dog" as "d" and "do" are prefixes of "dov".
//        For word "du", we have to use "du" as "d" is prefix of "dov" and "dog".
//        For word "dov", we have to use "dov" as "d" and do" are prefixes of "dog".
//
//        Explanation 2:
//
//        "a", "b" and c" are not prefixes of any other word. So, we can use of first letter of each to represent.
public class ShortestUniquePrefix {
    //we will create a Trie DS first and in Trie DS, we will have freq which will tell us the number of times
    // that character occurs for multiple strings
    // Unique prefix is when we found a char with freq 1, then that string is unqiue prefix
    // because if freq is more than 1, then it means multiple strings have the same preix
    // So once we reached to freq =1, it means no other string reached it till here
    //1. Create Trie DS
    //2. Search for a freq 1 for each word, until dont find freq 1, add the chars into answer string
    //3. once the found the char with freq 1, return the string
    private class Trie{
        char data;
        int freq;
        Trie[] children;
        Trie(char data){
            this.data=data;
            freq=1;
            children= new Trie[26];
        }
    }
    public void createTrie(Trie root, String str){
        Trie node=root;
        for(int i=0;i<str.length();i++){
            int idx=str.charAt(i)-'a';
            if(node.children[idx]==null){
                node.children[idx]= new Trie(str.charAt(i));

            }
            else{
                node.children[idx].freq++;
            }
            node=node.children[idx];
        }
    }
    public String searchTrie(Trie root, String str){
        Trie node= root;
        String ans="";
        for(int i=0;i<str.length();i++){
            int idx=str.charAt(i)-'a';
            ans+=node.children[idx].data;
            if(node.children[idx].freq==1){
                return ans;
            }
            node=node.children[idx];
        }
        return ans;
    }
    public ArrayList<String> prefix(ArrayList<String> A) {
        Trie root= new Trie('#');
        for(String str: A){
            createTrie(root,str);
        }
        ArrayList<String> output= new ArrayList<>();
        for(String str: A){
            output.add(searchTrie(root,str));
        }
        return output;
    }
}
