package Trees.LCA_TreesProb;

//Given a Binary Tree A consisting of N integer nodes, you need to find the diameter of the tree.
//
//        The diameter of a tree is the number of edges on the longest path between two nodes in the tree.
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
//        3
//        Output 2:
//
//        4
//
//
//        Example Explanation
//        Explanation 1:
//
//        Longest Path in the tree is 4 -> 2 -> 1 -> 3 and the number of edges in this path is 3 so diameter is 3.
//        Explanation 2:
//
//        Longest Path in the tree is 4 -> 2 -> 1 -> 3 -> 6 and the number of edges in this path is 4 so diameter is 4.


public class DiameterofTree {
    // Diameter of the tree is kind of a extension of a longest length of a tree width wise which is going through root
    // we just calculated for root, height of left and height of right +2, because in order to maintain a width we need 2 edges
    // 1 is connected to left and another to right
    // but diameter is different, longest width in a tree, which may not be passed through root.
    // So what we will do we will calculate diameter while calculating height only
    // how it will work? while we calculate the height, we will check the diameter as well
    // as leftheight+rightheight+2, if it is greater than previous diameter than update diameter
    // else go ahead with calculating height only
    int diameter=0;
    public int solve(TreeNode A) {
        height(A);
        return diameter;
    }
    public int height(TreeNode A){
        if(A==null) return -1;
        int left=height(A.left);
        int right=height(A.right);
        diameter=Math.max(left+right+2,diameter);
        return Math.max(left,right)+1;
    }
}
