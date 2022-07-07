using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack1
{
    //Given a string A representing an absolute path for a file(Unix-style).

    //Return the string A after simplifying the absolute path.

    //Note:

    //In Unix-style file system:

    //A period '.' refers to the current directory.
    //A double period '..' refers to the directory up a level.
    //Any multiple consecutive slashes '//' are treated as a single slash '/'.
    //In Simplified Absolute path:

    //The path starts with a single slash '/'.
    //Any two directories are separated by a single slash '/'.
    //The path doesn't end with trailing slashes '/'.
    //The path only contains the directories on the path from the root directory to the target file or directory(i.e., no period '.' or double period '..')
    //Path will not have whitespace characters.

    //Input Format

    //The only argument given is string A.
    //Output Format

    //Return a string denoting the simplified absolute path for a file (Unix-style).
    //For Example

    //Input 1:
    //    A = "/home/"
    //Output 1:
    //    "/home"

    //Input 2:
    //    A = "/a/./b/../../c/"
    //Output 2:
    //    "/c"
    internal class SimplifyDirectoryPath
    {
        //As we can see, if we have .. then we will go back to previous directory path i.e pop the last element
        // if we have . or / or blank then we do not have to do anything
        // when we have a character then we have to store it somewhere because when we recieve .. it means we have to remove last directory
        // how do we get the last item value easily, can you think something as top, right, we will use stack.
        public string simplifyPath(string A)
        {
            // why string stack? we can directory name as string as well.
            Stack<string> directoryStack = new Stack<string>();
            // why starting with 1, we know starting char will always be /, and we have to get the string from 1st / to another /
            // so start with 1 as look for next /
            int i = 1;
            while (i < A.Length)
            {
                System.Text.StringBuilder directoryName = new System.Text.StringBuilder();
                while(i<A.Length && A[i]!='/')
                {
                    directoryName.Append(A[i]);
                    i++;
                }
                string directoryString=directoryName.ToString();
                // if string is .. then go back to last directory by removing the top element
                if(directoryStack.Count>0 && directoryString == "..")
                {
                    directoryStack.Pop();
                }
                // if the string is directoryname, not .,/,.. then add in stack
                else if(directoryString!="" && directoryString!="." && directoryString!="/" && directoryString != "..")
                {
                    directoryStack.Push(directoryString);
                }
                i++;
            }
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            List<string> list = new List<string>();
            while (directoryStack.Count > 0)
            {
                list.Add(directoryStack.Pop());
            }
            string output = reverse(list);
            return output;

        }
        public string reverse(List<string> sb)
        {
            System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
            if (sb.Count == 0)
            {
                sb2.Append("/");
            }
            for (int i = sb.Count - 1; i >= 0; i--)
            {
                //add / first then directory name
                sb2.Append("/");
                sb2.Append(sb[i]);
            }
            return sb2.ToString();
        }
    }
}
