package Trees.LCA_TreesProb;

import com.sun.source.tree.Tree;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<Integer> list1= new ArrayList<>(Arrays.asList(
                16,12,18,33,49,105,181));
        List<Integer> list2= new ArrayList<>(Arrays.asList(
                24,29,18,33,49,105,181));
        DistanceBetweenNodes obj= new DistanceBetweenNodes();

        TreeNode root= new TreeNode(51);
        TreeNode s17 = new TreeNode(17);
        TreeNode s6= new TreeNode(6);
        TreeNode f45= new TreeNode(45);
        TreeNode f58= new TreeNode(58);
        TreeNode f4= new TreeNode(4);
        TreeNode e8= new TreeNode(8);
        TreeNode s7= new TreeNode(7);
        TreeNode f5= new TreeNode(5);
        TreeNode t30= new TreeNode(30);

        root.left=s17;
        root.right=s6;
        s17.left=f45;
        s17.right=f58;
        f45.left=f4;
        f45.right=e8;
        s6.left=f5;
        s6.right=t30;
        BoundaryTraversalOfBTree obj1= new BoundaryTraversalOfBTree();
        obj1.solve(root);

    }
}
