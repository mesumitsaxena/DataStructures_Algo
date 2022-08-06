package Trees.ProblemonTrees2;


//Given a binary tree and a sum, determine if the tree has a root-to-leaf path
//        such that adding up all the values along the path equals the given sum.
//Input 1:
//
//        Tree:    5
//        / \
//        4   8
//        /   / \
//        11  13  4
//        /  \      \
//        7    2      1
//
//        B = 22
//        Input 2:
//
//        Tree:    5
//        / \
//        4   8
//        /   / \
//        -11 -13  4
//
//        B = -1
//
//
//        Example Output
//        Output 1:
//
//        true
//        Output 2:
//
//        false
//
//
//        Example Explanation
//        Explanation 1:
//
//        There exist a root-to-leaf path 5 -> 4 -> 11 -> 2 which has sum 22. So, return true.
//        Explanation 2:
//
//        There is no path which has sum -1.
public class PathSum {
    public boolean isLeafNode(TreeNode root){
        if(root==null) return false;
        if(root.left==null && root.right==null){
            return true;
        }
        return false;
    }
    public boolean hasPathSum(TreeNode root, int targetSum) {
        if(root==null) return false;
        // if node is leaf node and value is equal to targetSum then return true
        if(isLeafNode(root)==true && root.val==targetSum){
            return true;
        }
        boolean left=hasPathSum(root.left,targetSum-root.val);
        boolean right=hasPathSum(root.right,targetSum-root.val);
        return left||right;
    }
}
