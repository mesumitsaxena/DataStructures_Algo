package Trees.LCA_TreesProb;

import java.util.ArrayList;
import java.util.List;

//Given a binary search tree.
//        Return the distance between two nodes with given two keys B and C. It may be assumed that both keys exist in BST.
//
//        NOTE: Distance between two nodes is number of edges between them.
//Example Input
//        Input 1:
//
//
//        5
//        /   \
//        2     8
//        / \   / \
//        1   4 6   11
//        B = 2
//        C = 11
//        Input 2:
//
//
//        6
//        /   \
//        2     9
//        / \   / \
//        1   4 7   10
//        B = 2
//        C = 6
//
//
//        Example Output
//        Output 1:
//
//        3
//        Output 2:
//
//        1
//
//
//        Example Explanation
//        Explanation 1:
//
//        Path between 2 and 11 is: 2 -> 5 -> 8 -> 11. Distance will be 3.
//        Explanation 2:
//
//        Path between 2 and 6 is: 2 -> 6. Distance will be 1
public class DistanceBetweenNodes {
    // Solution is almost same as LCA, LCA is the point where the path intersect for both nodes
    // but here we need to return the distance between 2 nodes
    // Same approach as LCA-
    // 1. Find the first node path and store it in List
    // 2. Find the second node path and store it in list
    // 3. Traverse the first list from back and when nodes matches in second list
    // print 2nd list from that point from left to right
    // example: we have 1 2 3 4 5 6 and second list is 1 2 3 7 8 9 10.
    // So traverse from 6 in first list, so 6 5 4 3, now 3 matches in second list, So print from 2nd list itself
    // 7 8 9 10, and then calculate the count of elements and return.
    // but here we only need to find the count, So
    // traverse both list from front and see when the elements are not same
    // So 1 2 3 is same in both list but, 4 and 7 are not same, so list1.size-i + list2,size-i = 6-3 + 7-3 = 3+4+1(because we need to consider LCA as well)
    public boolean findNode(TreeNode root, List<Integer> list, int k){
        if(root==null) return false;
        if(root.val==k){
            list.add(root.val);
            return true;
        }
        if(findNode(root.left,list,k)||findNode(root.right,list,k)){
            list.add(root.val);
            return true;
        }
        return false;
    }
    public int solve(TreeNode A, int B, int C) {
        List<Integer> list1= new ArrayList<>();
        List<Integer> list2= new ArrayList<>();
        findNode(A,list1,B);
        findNode(A,list2,C);

        int list1Size=list1.size()-1;
        int list2Size=list2.size()-1;

        while(list1Size>=0 && list2Size>=0){
            int list1Item=list1.get(list1Size);
            int list2Item=list2.get(list2Size);
            if(list1Item!=list2Item){
                return (list1Size+1)+(list2Size+1);
            }
            else{
                list1Size--;
                list2Size--;
            }
        }
        if(list1Size>=0) return list1Size+1;
        return list2Size+1;
    }
}
