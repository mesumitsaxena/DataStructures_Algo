package Trees.LCA_TreesProb;

//Given a binary tree T, find the maximum path sum.
//
//        The path may start and end at any node in the tree.
//Example Input
//        Input 1:
//
//
//        1
//        / \
//        2   3
//        Input 2:
//
//        20
//        /  \
//        -10   20
//        /  \
//        -10  -50
//
//
//        Example Output
//        Output 1:
//
//        6
//        Output 2:
//
//        40
//
//
//        Example Explanation
//        Explanation 1:
//
//        The path with maximum sum is: 2 -> 1 -> 3
//        Explanation 2:
//
//        The path with maximum sum is: 20 -> 20
public class MaxPathSum {
    // we can create a method of finding maximum path sum, where we will check the path or height with max sum from root
    // and we can calculate a path with maximum sum across tree as a by product
    // in order to calculat max path sum, we will calculate a path which is max.
    // and we will get max sum of left and right
    // and then we can calculate max path sum considering left and right
    // if left and right are -ve, then we should replace them with 0
    // Max Path is just a path from root to node which gives max sum, So we will just add current nodes value
    // to max(left,right).
    // but in this question, we need sum of any path which is maximum
    // So by max path sum we will get maximum value which can be get from left and maximum value which can be get from right
    // and add the current node
    // Lets take this example and understabd
    //          1
    //        /   \
    //        2    3
    //        / \  / \
    //        4   5 6  7
    //        /
    //        8
    // first we will iterate and iterate and come to 8, it has left as null and right as null
    // So left will send 0, right will send 0, So max will be 8+0+0=8
    // and 8 will send 8+max(0,0)=8
    // now 4 will check right which is null so right is sending 0, so max will be 4+left(8)+0=12
    // and 4 will send, 4+max(8,0)=12 only
    // So till now we can see, max path is 8 and 4 only and max path sum is also derived from it only
    // lets move forward
    // 2 comes, from left 12 will come and from right 5 will come
    // So total sum till now or we can say max path sum till now is 19(12+5+2)
    // and it will return 2+max(left(12),right(5))=2+12=14
    // So till now max path in a tree will be
    //        2
    //        / \
    //        4   5
    //        /
    //        8
    // but max path from root is only-
    //        2
    //        /
    //        4
    //        /
    //        8
    // now when we come to 1, we can see, maxpathsum in a tree will be curr+left+right=> 1+12+10
    // but max path from root will be 1+14=15
    // So calculating max sum of path in a tree is derived from max path from root.
    // example: when calculating maxpathsum at 1, we tool 1+left+right = now left is coming from max sum from root only from left
    // which is 14 and same with right
    int max=Integer.MIN_VALUE;
    public int MaxSum(TreeNode A){
        float f1=2.5f;
        if(A==null) return 0;
        // get max value from a nodes of left subtree
        int left=MaxSum(A.left);
        // get max value from nodes of right subtree
        int right=MaxSum(A.right);
        // if left is -ve then mark them 0
        left=Math.max(0,left);
        // if right is -ve then mark them 0
        right=Math.max(0,right);
        // calculate max by adding current+left+right(as left and right already have max path from left and right)
        // So by this we will get maximum sum path
        max=Math.max(max,A.val+left+right);
        // return current node value + maximum value from left or right
        return A.val+Math.max(left,right);


    }
    public int maxPathSum(TreeNode A) {
        MaxSum(A);
        return max;

    }
}
