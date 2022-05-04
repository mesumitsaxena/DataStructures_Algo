// See https://aka.ms/new-console-template for more information
using DSAbyScaler.Arrays.AdvancedArray_1;
using DSAbyScaler.Arrays.AdvancedArray2;
using DSAbyScaler.Arrays.AdvancedArray3;
using DSAbyScaler.Arrays.Intermediate.GeneralQuestions;
using DSAbyScaler.Arrays.Sorting;

//Console.WriteLine("Hello, World!");
//MultipleLeftRotation obj = new MultipleLeftRotation();
//obj.solve(new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 2, 3 });

//MatrixMultipication matri= new MatrixMultipication();
//List<List<int>> A= new List<List<int>>();
//A.Add(new List<int>() { 94,91});
//List<List<int>> B = new List<List<int>>();
//B.Add(new List<int>() { 35, -52, -12, 26, -93, -61 });
//B.Add(new List<int>() { 29, -20, -36, -9, 66, 15 });
//matri.solve(A, B);
//MaxNonNegSubArray obj= new MaxNonNegSubArray();
//obj.maxset(new List<int>() { 0, 0, -1, 0 });

//RainTrappingProblem obj= new RainTrappingProblem();
//obj.trap(new List<int>() { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
List<List<int>> list = new List<List<int>>();
list.Add(new List<int>() { 4,-1});
list.Add(new List<int>() { 2,3 });
SumofAllSubmatrices obj = new SumofAllSubmatrices();
obj.Sum(list);
