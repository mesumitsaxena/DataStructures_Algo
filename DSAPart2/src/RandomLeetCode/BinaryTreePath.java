package RandomLeetCode;

import java.util.ArrayList;
import java.util.List;

//https://leetcode.com/problems/binary-tree-paths/
//Given the root of a binary tree, return all root-to-leaf paths in any order.
//
//        A leaf is a node with no children.
//
//
//
//        Example 1:
//
//
//        Input: root = [1,2,3,null,5]
//        Output: ["1->2->5","1->3"]
public class BinaryTreePath {
    public void findTreePath(TreeNode root, List<String> output, StringBuilder sb){
        if(root==null) return;
        if(root.left==null && root.right==null){
            sb.append(String.valueOf(root.val));
            output.add(sb.toString());
            return;
        }
        String val=sb.toString()+String.valueOf(root.val)+"->";
        findTreePath(root.left,output,new StringBuilder(val));
        findTreePath(root.right,output,new StringBuilder(val));
    }
    public List<String> binaryTreePaths(TreeNode root) {
        List<String> output= new ArrayList<>();
        StringBuilder sb= new StringBuilder();
        findTreePath(root,output,sb);
        return output;
    }
}
