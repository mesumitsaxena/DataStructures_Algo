package Trees.BST2;

import java.util.HashMap;

//Given a binary search tree represented by root A,
// write a function to find the Bth smallest element in the tree.
/*
Example Input
Input 1:


            2
          /   \
         1    3
B = 2
Input 2:


            3
           /
          2
         /
        1
B = 1



Example Output
Output 1:

 2
Output 2:

 1
* */

public class KthSmallestElementinBST {
    //first way is we can create a list of integers using inorder traversal
    // by inorder traversal, list will be in sorted order and we can find the B-1 element from the list
    // this requires extra space
    // can we search it using traversal only?
    // lets understand -
    // Suppose we are on root node, we can ask root node that how many elements do you have on left?
    // why asking left? because all the left elements are smaller than root. Now we will check
    // if number of elements on left is smaller than B, means if B=7(we want 7th smallest element)
    // and number of elements on left is 5, means 7th element will be there on right.
    // how to conclude that? lets create an array using inorder of above example:
    //            2
    //          /   \
    //         1    3
    // 1 2 3, B =3 if we want 3rd smallest element, number of elements on left matters, if they are smaller, means
    // we didn't reached to B yet
    // So we will look on the right, but if number of elements on left is less than B, it means Bth element will be here on left
    // So move to left.
    // by this we will also check if number of elements on left + 1=B, then this is the Bth node
    // but each time checking number of nodes on left will increase the time complexity right?
    // We will take hashmap, with node and their rank, means number of elements on left+1
    // whenever we visit the node, we will get the rank from node and decide if it is the Bth node?
    // or we have to move to left or move to right.
    // Let's understand with an example:
    //            15
    //          /    \
    //        12      14
    //        / \    /  \
    //       10  20  16  27
    //      /
    //     8
    // suppose B=4, we will ask root 15, its rank, the rank is total number of node  on left +1 =5
    // so go to left, ask 12, rank is 3, so we have to go to right.
    // but when we move to right, we know the elements which we already covered (means number of elements on left)
    // So B=B-rank of root
    // in above example: when we move to 12, we know rank is 3 so move to right
    // but before moving to right, we knew there are 8, 10 and 12 which are already covered, So 4-3=1
    // now we need to check an element which has rank 1. and 20 has rank 1 and it is our 4th smallest node
    // why it is helping
    // when we create hashmap, we insert node and its rank, means 12 has rank 3, 20 has rank 1
    // So whenever we move to right, it doesn't have its order, instead a rank(number of left element+1)
    // take an example of above tree with the list: 8 10 12 20 15 16 13 27
    // when we are move from 12 to 20, we will have to know that we already covered 3 elements, so you have to find
    // the 1st smallest element now
    HashMap<TreeNode,Integer> map= new HashMap<>();
    public int findLeftSize(TreeNode root){
        if(root==null) return 0;
        int leftCount=findLeftSize(root.left);
        map.put(root,leftCount+1);
        int rightCount=findLeftSize(root.right);
        return leftCount+rightCount+1;
    }
    public int kthsmallest(TreeNode A, int B) {
        findLeftSize(A);
        while(A!=null){
            if(map.get(A)==B){
                return A.val;
            }
            else if(map.get(A)<B){
                B=B-map.get(A);
                A=A.right;
            }
            else {
                A=A.left;
            }
        }
        return -1;
    }
}