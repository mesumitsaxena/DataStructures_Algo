using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees1
{
    //You are given the root node of a binary tree A.You have to find the height of the given tree.

    //A binary tree's height is the number of nodes along the longest path from the root node down
    //to the farthest leaf node.

    //Example Input
    //Input 1:

    // Values =  1 
    //          / \     
    //         4   3                        
    //Input 2:


    // Values =  1      
    //          / \     
    //         4   3                       
    //        /         
    //       2                                     


    //Example Output
    //Output 1:

    // 2 
    //Output 2:

    // 3 


    //Example Explanation
    //Explanation 1:

    // Distance of node having value 1 from root node = 1
    // Distance of node having value 4 from root node = 2 (max)
    // Distance of node having value 3 from root node = 2 (max)
    //Explanation 2:

    // Distance of node having value 1 from root node = 1
    // Distance of node having value 4 from root node = 2
    // Distance of node having value 3 from root node = 2
    // Distance of node having value 2 from root node = 3 (max)
    internal class TreeHeight
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // Height of the tree is max level either on left or right+1(its own height)
        // Values =  1      
        //          / \     
        //         4   3                       
        //        /         
        //       2 
        // here root node (1) has height as 2, which is number of max edges on left or right+ 1(edge between current node and its children which is giving max value) till leaf node.
        // How do calculate this? lets understand it with the leaf node.
        // 2 has height as 0,how? number of max edges on left and right + 1(edge between current node and its children which is giving max value) till leaf node, this is itself a leaf node
        // So height will be 0(and you can see there is no edges after 2.
        // Now calculate for 4, 4 has 1 max edge on left so it's height is 4, now root node, height is 2(1->4 edge and 4->2 edge).
        // lets see how our logic works, for 4, while returning from recusion, its children will give the value.
        // 4's children will give the value of max number of edges on left or right + 1(edge between current node and its children which is giving max value)
        // 2 is giving 0 So we will add 1 into it so hence it will become 1.

        // we will iterate from root and move till we find root node.
        // but when we find root node, its childrens will be null, then we will return some value, what value should we return?
        // Should we return 0? lets see after some time.
        // As we know height of a node is max of left or right +1, So for leaf node, what would be height?
        // 0 right? and if return 0 from its children, leaf node will add its own height which will become 1, but its not the case.
        // So in order to make leaf node height 0, we will return -1, So that max(-1(left node of leaf node),-1(right node of leaf node)+1.
        // by this -1+1=0, and 0 will be return to 4, now 4 will return max(0(left side node max length),-1(right side is null))+1 => 0+1=1
        // now 1 will be returned to 1, but its right is 3, 3 will return 0(as it is a leaf node).
        // So 1 will return max(1(left side max length{returned by 4}),0(right side max length{returend by 3})+1=> 1+1=2 and this is our answer.
        public int solve(TreeNode A)
        {
            if (A == null) return -1;
            return Math.Max(solve(A.left), solve(A.right)) + 1;
        }
    }
}
