package Trees.ProblemonTrees2;

//Given a binary tree,
//
//        Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.
//
//        Initially, all next pointers are set to NULL.
//
//        Assume perfect binary tree and try to solve this in constant extra space.
//Example Input
//        Input 1:
//
//
//        1
//        /  \
//        2    3
//        Input 2:
//
//
//        1
//        /  \
//        2    5
//        / \  / \
//        3  4  6  7
//
//
//        Example Output
//        Output 1:
//
//
//        1 -> NULL
//        /  \
//        2 -> 3 -> NULL
//        Output 2:
//
//
//        1 -> NULL
//        /  \
//        2 -> 5 -> NULL
//        / \  / \
//        3->4->6->7 -> NULL
//
//
//        Example Explanation
//        Explanation 1:
//
//        Next pointers are set as given in the output.
//        Explanation 2:
//
//        Next pointers are set as given in the output.
public class NextPointerBinaryTree {
     public class TreeLinkNode {
         int val;
         TreeLinkNode left, right, next;

         TreeLinkNode(int x) {
             val = x;
         }
     }
     // As we know we it is a perfect binary Tree, So each node will have left and right child expect leaf nodes
    // So we know root node has no next, so it will remain null
    // but, its left should be connected with its right
    // temp.left.next=temp.right
    // but not just this, right child of the node should be connected to left node of node's next
    // So if node's next is not null, then node.right.next=node.next.left
    public void connect(TreeLinkNode root) {
         TreeLinkNode curr=root;
         while(curr!=null){
             TreeLinkNode temp=curr;
             while(temp.next!=null){
                 temp.left.next=temp.right;
                 if(temp.next!=null){
                     temp.right.next=temp.next.left;
                 }
                 temp=temp.next;
             }
             curr=curr.left;
         }

    }
}
