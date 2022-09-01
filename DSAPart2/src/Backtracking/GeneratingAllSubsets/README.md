# Generating All Subsets #

For any given time, Either we can include the element or not include the element.  
For example:  if A= 1 ,2 ,3  

for i=0, We can add 1 or not add 1, Suppose we add 1, then temp=1  
for i=1, we can add 2 or not add 2, Suppose we add 2, then temp=1,2  
for i=2, we can add 3 or not add 3, Suppose we add 3, then temp= 1,2,3, i== size of array, Add temp into output array, Output= [(1,2,3)]

for i=2, now lets not add 3, then temp = 1,2, i== size of array, Add temp into output array. Output= [(1,2,3), (1,2)]

for i=1, now lets not add 2, then temp = 1
for i=2, we can add 3, or not add 3, Suppose we add 3, then temp = 1,3, i==size of array, Add temp into output array, Output= [(1,2,3), (1,2), (1,3)]  

for i=2, now lets not add 3, then temp = 1, i== size of array, Add temp into output array. Output= [(1,2,3), (1,2), (1,3), (1)]  

for i=0, now lets not add 1, then temp ={}
for i=1, we can add 2 or not add 2, Suppose we add 2, then temp= 2  
for i=2, we can add 3 or not add 3, Suppose we add 3, then temp= 2,3, i== size of array, Add temp into output array, Output= [(1,2,3), (1,2), (1,3), (1), (2,3)]

for i=2, now lets not add 3, then temp = 2,  i== size of array, Add temp into output array, Output= [(1,2,3), (1,2), (1,3), (1), (2,3), (2)]

for i=1, now lets not take 2, then temp ={}
for i=2, we can add 3 or not add 3, Suppose we add 3, then, temp=3, i== size of array, Add temp into output array, output= [(1,2,3), (1,2), (1,3), (1), (2,3), (2),(3)]

for i=2, lets not add 3, them temp ={}, i== size of array, so add temp into output, output= [(1,2,3), (1,2), (1,3), (1), (2,3), (2),(3), {}]

**We when add that element, lets consider an temp array and temp.add()  will add that element in the array  
But when we do not add that element, it means whatever we have added just remove that element from the temp array**


In Order to generate all subsets, there are simple steps -

- Add the ith index in Subset List (temp.add(A.get(i))
- Recurse the same for next element (GenerateSubsets(i+1))
- Remove the last element in Subset list (temp.remove(temp.size()-1)
- Recurse the same for next element (GenerateSubsets(i+1))

Base condition will be when i==size of array, then add subset list into 2D output array (output.add(temp)) and return

![image](https://user-images.githubusercontent.com/83850703/187623586-5765c193-4cc8-48fa-911a-7eec117990cc.png)
