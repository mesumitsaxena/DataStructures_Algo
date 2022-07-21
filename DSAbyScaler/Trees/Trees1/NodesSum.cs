using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees1
{
    //You are given the root node of a binary tree A.You have to find the sum of node values of this tree.
    //Example Input

    //Input 1:

    // Values =  1 
    //          / \     
    //         4   3                        
    //Input 2:


    // Values =  1      
    //          / \     
    //         8   3                       
    //        /         
    //       2                                     


    //Example Output

    //Output 1:

    // 8 
    //Output 2:

    // 14 


    //Example Explanation

    //Explanation 1:

    //Clearly, 1 + 4 + 3 = 8.
    //Explanation 2:

    //Clearly, 1 + 8 + 3 + 2 = 14.
    internal class NodesSum
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // As we need to make the sum of all the nodes, we will again use recursion.
        // we will move until we find leaf node.
        // As we need to add leaf node eleemnt value as well, we will go to leaf nodes children as well, which are null
        // when we encountered null, return 0 means null will have no value(no contribution to sum).
        // So while calculating its left and right value, add the current node value as well while returning this sum
        // to previous function call.
        // So overall method would be Add current value + sum returned by left node + sum returned by right node
        // example:
        // Values =  1      
        //          / \     
        //         8   3                       
        //        /         
        //       2 
        // on 2 leaf node, lets apply above formula=> return 2+ Sum of left tree + sum of right tree
        // Sum of left tree is 0 as it is null and sum of right tree also is 0 as it is also null.
        // So 2 will return 2+0+0=2 to 8
        // on 8, 8+ Sum of left tree + sum of right tree => 8+ Sum returned by 2(2) + 0(no right child) => 8+2+0=10,
        // return 10 to 1.
        // on 1, 1+ sum of left tree(sum returned by 8{10})+Sum of right tree(sum returned by 3)
        // Sum of right tree is not yet calculated so calculate it first(thats how recusrion works).
        // on 3, 3+ sum of left treee+ sum of right tree => 3+0(3 is leaf node so left childrens are null)+0(3 is leaf node so right childrens are null)
        // So 3+0+0=3(3 will be returned to 1 by 3)
        // So finally 1 will return 1(its own value)+ sum of left tree(sum returned by 8{10})+Sum of right tree(sum returned by 3{3})
        // 1+10+3 = 14.
        public int solve(TreeNode A)
        {
            if (A == null) return 0;
            return A.val+solve(A.left)+solve(A.right);
        }
    }
}
