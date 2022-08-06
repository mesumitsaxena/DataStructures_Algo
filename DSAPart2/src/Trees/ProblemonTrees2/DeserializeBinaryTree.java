package Trees.ProblemonTrees2;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;

//You are given an integer array A denoting the Level Order Traversal of the Binary Tree.
//
//        You have to Deserialize the given Traversal in the Binary Tree and return the root of the Binary Tree.
//
//        NOTE:
//
//        In the array, the NULL/None child is denoted by -1.
//        For more clarification check the Example Input.
//Example Input
//        Input 1:
//
//        A = [1, 2, 3, 4, 5, -1, -1, -1, -1, -1, -1]
//        Input 2:
//
//        A = [1, 2, 3, 4, 5, -1, 6, -1, -1, -1, -1, -1, -1]
//
//
//        Example Output
//        Output 1:
//
//        1
//        /   \
//        2     3
//        / \
//        4   5
//        Output 2:
//
//        1
//        /   \
//        2     3
//        / \ .   \
//        4   5 .   6
//
//
//        Example Explanation
//        Explanation 1:
//
//        Each element of the array denotes the value of the node. If the val is -1 then it is the NULL/None child.
//        Since 3, 4 and 5 each has both NULL child we had represented that using -1.
//        Explanation 2:
//
//        Each element of the array denotes the value of the node. If the val is -1 then it is the NULL/None child.
//        Since 3 has left child as NULL while 4 and 5 each has both NULL child.
public class DeserializeBinaryTree {
    // we can still apply Level Order Traversal on the arraylist, and access the ith and (i+1)th node in order to know left and right
    // first of all we will add root node value(1st value from list) into queue
    // Now check the next 2 values from list, if it is not -1, then make them left and right
    // pop the element from Queue and atatch left adn right to it
    // then add left and right nodes in Queue
    // continue this process
    public TreeNode solve(ArrayList<Integer> A) {
        TreeNode root= new TreeNode(A.get(0));
        Queue<TreeNode> Q= new LinkedList<>();
        Q.add(root);
        int i=1;
        // why are we not checking i value?
        // because we know even if there is only 1 node which is root node, it will have -1 -1 left and right
        // So we are still able to access i and i+1 item
        // when Q is empty means there were -1 -1 nodes which we check before and now all nodes are processed
        while(Q.size()>0){
            TreeNode node=Q.peek();
            TreeNode left=null;
            TreeNode right=null;
            if(A.get(i)!=-1){
                left= new TreeNode(A.get(i));
            }
            if(A.get(i+1)!=-1){
                right= new TreeNode(A.get(i+1));
            }
            node.left=left;
            node.right=right;
            Q.remove();
            if(left!=null) Q.add(left);
            if(right!=null) Q.add(right);
            i+=2;
        }
        return root;
    }
}
