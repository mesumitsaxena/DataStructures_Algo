using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees1
{
    //You are given the root node of a binary tree A.You have to find the number of nodes in this tree.
    //    Example Input
    //Input 1:

    // Values = 1
    //          / \     
    //         4   3                        
    //Input 2:



    // Values = 1
    //          / \     
    //         4   3                       
    //        /         
    //       2                                     


    //Example Output
    //Output 1:

    // 3 
    //Output 2:

    // 4 


    //Example Explanation
    //Explanation 1:

    //Clearly, there are 3 nodes 1, 4 and 3.
    //Explanation 2:

    //Clearly, there are 4 nodes 1, 4, 3 and 2.
    internal class NodesCount
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // with recursion we will go till the leaf node and will return 0.
        // why return 0? we will make a pattern in a way we will always return the number of nodes of the children
        // to the root.
        // for leaf node, do we have any children? No, so that is why childrens will return 0 to leaf node.
        // but if that is not the leaf node and that node has to return total number of node till that node,
        // then it will add left children count and right children count and +1(include the current node as well)
        public int solve(TreeNode A)
        {
            // if node is null then return 0 as number of children to leaf node
            if(A==null) return 0;
            //int leftCount=solve(A.left);
            //int rightCount=solve(A.right);
            //return leftCount + rightCount + 1;
            // else numebr of children on left+ number of children on right + 1(current node)
            return solve(A.left) + solve(A.right) + 1;
        }
    }
}
