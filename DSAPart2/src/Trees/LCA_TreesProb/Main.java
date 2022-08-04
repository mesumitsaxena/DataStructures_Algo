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

        TreeNode root= new TreeNode(68);
        TreeNode eightone = new TreeNode(81);
        TreeNode eleven= new TreeNode(11);
        TreeNode fiftyfive= new TreeNode(55);
        TreeNode fourtynine= new TreeNode(49);
        root.left=eightone;
        root.right=eleven;
        eightone.left=fiftyfive;
        eightone.right=fourtynine;
        NodesatDistanceKFromANode obj1= new NodesatDistanceKFromANode();
        obj1.solve(root,11,2);

    }
}
