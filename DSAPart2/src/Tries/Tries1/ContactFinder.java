package Tries.Tries1;

import java.util.ArrayList;

//We want to make a custom contacts finder applications as part of our college project. The application must perform two types of operations:
//
//        Type 1: Add name B[i] ,denoted by 0 in vector A where B[i] is a string in vector B denoting a contact name. This must store B[i] as a new contact in the application.
//
//        Type 2: Find partial for B[i] ,denoted by 1 in vector A where B[i] is a string in vector B denoting a partial name to search the application for. It must count the number of contacts starting with B[i].
//
//        You have been given sequential add and find operations. You need to perform each operation in order.
//
//        And return as an array of integers, answers for each query of type 2(denoted by 1 in A) .
//Example Input
//
//        Input 1:
//
//        A = [0, 0, 1, 1]
//        B = ["hack", "hacker", "hac", "hak"]
//        Input 2:
//
//        A = [0, 1]
//        B = ["abcde", "abc"]
//
//
//        Example Output
//
//        Output 1:
//
//
//        [2, 0]
//        Output 2:
//
//        [1]
//
//
//        Example Explanation
//
//        Explanation 1:
//
//
//        We perform the following sequence of operations:
//        Add a contact named "hack".
//        Add a contact named "hacker".
//        Find the number of contact names beginning with "hac". There are currently two contact names in the application and both of them start with "hac", so we have 2.
//        Find the number of contact names beginning with "hak". There are currently two contact names in the application but neither of them start with "hak", so we get0.
//        Explanation 2:
//
//
//        Add "abcde"
//        Find words with prefix "abc". We have answer as 1.

public class ContactFinder {
    private class Trie{
        char data;
        boolean isEnd;
        int freq;
        Trie[] children;
        Trie(char data){
            this.data=data;
            isEnd=false;
            freq=1;
            children= new Trie[26];
        }
    }
    public int searchTrie(Trie root, String str){
        Trie node=root;
        int ans=0;
        for(int i=0;i<str.length();i++){
            int idx=str.charAt(i)-'a';
            if(node.children[idx]==null){
                return 0;
            }
            else{
                ans=node.children[idx].freq;
            }
            node=node.children[idx];
        }
        return ans;
    }
    public void Insert(Trie root, String str){
        Trie node=root;
        for(int i=0;i<str.length();i++){
            int idx=str.charAt(i)-'a';

            if(node.children[idx]==null){
                node.children[idx]=new Trie(str.charAt(i));
            }
            else {
                node.children[idx].freq++;
            }
            node=node.children[idx];
        }
        node.isEnd=true;
    }
    public ArrayList<Integer> solve(ArrayList<Integer> A, ArrayList<String> B) {
        ArrayList<Integer> output= new ArrayList<>();
        Trie root= new Trie('#');
        for(int i=0;i<A.size();i++){
            if(A.get(i)==0){
                Insert(root,B.get(i));
            }
            else{
                output.add(searchTrie(root,B.get(i)));
            }
        }
        return output;
    }
}
