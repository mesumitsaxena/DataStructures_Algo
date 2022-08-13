package Tries.Tries2;

import java.util.ArrayList;

//Given a phone directory in the form of string array A containing N numeric strings.
//
//        If any phone number is prefix of another phone number then phone directory is invalid else it is valid.
//
//        You need to check whether the given phone directory is valid or not if it is valid then return 1 else return 0.
//Example Input
//
//        Input 1:
//
//        A = ["1234", "2342", "567"]
//        Input 2:
//
//        A = ["00121", "001"]
//
//
//        Example Output
//
//        Output 1:
//
//        1
//        Output 2:
//
//        0
//
//
//        Example Explanation
//
//        Explanation 1:
//
//        No number is prefix of any other number so phone directory is valid so we will return 1.
//        Explanation 2:
//
//        "001" is prefix of "00121" so phone directory is invalid so we will return 0.
public class ValidPhoneDirectory {
    private class Trie{
        int number;
        Trie[] children;
        boolean isEnd;
        Trie(int number){
            this.number=number;
            children= new Trie[10];
            isEnd=false;
        }
    }
    public boolean Insert(Trie root, String number){
        Trie node=root;
        for(int i=0;i<number.length();i++){
            int idx=number.charAt(i)-'0';
            if(node.children[idx]==null){
                node.children[idx]= new Trie(number.charAt(i));
            }
            else{
                return false;
            }
            node=node.children[idx];
        }
        node.isEnd=true;
        return true;
    }

    public int solve(ArrayList<String> A) {
        Trie root= new Trie('#');
        for(String str:A){
            if(!Insert(root,str)){
                return 0;
            }
        }
        return 1;
    }
}
