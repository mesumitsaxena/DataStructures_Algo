using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Given preorder and inorder traversal of a tree, construct the binary tree.

    //NOTE: You may assume that duplicates do not exist in the tree.
    //Input Format
    //First argument is an integer array A denoting the preorder traversal of the tree.

    //Second argument is an integer array B denoting the inorder traversal of the tree.



    //Output Format
    //Return the root node of the binary tree.



    //Example Input
    //Input 1:

    // A = [1, 2, 3]
    // B = [2, 1, 3]
    //Input 2:

    // A = [1, 6, 2, 3]
    // B = [6, 1, 3, 2]


    //Example Output
    //Output 1:

    //   1
    //  / \
    // 2   3
    //Output 2:

    //   1  
    //  / \
    // 6   2
    //    /
    //   3
    internal class GenerateTreefromInorderPeorder
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        /* We can build the tree if and only if we are given with preorder and inorder traversal
         because from pre order we can find the root for a subtree and also for whole tree as well (1st node will be root of whole tree in preorder)
         then we will search that node in inorder to know left subtree and right subtree of that node.
         why do we need inorder? lets understand with an example: 
         preorder = [1, 6, 2, 3]
         inorder  = [6, 1, 3, 2]
         we have preorder so, we know 1 will be root for sure, now are we 100% sure and infer that 6 will be left of 1, NO
         because it is possible that there is no left of 1, 6 might be right, So alone preorder can not give any result to us.
         by inorder if we know the root, we can search in inorder and then we will know what part is left subtree and what is right subtree

         So now we know that we need inorder to know what is on left subtree and what will be on right subtree
         Lets understand with above example only - 
         
         1 is root which is given by preorder, now search 1 in inorder list, we found 1 at index 1 in inorder
         So Create a node 1.
          
                  1(root)  
                 / \
                6   2,3

         Now we know 6 is left subtree and 2,3 is right subtree.
         How can create this above structure, we can create logical structure by diving the array by storing indexes
         So we can say , by inorder, we go to know that at left of 1, there is only 1 element and at right of 1, there are 2 elements
         or we can say found index of 1 is 1, So index =1, and on left subtree there is only one element, So we can say 
         number of element on left in order = index- inorder start index = 1-0 =1
         So pre order start for left subtree will be previous position +1(ps=0+1) and ending will be ps+1 =0+1=1
         
         and for preorder start for right subtree will be index+1 = 2 and ending will remain same as pe whihc is end of array

         Now we know on root of left subtree is 6 from pre order, ps=1 and pe=1, So 6
         and for right, ps=2(index), so root will be 2(value), and left is nothing and right will be 3

        So by indexing we will be able to create virtual division of preorder and inorder

        lets understand the purpose of preorder and inorder
        1.) we take root of the subtree from preorder
        2.) search the node in inorder list
        3.) from inorder we will get to know about number of elements(x) on left
        4.) after knowing the number of elements from left index left subtree from ps+1 to ps+x, and for right subtree ps+x+1 to pe
        5.) apply same on left subtree and right subtree, untill ps > pe

        */
        /// <summary>
        /* We can build the tree if and only if we are given with preorder and inorder traversal
        because from pre order we can find the root for a subtree and also for whole tree as well(1st node will be root of whole tree in preorder)
         then we will search that node in inorder to know left subtree and right subtree of that node.
         why do we need inorder? lets understand with an example: 
         preorder = [1, 6, 2, 3]
        inorder  = [6, 1, 3, 2]
        we have preorder so, we know 1 will be root for sure, now are we 100% sure and infer that 6 will be left of 1, NO
         because it is possible that there is no left of 1, 6 might be right, So alone preorder can not give any result to us.
         by inorder if we know the root, we can search in inorder and then we will know what part is left subtree and what is right subtree

         So now we know that we need inorder to know what is on left subtree and what will be on right subtree
         Lets understand with above example only - 
         
         1 is root which is given by preorder, now search 1 in inorder list, we found 1 at index 1 in inorder
         So Create a node 1.
          
                  1(root)
                 / \
                6   2,3

         Now we know 6 is left subtree and 2,3 is right subtree.
         How can create this above structure, we can create logical structure by diving the array by storing indexes
         So we can say, by inorder, we go to know that at left of 1, there is only 1 element and at right of 1, there are 2 elements
         or we can say found index of 1 is 1, So index = 1, and on left subtree there is only one element, So we can say
         number of element on left in order = index - inorder start index = 1 - 0 = 1
         So pre order start for left subtree will be previous position +1(ps= 0 + 1) and ending will be ps+1 =0+1=1
         
         and for preorder start for right subtree will be index+1 = 2 and ending will remain same as pe whihc is end of array

         Now we know on root of left subtree is 6 from pre order, ps=1 and pe = 1, So 6
         and for right, ps=2(index), so root will be 2(value), and left is nothing and right will be 3

        So by indexing we will be able to create virtual division of preorder and inorder

        lets understand the purpose of preorder and inorder
        1.) we take root of the subtree from preorder
        2.) search the node in inorder list
        3.) from inorder we will get to know about number of elements(x) on left
        4.) after knowing the number of elements from left index left subtree from ps+1 to ps+x, and for right subtree ps+x+1 to pe
        5.) apply same on left subtree and right subtree, untill ps > pe

        Now searching an element in Inorder again and again for each element from Preorder, can lead us in O(N^2) TC
        So we can use hashmap, by storing each value of inorder in map along with its index
        */
        /// </summary>
        /// <param name="pre">PreOrder List</param>
        /// <param name="ps"> PreOrder Starting Index</param>
        /// <param name="pe">PreOrder Ending Index</param>
        /// <param name="ino">InOrder List</param>
        /// <param name="ins">InOrder Starting Index</param>
        /// <param name="ine">InOrder Ending Index</param>
        /// <returns></returns>
        public TreeNode generateTree(List<int> pre, int ps, int pe, List<int> ino, int ins, int ine, Dictionary<int,int> inOrderMap)
        {
            if (ps > pe) return null;
            //create root node for tree/subtree
            TreeNode node = new TreeNode(pre[ps]);
            // get the index of root from inorder in O(1)
            int indexofPreOrderElementinInorder=inOrderMap[pre[ps]];
            // find the number of elements on left from root in inorder array
            int numberOfElementOnLeft = indexofPreOrderElementinInorder - ins;
            // now call recursion function for left array (to create left subtree)
            node.left = generateTree(pre, ps + 1, ps + numberOfElementOnLeft, ino, ins, indexofPreOrderElementinInorder - 1,inOrderMap);
            // now call the recursion function for right array (to create right subtree)
            node.right = generateTree(pre, ps + numberOfElementOnLeft + 1, pe, ino, indexofPreOrderElementinInorder + 1, ine,inOrderMap);
            // return the node to attach it to previous root's left or right
            return node;
        }
        public TreeNode buildTree(List<int> A, List<int> B)
        {
            Dictionary<int, int> inOrderMap = new Dictionary<int, int>();
            for(int i = 0; i < B.Count; i++)
            {
                inOrderMap.Add(B[i],i);
            }
            TreeNode node = generateTree(A, 0, A.Count - 1, B, 0, B.Count - 1, inOrderMap);
            return node;
        }
    }
}
