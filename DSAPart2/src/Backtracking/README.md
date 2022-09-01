# Permutations of Numbers #

We can swap the numbers and Add them into output.

Swap with which number? Swap with all possible numbers in the array.

After swapping the number, fix that number and do the swapping for next number with all possible numbers in the array.

Code Snippet can be-  

0.) if(i==n) output.add(A) return
1.) for(int j=i;j<A.size();j++){  
2.) Swap(A[i],A[j]);  
3.) Permutation(i+1);  
4.) Swap(A[j],A[i]);  
    }  

Lets see how it will work. Suppose we have 4,7,8

i=0, l=0, swap 4 with 4 Step 2. by this fixing 4 now call method Permutation(i+1) - Step 3  
i=1, l=1, swap 7 with 7 Step 2. by this fixing 7 now call method Permutation(i+1) - Step 3  
i=2, l=2, swap 8 with 8 Step 2, by this fixing 8 now call method Permutation(i+1) - Step 3  
i=3, now i==n, so add A into output [4,7,8] - Step 0  

i=2, l=2, swap back 8 with 8 - Step 4, increase l++, l>size, return back to Step 4 for i=1 and l=1  
i=1, l=1, swap back 7 with 7 - Step 4, increase l++. i=1, l=2 -Step 1  
i=1, l=2, swap 7 with 8 - Step 2, by fixing 8, now call method Permutation(i+1) -Step 3  
i=2, l=2, swap 7 with 7 - Step 2, by fixing 7, now call method Permutation(i+1) - Step 3  
i=3, now i==n, So add A into output ([4,7,8],[4,8,7])
...   
... and so on   

![image](https://user-images.githubusercontent.com/83850703/187930096-8b44dd73-b5cc-4da4-bc6d-25cff23e20ef.png)


