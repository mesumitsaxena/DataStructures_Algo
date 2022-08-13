package Tries.Tries1;

import java.lang.*;
import java.util.*;

class pair implements Comparable < pair > {
    int first;
    int second;
    public pair(int a, int b) {
        this.first = a;
        this.second = b;
    }
    @Override
    public int compareTo(pair a) {
        return this.first - a.first;
    }
}
public class AutoComplete {
    public static void main(String[] args) {
        Scanner inp = new Scanner(System.in);
        int t = inp.nextInt();
        inp.nextLine();
        while (t-- > 0) {
            int n, m;
            n = inp.nextInt();
            m = inp.nextInt();
            inp.nextLine();
            String s[] = inp.nextLine().split(" ");
            String temp[] = inp.nextLine().split(" ");
            int[] wt = new int[n];
            for (int i = 0; i < temp.length; i++)
                wt[i] = Integer.parseInt(temp[i]);
            String q[] = inp.nextLine().split(" ");
            solve(s, wt, q);
        }
        inp.close();
    }
    public static void solve(String[] A, int[] W, String[] B) {

        TrieNode root = new TrieNode();
        ArrayList <pair > v = new ArrayList <> ();
        for (int i = 0; i < A.length; i++) {
            v.add(new pair(W[i], i));
        }
        Collections.sort(v);
        for (int i = v.size() - 1; i >= 0; i--) {
            insert(root, A[v.get(i).second], v.get(i).second, W);
        }
        for (int i = 0; i < B.length; i++) {
            ArrayList < pair > ans = new ArrayList < pair > (query(root, B[i], W));
            if (ans.size() == 0) {
                System.out.println(-1 + " ");
            } else {
                for (int j = 0; j < ans.size(); j++) {
                    System.out.print(A[ans.get(j).second] + " ");
                }
                System.out.println();
            }
        }
    }
    public static ArrayList < pair > query(TrieNode root, String prefix, int[] W) {
        TrieNode temp = root;
        ArrayList < pair > ans = new ArrayList < pair > ();
        for (int i = 0; i < prefix.length(); i++) {
            int chr_val = prefix.charAt(i) - 'a';
            if (temp.child[chr_val] == null) {
                temp = temp.child[chr_val];
                break;
            }
            temp = temp.child[chr_val];
        }
        if (temp == null) {
            return ans;
        }
        return temp.idx_ans;
    }
    public static void insert(TrieNode root, String word, int idx, int[] W) {
        TrieNode temp = root;
        for (int i = 0; i < word.length(); i++) {
            int chr_val = word.charAt(i) - 'a';
            if (temp.child[chr_val] == null) {
                temp.child[chr_val] = new TrieNode();
            }
            temp = temp.child[chr_val];
            if (temp.idx_ans.size() < 5) {
                temp.idx_ans.add(new pair(W[idx], idx));
            }
        }
        temp.isend = true;
    }
}
class TrieNode {
    TrieNode[] child;
    ArrayList < pair > idx_ans;
    boolean isend;
    public TrieNode() {
        child = new TrieNode[26];
        for (int i = 0; i < 26; i++) child[i] = null;
        idx_ans = new ArrayList < pair > ();
        isend = false;
    }
}
