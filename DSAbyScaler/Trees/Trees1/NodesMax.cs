using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees1
{
    //You are given the root node of a binary tree A.You have to find the max value of all node values of this tree.
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

    // 4 
    //Output 2:

    // 8 


    //Example Explanation

    //Explanation 1:

    //Clearly, among 1, 4, 3: 4 is maximum.
    //Explanation 2:

    //Clearly, among 1, 8, 3, 2: 8 is maximum.
    internal class NodesMax
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // In order to find the max among all the nodes, we will do the same as addition
        // in Addition, we added Node value+ Sum of left tree+ Sum of right tree.
        // and if left or right subtree is null then return null.

        // Same concept, only thing we need to find the maximum.
        // Maximum value among current node and maxmimum on left and maximum on right
        // basically max(current node, max(left side, right side)).
        // left and right side will return their respective max, we return between current node, left max, right max
        public int solve(TreeNode A)
        {
            if (A == null) return 0;
            return Math.Max(A.val, Math.Max(solve(A.left), solve(A.right)));
        }
    }
}
