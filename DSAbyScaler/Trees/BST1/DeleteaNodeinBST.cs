using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.BST1
{
    //Given a root node reference of a BST and a key, delete the node with the given key in the BST.Return the root node reference (possibly updated) of the BST.

    //Basically, the deletion can be divided into two stages:

    //Search for a node to remove.
    //If the node is found, delete the node.


    //Example 1:


    //Input: root = [5, 3, 6, 2, 4, null, 7], key = 3
    //Output: [5,4,6,2,null,null,7]
    //Explanation: Given key to delete is 3. So we find the node with value 3 and delete it.
    //One valid answer is [5,4,6,2,null,null,7], shown in the above BST.
    //Please notice that another valid answer is [5,2,6,null,4,null,7] and it's also accepted.

    //Example 2:

    //Input: root = [5, 3, 6, 2, 4, null, 7], key = 0
    //Output: [5,3,6,2,4,null,7]
    //Explanation: The tree does not contain a node with value = 0.
    //Example 3:

    //Input: root = [], key = 0
    //Output: []
    // Exampe for BST:
    //            15
    //          /    \
    //        12      20
    //        / \    /  \
    //       10  14  16  27
    //      /
    //     8
    internal class DeleteaNodeinBST
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // If we have to delete a node from a BST, there are 3 Situation
        // 1.) if the node which needs to be deleted is a leaf node, means do not have any children(0 Children)
        // 2.) if the node which needs to be delete has only 1 child(either left or right)
        // 3.) if the node which needs to be deleted has both chuldren(both left and right)

        // lets understand it with the help of an example: 
        //            15
        //          /    \
        //        12      20
        //        / \    /  \
        //       10  13  16  27
        //      /  \   \
        //     8    11  14
        // Case 1: if we have to delete 16 or 27 or 14 or 8, is the example of case 1, because all the nodes are leaf node
        // case 2: if we have to delete node which has single child, example: delete 10, 10 has only 1 child, which is 8 on left
        // case 3: if we have to delete node which has both children, example: delete 12, 12 has both children (10,13)

        // How to solve:
        // Case 1: it is simple,
        // Search for a node first, maintain a parent pointer, and after that, just do parent.left/right=null
        // example: 27, search 27, so node=27 and parent=20. so 20.right=null

        // Case 2: it is simple,
        // Search for a node first, maintain a parent pointer adn after that, just do, parent.left/right=node.left/right
        // example: 10, after searcing 10 will be node, and 12 will parent
        // So 12.left=10.left

        //Case 3: Search for a node, maintain a parent pointer, now we have a node, example: 12, can we delete the node as it is?
        // if we do, then what will happen to 10 and 13, where do we have to connect them.
        // So, what we will do, extract a node which satisfy case 1 or case 2 and then replace that extracted node to the deleted node
        // How do we extract the node which satisfy the case 1 and case 2 condition
        // example, we need to delete node 12, So in order to maintain the tree the BST, we need a node whose value is greater than or equal to left subtree
        // which is 10-> 8.4(subtree), and smaller than equal to right subtree, which is 13->14(subtree).
        // So we can see if we put 11 at 12 place it will still be BST, 
        //            15
        //          /    \
        //        11      20
        //        / \    /  \
        //       10  13  16  27
        //      /     \
        //     8      14
        // Also if we put 13 in place of 12, then also it is BST.
        // check,
        //            15
        //          /    \
        //        13      20
        //        / \    /  \
        //       10  14  16  27
        //      /  \   
        //     8    11
        // 
        // How can we make this observation, we can say we can extract max(left subtree) or min(right subtree)
        // because max of left subtree will satisfy the condition of valid BST (node which if we place all the left subtree nodes are lesser than that extracted node)
        // and all the rall the node on the right should be greater than this)
        // So if we take max of left subtree, will have a higher value in leftsubtree and all the nodes will be smaller than that node
        // within left subtree, So we can make make the leader(extracted node).
        // the maximum node on the left subtree will always be having either 0 or 1 child, how can we sure about that?
        // take an above example original BST, 11 is max node on left subtree and it has 0 child.
        // it might be coincidence right? NO. because if it has any right node, than it will be greater than 11, and in that case it will max on left
        // and yes 11 can still have left child, but it will not refrain itself to claim max on left subtree, because all the nodes
        // on left of 11 will be smaller than 11, so in that case also it will be max of left subtree
        // Also this will be case 2, which lands to node having single child.

        // next is min on right subtree, minimum value on right will also satisfy the condition of maintaining BST
        // because it will be greater than left subtree and smaller than all right subtree
        // consider 13, how it can be considered to replacement node? as 13 is smaller in right subtree
        // what if 13 has both children? then again we might end in same problem?
        // NO, if 13 has left node as well, than that left node will be smaller node in whole subtree
        // then 13 will no longer be smaller on right
        // and that is how we can say it will be landing into either case 1 or case 2

        // we will go ahead with max on left subtree.

        public KeyValuePair<TreeNode,TreeNode> Search(TreeNode root, int K)
        {
            TreeNode node = root;
            TreeNode parent = null;
            while(node != null)
            {
                if (node.val == K) return new KeyValuePair<TreeNode, TreeNode>(parent, node);
                parent = node;
                if (node.val > K)
                {
                    node=node.left;
                }
                else if (node.val < K)
                {
                    node = node.right;
                }
            }
            return  new KeyValuePair<TreeNode, TreeNode>(null, null); 
        }
        public int numberOfChildren(TreeNode node)
        {
            if(node.left==null && node.right == null)
            {
                return 0;
            }
            else if(node.left==null || node.right == null)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            //search the node, it will return the parent, node
            KeyValuePair<TreeNode, TreeNode> searchPair = Search(root, key);
            if(searchPair.Key!=null && searchPair.Value != null)
            {
                TreeNode parent=searchPair.Key;
                TreeNode node=searchPair.Value;
                // check number of nodes
                int numberOfChildrens = numberOfChildren(node);
                
                // case 1 && 2
                if (numberOfChildrens < 2)
                {
                    //case 2
                    // check if node has 1 child then which child it is, left or right
                    
                    TreeNode temp = null;
                    if (node.left!=null)
                    {
                        temp=node.left;
                    }
                    else if (node.right != null)
                    {
                        temp = node.right;
                    }
                    // if node has 0 child then temp will remain null and we will connect parent to null in coming code

                    //case 1
                    // if node has 0 child, then check if it is left or right of parent
                    // based on that connect it to null.
                    // below code can also help case 2, because if node has only 1 child, then connect the parent
                    // that children, based on left and right adn that node can be determine by temp
                    if (node == parent.left)
                    {
                        parent.left=temp;
                    }
                    else if(node== parent.right)
                    {
                        parent.right = temp;
                    }
                }
                else
                {
                    // if node has 2 childrens then extract the max of left subtree node and replace the extracted node
                    // with the node which needs to be deleted

                    // how to extract the node or we can say max of left subtree node
                    // go to left subtree and go till right right and right untill it is null
                    //            15
                    //          /    \
                    //        12      20
                    //        / \    /  \
                    //       10  13  16  27
                    //      /  \   \
                    //     8    11  14
                    // here if we have to delete 12, then go to left which means 10, and go till right right untill it is null
                    // so we get 11 which is max node on left subtree
                    // maintain the parent for that as well
                    TreeNode p = null;
                    TreeNode curr = node.left;
                    while (curr.right != null)
                    {
                        curr = curr.right;
                    }
                    // here we can have to conditions-
                    // 1.) left subtree can have no right. example: suppose there is no element on right of 10
                    // then we need to extract 10 and connect 12 to 8
                    // if there is no right subtree then p will be null
                    if (p == null)
                    {
                        node.left = curr.left;
                        //12.left=10.left => 12->8
                    }
                    else
                    {
                        p.right=curr.left;
                        // if there is right subtree then 10 will be parent and 11 is the curr
                        // so 10.right=11.left
                        // why 11.left we can say null naa
                        // no, it might be possible that 11.left is not null, then also 11 is maximum on left subtree
                        // so we will connect 10 to 11's left subtree

                    }
                    // after extracting the node which is curr.
                    // lets replace node with curr
                    curr.left = node.left;
                    curr.right = node.right;
                    // and connect the parent of node to curr
                    if (node == parent.left)
                    {
                        parent.left = curr;
                    }
                    else
                    {
                        parent.right = curr;
                    }
                }
            }
            return root;
        }


    }
}
