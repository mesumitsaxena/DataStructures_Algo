package Tries.Tries1;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

//Given two arrays of strings A of size N and B of size M.
//
//        Return a binary string C where C[i] = '1' if B[i] can be found in dictionary A using exactly one modification in B[i], Else C[i] = '0'.
//
//        NOTE: modification is defined as converting a character into another character.
//Example Input
//
//        Input 1:
//
//        A = [data, circle, cricket]
//        B = [date, circel, crikket, data, circl]
//        Input 2:
//
//        A = [hello, world]
//        B = [hella, pello, pella]
//
//
//        Example Output
//
//        Output 1:
//
//        "10100"
//        Output 2:
//
//        "110"
//Example Explanation
//
//        Explanation 1:
//
//        1. date = dat*(can be found in A)
//        2. circel =(cannot be found in A using exactly one modification)
//        3. crikket = cri*ket(can be found in A)
//        4. data = (cannot be found in A using exactly one modification)
//        5. circl = (cannot be found in A using exactly one modification)
//        Explanation 2:
//
//        Only pella cannot be found in A using only one modification.
public class ModifiedSearch {
    private class Trie{
        char data;
        Trie[] children;
        boolean isEnd;
        Trie(char data){
            this.data=data;
            children= new Trie[26];
            isEnd=false;
        }

    }
    public void Insert(Trie root, String word){
        Trie node=root;
        for(int i=0;i<word.length();i++){
            int idx=word.charAt(i)-'a';
            if(node.children[idx]==null){
                node.children[idx]= new Trie(word.charAt(i));
            }
            node=node.children[idx];
        }
        node.isEnd=true;
    }
    public boolean query(Trie root, String word, int indx, int flag){
        int length=word.length();
        boolean ans=false;

        if(indx==length){
            if(flag==1 && root.isEnd==true){
                return true;
            }
            return false;
        }

        char letter=word.charAt(indx);
        if(flag==0){
            for(int i=0;i<26;i++){
                if(root.children[i]!=null){
                    if(root.children[i].data==letter){
                        ans=ans||query(root.children[i],word,indx+1,flag );
                    }
                    else{
                        ans=ans||query(root.children[i],word,indx+1,1-flag );
                    }
                }
            }
        }
        else{
            int idx=letter-'a';
            if(root.children[idx]!=null){
                ans=ans||query(root.children[idx],word,indx+1,flag );
            }
        }
        return ans;
    }
    public String solve(ArrayList<String> A, ArrayList<String> B) {
        Trie root = new Trie('#');
        for (String a: A)
            Insert(root,a);
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < B.size(); i++) {
            if (query(root, B.get(i),0, 0) == true)
                res.append('1');
            else
                res.append('0');
        }
        return res.toString();
    }
}
