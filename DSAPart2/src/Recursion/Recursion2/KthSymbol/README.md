# Kth Symbol #

So the question clearly says, we have to replace 0 with 01 and 1 with 10
**0-> 01 and 1->10

As per the above understanding -

As per the above understanding, and question clearly stated that start with 1st row and its value will be 0.

A=1 (here A represent the row number) -> its corresponding value will be 0
After that for next row, look at the previous row and replace 0 with 01 and 1 with 10

A=2 - 0**1** (because A=1 has only one 0)

A=3 - 01**10** (because A=2 has 01, so 0 will be replaced by 01 and 1 will be replaced by 10, 0(01)1(10))

A=4 - 0110**1001**

A=5 - 01101001**10010110**

Here, if A=4 and B=3, it means for row 4, return the 3rd bit(1 based), So answer will be 1 (01 **1(this bit)** 01001)

![image](https://user-images.githubusercontent.com/83850703/187352753-33046851-50cf-4a72-8125-67f72da28b64.png)

From above example, there are 2 observation -

1.) for any row except A=1, there are 2 halfs, second half will always have flip of first half, example:

A=4 0110(first half) and in second half all the bits are flip of first half, 1001(second half)

2.) Second observation is, for a given row, how many bits are there? 

for A=3 - 4 bits are there it means 2^2

for A=4 - 8 bits are there it means 2^3

for A=5 - 16 bits are there it means 2^4

so, in general -

for A=i - 2^(i-1) bits will be there

## Solution

for a given row, suppose A=5, if B is asked in first half, suppose B=5, which is 1, then we can directly give from A=4, right? because A=4 value and A=5 first half is same

if B is asked in second half, suppose B=13, then we will have to find it in A=4 but flip the bit, how can we find the bit in A=4?

for a given row and B, in order to check B lies in first half or second half, we can check using below method-

if B is in first half,

Example: A=4, and B=2, A has 2^3 bits, So its first half bits will be equal to A=2 bits right, (A=4 - 0110 **1001**, and A=3 is 0110, we can see, first of A=4 is same as A=3 full

So, we can check if B<=2^2

for A=5, we can check if B is in first half as, if B<=2^3

for A=6, we can check if B is in first half as, if B<=2^4

**So for general A=i, we can check if B is in first half as, if B<=2^(i-2)**

else B is in second half

if B is in first half then look in previous row same B

**if B is in second half, then look in previous row but B-2^(i-2), example: A=5, B=13, first half is till 8, so 13-8=5, look in A=4, 5th bit**

Please refer the code for  more understanding
