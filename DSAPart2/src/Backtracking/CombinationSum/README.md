# Combination Sum #

As per the question, we have an array and we need to check the subsets which has sum equal to B.  
Interesting point is we can take array element multiple times

Ex: A = [2, 3, 6, 7]  
B = 7  
Then output can be [2,2,3], [7], So here 2 can be taken twice.  

### Solution ###

Just like generating subsets, we can use that concept to generate different subsets, but here we have little difference-

1.) Elements can be considered multiple times

now the break condition is if sum is greater than B or sum is equal to B then only we will stop (previously we were stopping when i==array size)

but here we will have 3 conditions-

1.) an Element can be considered once
2.) an Element can be considered multiple times
3.) an Element can not be considered in sum.

So, just like previous solution, we can take the element and add it to sum, now this element can be repeated again, So do recurse again with same index
if Sum> B then return.
Now remove the last element from Sum and recurse for next elements in array.

Steps would be :  
Sum+=A[i]  
ans.add(A[i])  
CombSum(i)  
Sum-=A[i]  
ans.remove(ans.size()-1)  
CombSum(i+1)  


Ex: 2,3,6, B=7

 for i=0, Add 2 in sum and in temp array, temp={2}, Call CombSum(i), do not incremenet i  
 for i=0, Add 2 in sum and in temp array, temp={2,2}, sum=4, Call ComSum(i), do not increment i as we can include this element again and sum <B  
 for i=0, Add 2 in sum and in temp array, temp={2,2,2}, Sum=6, Call ComSum(i) do not increment i as we can include this element again and sum <B    
 for i=0, Add 2 in sum and in temp array, temp={2,2,2,2}, Sum=8, Call ComSum(i), but now sum>B, so return  
 for i=0, Now remove 2 from sum and from temp, Sum=6 and temp={2,2,2}, Call ComSum(i+1)   
 now, i=1, Add 3 in sum and in temp array, temp={2,2,2,3}, Sum=9, call ComSum(i), but Sum> B, So return  
 for i=1, now remove 3 from sum and from temp, Sum=6, and temp={2,2,2}, Call ComSum(i+1)  
 for i=2, Add 6, Sum=10 and temp is (2,2,2,6}, Sum>B, So return back to i=1, from there return back to i=0  
 for i=0, remove 2 from sum and temp (2,2), and sum=4, now call ComSum(i+1)  
 for i=1, Add 3, Sum=7 and temp is (2,2,3), Call ComSum(i)  
 B==Sum so add this temp to output.
 
 Continue this process untill all function calls are done, also check if i is going out of array bound then also return.
