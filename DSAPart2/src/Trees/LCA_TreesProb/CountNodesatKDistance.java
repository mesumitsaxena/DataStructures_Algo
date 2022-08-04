package Trees.LCA_TreesProb;

public class CountNodesatKDistance {
    // First Approach is level order traversal, return count of nodes at the level of K(Approach using Queue, Count all
    // nodes after Kth Null, revise level order for more understanding)
    // Another approach is, we can go in recursively and we can pass K-1 for next iteration (going left or right)
    // whenever K is 0, means we reached at Kth level, So count++
    // lets see this in action
    public int CountNodes(TreeNode root, int K){
        // if root reached to null, means K is still not 0, So level is greater than that tree, So return 0
        if(root==null) return 0;
        // if K becomes 0, means we reached to K distance, So return 1(count of current node)
        if(K==0) return 1;
        // traverse left, with K-1, because we came one step down, So we traverse 1 distance, so K will reduce by 1
        int left=CountNodes(root.left,K-1);
        // traverse right, with K-1, because we came one step down, So we traverse 1 distance, so K will reduce by 1
        int right=CountNodes(root.right,K-1);
        // return total number of count from left + right
        return left+right;
    }
}
