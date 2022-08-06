package Trees.ProblemonTrees2;

import com.sun.source.tree.Tree;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;

//Given the root node of a Binary Tree denoted by A. You have to Serialize the given Binary Tree in the described format.
//
//        Serialize means encode it into a integer array denoting the Level Order Traversal of the given Binary Tree.
//
//        NOTE:
//
//        In the array, the NULL/None child is denoted by -1.
//        For more clarification check the Example Input.
//Example Input
//        Input 1:
//
//        1
//        /   \
//        2     3
//        / \
//        4   5
//        Input 2:
//
//        1
//        /   \
//        2     3
//        / \     \
//        4   5     6
//
//
//        Example Output
//        Output 1:
//
//        [1, 2, 3, 4, 5, -1, -1, -1, -1, -1, -1]
//        Output 2:
//
//        [1, 2, 3, 4, 5, -1, 6, -1, -1, -1, -1, -1, -1]
//
//
//        Example Explanation
//        Explanation 1:
//
//        The Level Order Traversal of the given tree will be [1, 2, 3, 4, 5 , -1, -1, -1, -1, -1, -1].
//        Since 3, 4 and 5 each has both NULL child we had represented that using -1.
//        Explanation 2:
//
//        The Level Order Traversal of the given tree will be [1, 2, 3, 4, 5, -1, 6, -1, -1, -1, -1, -1, -1].
//        Since 3 has left child as NULL while 4 and 5 each has both NULL child.
public class SerializeBinaryTree {
    // It is same as Level Order Traversal, Just add -1 when node.left or node.right is null
    public ArrayList<Integer> solve(TreeNode A) {
        ArrayList<Integer> output= new ArrayList<>();
        Queue<TreeNode> Q= new LinkedList<>();
        Q.add(A);
        while(Q.size()>0){
            TreeNode node=Q.peek();
            Q.remove();
            if(node==null){
                output.add(-1);
            }
            else{
                output.add(node.val);
            }
            if(node!=null) Q.add(node.left);
            if(node!=null) Q.add(node.right);

        }
        return output;
    }
}
