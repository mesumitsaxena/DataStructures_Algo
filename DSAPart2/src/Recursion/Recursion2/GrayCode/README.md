# Gray Code #

**Problem Statement**

**The gray code is a binary numeral system where two successive values differ in only one bit.**

**Given a non-negative integer A representing the total number of bits in the code, print the sequence of gray code.**

**A gray code sequence must begin with 0.**

**Please refer the solution to know the problem in depth**

## Solution ##

As question states, gray code sequence starts with 0, and for every next sequence there is should be only 1 bit change

Input value is the number of bits in a number, i.e, if A=0, means 2^0 =>1, number of bits will be only 1. so, corresponding value will be 0 because in question, it is said that sequence will start with 0.

Now, next sequence will be A=1, means 2^1=2, so there will be two values with single bit, So first value will be 0 and other should be flip of previous so it will be 1

So, for A=1, values will be 0,1

Now, for A=2, number of bits will be 2 and values will be 2^2=4, which means

00
01
11
10

As you can see, all the above numbers have 1 bit differ in each sequence, so answer will be ( 00(0), 01(1), 11(3), 10(2))

Now, for A=3, number of bits will be 3 and values will be 2^3 = 8, which means

000
010
110
100
101
111
011
001

**Observation**

| A=0  |  A=1  |  A=2   |  A=3    |
|------|-------|--------|---------|
|  0   |   0   |  0**0**|   00**0**|
|      |   1   |  1**0**|   10**0**      |
|      |       |  1**1**|   11**0**      |
|      |       |  0**1**|   01**0**      |
|      |       |        |   01**1**      |
|      |       |        |   11**1**
|      |       |        |   10**1**
|      |       |        |   00**1**


As you can see in the above table, for A=1, there is only 1 bit change which is 1.

for A=2, if you see it carefully, first numbers are same as A=1 and 0 is appended in the end

But next two numbers are in reverse of first 2 numbers and appended 1 at the end

For A=3, Same first 4 numbers are same as A=2 and 0 is appended in the end

but next 4 numbers are in reverse of first 4 numbers of A=3 and 1 is appended in the end.

**So for every number we look for its previous number result.**
1. Copy that numbers and add 0 in the end
2. Make a copy of the numbers and reverse it and add 1 in the end.
