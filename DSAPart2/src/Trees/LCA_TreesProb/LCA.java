package Trees.LCA_TreesProb;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

//Find the lowest common ancestor in an unordered binary tree A, given two values, B and C, in the tree.
//
//Lowest common ancestor: the lowest common ancestor (LCA) of two nodes and w in a tree or directed acyclic graph
// (DAG) is the lowest (i.e., deepest) node that has both v and w as descendants.
//Example Input
//        Input 1:
//
//
//        1
//        /  \
//        2    3
//        B = 2
//        C = 3
//        Input 2:
//
//        1
//        /  \
//        2    3
//        / \
//        4   5
//        B = 4
//        C = 5
//
//
//        Example Output
//        Output 1:
//
//        1
//        Output 2:
//
//        2
//
//
//        Example Explanation
//        Explanation 1:
//
//        LCA is 1.
//        Explanation 2:
//
//        LCA is 2.
public class LCA {
    // So the idea is we will search the 1st node and store its path in list
    // we will search the 2nd node and store its path in another list
    // then we will check both the list, the last point they have common element is the LCA point
    //          1
    //        /  \
    //        2    3
    //        / \
    //        4   5
    //        B = 4
    //        C = 5
    // In above example: we know LCA is 2, because that is the point intersection point if we take a path from 4 to 5
    // So path from root to 4 is 1->2->4, and path from root to 5 is 1->2->5, we can see, last common point is 2 only
    // So 2 is the answer
    // below are the steps:
    // 1. make a list of path of root to target node 1
    // 2. make a list of path of root to target node 2
    // Iterate both list and find the last common value
    public boolean findPath(TreeNode root, List<Integer> list, int k){
        if(root==null) return false;
        if(root.val==k){
            list.add(root.val);
            return true;
        }
        if(findPath(root.left,list,k) || findPath(root.right,list,k)){
            list.add(root.val);
            return true;
        }
        return false;
    }
    public int lca(TreeNode A, int B, int C) {
        List<Integer> list1= new ArrayList<>();
        List<Integer> list2= new ArrayList<>();
        boolean firstNode=findPath(A,list1,B);
        boolean secondNode=findPath(A,list2,C);
        if(firstNode==false || secondNode==false) return -1;
        int i=0;

        Collections.reverse(list1);
        Collections.reverse(list2);
        while(i<list1.size() && i<list2.size()){
            if(list1.get(i)!=list2.get(i)){
                return list1.get(i-1);
            }
            i++;

        }
        if(i==0) i++;
        return list2.get(i-1);
    }
}
