package Trees.LCA_TreesProb;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

//Given a binary tree of integers. All nodes in the binary tree have distinct values. You are given an integer B.
//
//You have to find all the nodes that are at a distance of exactly C from the node containing value B.
//
//Return an array of integers consisting all the nodes that are C distance from node containing value B.
//For Example
//
//        Input 1:
//        1
//        /   \
//        2    3
//        / \  / \
//        4   5 6  7
//        /
//        8
//
//        B = 3
//        C = 3
//        Output 1:
//        [4, 5]
//
//        Input 2:
//        1
//        /  \
//        2    3
//        \
//        4
//        \
//        5
//        B = 4
//        C = 1
//        Output 2:
//        [2, 5]
public class NodesatDistanceKFromANode {
    // In this question, distance can be in the subtree from the node, also it can be in another subtree from previous node
    // keeping in mind, if node is left of previous node then go to right otherwise go to left
    // in the above example: from 4 we have 1 distance apart as 5 and 2 as well.
    // Consider below example:
    //         1
    //        /  \
    //        2    3
    //       / \
    //      8  4
    //     /   \
    //    9     5
    //        B = 2
    //        C = 2


    // So from 2, we have 9 and 5 nodes with 2 distance. also we have 3 from 2 distnace
    // So first we will calculate nodes for 2 subtree which is 9 and 5
    // now we will go one level up, which 1, as we moved 1 level up, means C will also reduce by 1, So C=C-1=1
    // but from 1, distance of 1 is 2 as well, but its not correct answer, so that is why check if 2 is left of 1 or right
    // it is left of 1, So only consider your answer on right
    // how to find previous elements?
    // when finding the node, we can store the path in list
    // Steps:
    // 1. Find the Node and Store the path in the list
    // 2. Count the nodes for K distance
    // 3. Go to previous node from List, Check if it is from left or right and then count the nodes accordingly with K-1 distance
    // 4. Continue the process (repeat 3 until list is not empty)
    public Boolean findPath(TreeNode root, int B, List<TreeNode> path){
        if(root==null) return false;
        if(root.val==B){
            path.add(root);
            return true;
        }
        if(findPath(root.left,B,path) || findPath(root.right,B,path)){
            path.add(root);
            return true;
        }
        return false;
    }
    public void CountNodes(TreeNode root, int K, ArrayList<Integer> output ){
        if(root==null) return;
        if(K==0) {
            output.add(root.val);
            return;
        }
        CountNodes(root.left,K-1,output);
        CountNodes(root.right,K-1,output);
    }
    public ArrayList<Integer> solve(TreeNode A, int B, int C) {

        List<TreeNode> path= new ArrayList<>();
        findPath(A,B,path);
        ArrayList<Integer> output= new ArrayList<>();
        TreeNode node=path.get(0);
        CountNodes(node,C,output);
        // after calculating nodes with distance C, we will be moving to upper node
        // it means we already covered 1 distance, thats why C=C-1
        C=C-1;
        for(int i=1;i<path.size();i++){
            TreeNode curr=path.get(i);
            TreeNode child=path.get(i-1);
            // if C==0, when upper element is C distance apart or we can say, when we move to upper node
            // C becomes 0, it means this is the element which is C distance apart from original found node
            if(C==0) {
                output.add(curr.val);
                break;
            }
            // if child or proccessed node is left child of prev, then move to right(already explained)
            // and pass C-1, because we are moving from curr so we are covering one more distance
            // when moving to curr(upper element), we can not process Curr, because it can calculate for left and right both
            // but we already processed left or right, so that is why we are moving to left or right and then calculating
            // and that is why we are passing C-1
            if(curr.left==child){
                CountNodes(curr.right,C-1,output);
            }
            else{
                CountNodes(curr.left,C-1,output);
            }
            // after the node is processed, move to upper node, and by this we already covered one more distance
            C=C-1;
        }
        return output;
    }
}
