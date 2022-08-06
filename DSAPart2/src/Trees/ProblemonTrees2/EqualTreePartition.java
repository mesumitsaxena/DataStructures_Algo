package Trees.ProblemonTrees2;

import com.sun.source.tree.Tree;

import java.util.HashSet;

//Given a binary tree A. Check whether it is possible to partition the tree to two
// trees which have equal sum of values after removing exactly one edge on the original tree.
//Example Input
//        Input 1:
//
//
//        5
//        /  \
//        3    7
//        / \  / \
//        4  6  5  6
//        Input 2:
//
//
//        1
//        / \
//        2   10
//        / \
//        20  2
//
//
//        Example Output
//        Output 1:
//
//        1
//        Output 2:
//
//        0
//
//
//        Example Explanation
//        Explanation 1:
//
//        Remove edge between 5(root node) and 7:
//        Tree 1 =                                               Tree 2 =
//        5                                                     7
//        /                                                     / \
//        3                                                     5   6
//        / \
//        4   6
//        Sum of Tree 1 = Sum of Tree 2 = 18
//        Explanation 2:
//
//        The given Tree cannot be partitioned.
public class EqualTreePartition {
    // The basic idea is we need to find the sum of whole tree(N) and check if is there any sum of nodes of N/2 exist or not
    // Tree can be partitioned equally only when there is a subtree of sum of N/2 exist
    // So we will store each subTree sum in hashset and then in the end check if N/2 sum exist or not

    public long sumOfSubTree(TreeNode root, HashSet<Long> set){
        if(root==null) return 0;
        long sum=(long)root.val+sumOfSubTree(root.left,set)+sumOfSubTree(root.right,set);
        if(!set.contains(sum)){
            set.add(sum);
        }
        return sum;
    }
    public int solve(TreeNode A) {
        HashSet<Long> set= new HashSet<>();
        long sum=sumOfSubTree(A,set);
        if(set.contains(sum/2)){
            return 1;
        }
        return 0;
    }
}
