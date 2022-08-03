package Trees.BST2;

import java.util.ArrayList;
import java.util.List;

// In Order Traversal - By Iteration.
// Benefit? O(1)- because by recursion we use recursive stacks.

// In Order Traversal, we used to store the root in stack so that once all the left is visited we can come back
// again at root and process it and go to its right
// if we have to use O(1) space, how can we store the root?
// in deleting a node in BST, we found that we can find the max of left subtree
// Similiar approach - when root will be visited, once all the leftsubtree is visited
// So we can say in left subtree the right most node which is null will be inorder predeccer
// means after that node only root will be visited so connect inorder predeccesser right to current root.
// example:
//            15
//          /    \
//        12      14
//        / \    /  \
//       10  20  16  27
//      /
//     8
// Once reached to 15, we see 15 has left so we need to store 15 for later because we need to process left first
// So we will find in order predeccesser (go to 15 left and right right right), and coonect its right to 15
// why? because 15 will be processed after 20 only, so 20 right is null we will connect 20 right as 15.
// same for 12 as well, connect 10 right to 12 and 8 right to 10.
// Now once reached to 8, it will check its left, there is no left so print 8
// and move to its right, but its right is 10(we connected before), So 10 will again check its left and it has left.
// which is 8 and it is already processed, so we are kind of visiting it twice.
// Anyway, we will check 8's right which is connected 10(which is current node), so we will know that
// its a repeating loop, So this time, we will break the loop, means (8.right=null)
// process 10 and move to its right
// right is 12(we connected before), So we will check 12' left and it is not null, So we will find its in order predecceseer
// but while iteration we found it is a loop which we created, So we break the loop and print the curr and move to right
public class MorrisInOrderTraversal {
    public List<Integer> inorderTraversal(TreeNode root) {
        List<Integer> output= new ArrayList<>();
        TreeNode curr=root;
        while(curr!=null){
            // if left is null, then print the curr and move to its right
            if(curr.left==null){
                output.add(curr.val);
                curr=curr.right;
            }
            // if left is not null, then we need to store current first before moving to left
            // we cant use extra space, So we will find it's in order predesser by moving right right right of
            // current's left untill we get null or the current(in case we already connect the right)
            else{
                // take the temp as current left
                TreeNode temp=curr.left;
                // move to right right untill it is null(1st time when we are finding in order predessor)
                // and if its right is current only (2nd time when all the left is process and move to roots
                // inorder predessor and its right to connect to root itself
                // then break it
                while(temp.right!=null && temp.right!=curr){
                    temp=temp.right;
                }
                // check if temp right is null then it is inorder predessor
                // so connect it to root and move to left
                // 1st time treversal
                if(temp.right==null){
                    temp.right=curr;
                    curr=curr.left;
                }
                // if it is not null, means we are on in order predessor
                // it means we have processed all the left subtree
                // so break the link, process the root and move to right
                else{
                    temp.right=null;
                    output.add(curr.val);
                    curr=curr.right;
                }
            }

        }
        return output;
    }
}
