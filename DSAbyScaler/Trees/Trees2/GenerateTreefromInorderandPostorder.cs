using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    internal class GenerateTreefromInorderandPostorder
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        /// <summary>
        /// We will use the same technique as used in preorder and inorder
        /// only thing is in postorder, root of the whole tree is on the end of the array.
        /// So if we just reverse the post order array, it will become same as preorder 
        /// </summary>
        /// <param name="pre">PreOrder List</param>
        /// <param name="ps"> PreOrder Starting Index</param>
        /// <param name="pe">PreOrder Ending Index</param>
        /// <param name="ino">InOrder List</param>
        /// <param name="ins">InOrder Starting Index</param>
        /// <param name="ine">InOrder Ending Index</param>
        /// <returns></returns>
        public TreeNode generateTree(List<int> pre, int ps, int pe, List<int> ino, int ins, int ine, Dictionary<int, int> inOrderMap)
        {
            if (ps > pe) return null;
            //create root node for tree/subtree
            TreeNode node = new TreeNode(pre[ps]);
            // get the index of root from inorder in O(1)
            int indexofPreOrderElementinInorder = inOrderMap[pre[ps]];
            // find the number of elements on left from root in inorder array
            int numberOfElementOnLeft = indexofPreOrderElementinInorder - ins;
            // now call recursion function for left array (to create left subtree)
            node.left = generateTree(pre, ps + 1, ps + numberOfElementOnLeft, ino, ins, indexofPreOrderElementinInorder - 1, inOrderMap);
            // now call the recursion function for right array (to create right subtree)
            node.right = generateTree(pre, ps + numberOfElementOnLeft + 1, pe, ino, indexofPreOrderElementinInorder + 1, ine, inOrderMap);
            // return the node to attach it to previous root's left or right
            return node;
        }
        public TreeNode buildTree(List<int> A, List<int> B)
        {
            //after reversinf the postorder, the same question becomes as preorder
            A.Reverse();
            Dictionary<int, int> inOrderMap = new Dictionary<int, int>();
            for (int i = 0; i < B.Count; i++)
            {
                inOrderMap.Add(B[i], i);
            }
            TreeNode node = generateTree(A, 0, A.Count - 1, B, 0, B.Count - 1, inOrderMap);
            return node;
        }
    }
}
