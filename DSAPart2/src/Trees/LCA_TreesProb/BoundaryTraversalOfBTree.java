package Trees.LCA_TreesProb;

import java.util.ArrayList;

//binary tree, return the values of its boundary in anti-clockwise direction starting from the root. Boundary includes left boundary, leaves, and right boundary in order without duplicate nodes.
//
// Left boundary is defined as the path from the root to the left-most node. Right boundary is defined as the path from the root to the right-most node. If the root doesn't have left subtree or right subtree, then the root itself is left boundary or right boundary. Note this definition only applies to the input binary tree, and not applies to any subtrees.
//
//The left-most node is defined as a leaf node you could reach when you always firstly travel to the left subtree if exists. If not, travel to the right subtree. Repeat until you reach a leaf node.
//
//The right-most node is also defined by the same way with left and right exchanged.
//
//Return an array of integers denoting the boundary values of tree in anti-clockwise order.
//
// For Example
//
//        Input 1:
//        _____1_____
//        /           \
//        2             3
//        / \            /
//        4   5          6
//        / \        / \
//        7   8      9  10
//        Output 1:
//        [1, 2, 4, 7, 8, 9, 10, 6, 3]
//        Explanation 1:
//        The left boundary are node 1,2,4. (4 is the left-most node according to definition)
//        The leaves are node 4,7,8,9,10.
//        The right boundary are node 1,3,6,10. (10 is the right-most node).
//        So order them in anti-clockwise without duplicate nodes we have [1,2,4,7,8,9,10,6,3].
//
//        Input 2:
//        1
//        / \
//        2   3
//        / \  / \
//        4   5 6  7
//        Output 2:
//        [1, 2, 4, 5, 6, 7, 3]
public class BoundaryTraversalOfBTree {
    // There are 3 steps to do it
    // 1.) Add all the left side elements in the ArrayList (preorder traversal, because we need to add node top to down)
    //     Note: if for a node, left is not there, then add right(because it will be exposed from left view)
    // 2.) Print all the leaf nodes (Do not add the left side leaf node, because it is been added from left side traversal)
    //     Note: to check if left leaf node as added or not, check if the last node which is added in the list is first leaf node
    //     which we are processing, then only add
    // 3.) Add the right side elements in the arraylist( Postorder traversal, because we need add nodes bottom to top
    //     Note: if for a node, right is not there, then add left(because it it will be exposed from right view)
    //     Also check if last added node in the list is same as node which we are processing first, it can be a leaf node)
    // Simpilfying solution:
    // 1.) Add left boundary(prorder)
    // 2.) Add leafNodes (Any Order, because for leaf node, left and right are null)
    // 3.) Add right boundary(postorder)

    public void leftBoundary(TreeNode root, ArrayList<Integer> boundaryList){
        if(root==null) return;
        boundaryList.add(root.val);
        if(root.left!=null){
            leftBoundary(root.left,boundaryList);
        }
        else{
            leftBoundary(root.right,boundaryList);
        }
    }
    public void leafNodes(TreeNode root, ArrayList<Integer> boundaryList){
        if(root==null) return;
        if(root.left==null && root.right==null){
            // below condition is for, take an example of inout 1, and consider the element 7
            // this is the last left element as well as a leaf element, So we already added this element
            // while adding left boundry, So we will not add it again
            if(boundaryList.get(boundaryList.size()-1)!=root.val){
                boundaryList.add(root.val);
            }
        }
        leafNodes(root.left,boundaryList);
        leafNodes(root.right,boundaryList);
    }
    public void rightBoundary(TreeNode root, ArrayList<Integer> boundaryList) {
        if(root==null) return;
        if(root.right!=null){
            rightBoundary(root.right,boundaryList);
        }
        else{
            rightBoundary(root.left,boundaryList);
        }
        // we are doing the post order, So bottom to up and we are calling this method after
        // leafnode traversal, So, example of input 1, 10 is the right most boundary, as well as leaf node
        // So we already added leaf node in the list. So we will not add it here
        if(boundaryList.get(boundaryList.size()-1)!=root.val){
            boundaryList.add(root.val);
        }
    }

    public ArrayList<Integer> solve(TreeNode A) {
        ArrayList<Integer> boundaryList= new ArrayList<>();
        boundaryList.add(A.val);
        leftBoundary(A.left,boundaryList);
        leafNodes(A,boundaryList);
        rightBoundary(A.right,boundaryList);
        return boundaryList;
    }
}
