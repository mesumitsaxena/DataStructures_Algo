package Trees.ProblemonTrees2;


import java.util.LinkedList;
import java.util.Queue;

//Given a binary tree of integers. Find the difference between the sum of nodes at odd level and sum of nodes at even level.
//
//        NOTE: Consider the level of root node as 1.
//Example Input
//        Input 1:
//
//        1
//        /   \
//        2     3
//        / \   / \
//        4   5 6   7
//        /
//        8
//        Input 2:
//
//        1
//        / \
//        2   10
//        \
//        4
//
//
//        Example Output
//        Output 1:
//
//        10
//        Output 2:
//
//        -7
//
//
//        Example Explanation
//        Explanation 1:
//
//        Sum of nodes at odd level = 23
//        Sum of ndoes at even level = 13
//        Explanation 2:
//
//        Sum of nodes at odd level = 5
//        Sum of ndoes at even level = 12
public class OddandEvenLevels {
    // we will do the same thing as Level Order Traversal,
    // instead of TreeNode we will take pair of Treenode and level
    // and at each level we will check if it is even or odd and will take 2 variables called oddSum and evenSum
    // and add into the desired sum
    class Data{
        public TreeNode node;
        public int level;
        public Data(TreeNode node, int level){
            this.node=node;
            this.level=level;
        }
    }
    public int solve(TreeNode A) {
        Queue<Data> Q= new LinkedList<>();
        Data dNode= new Data(A,1);
        Q.add(dNode);
        int oddSum=0;
        int evenSum=0;
        while(Q.size()>0){
            Data dnode= Q.peek();
            TreeNode node=dnode.node;
            int level=dnode.level;
            if(level%2>0){
                oddSum+=node.val;
            }
            else{
                evenSum+=node.val;
            }
            Q.remove();
            if(node.left!=null) Q.add(new Data(node.left,level+1));
            if(node.right!=null) Q.add(new Data(node.right,level+1));

        }
        return oddSum-evenSum;
    }
}
