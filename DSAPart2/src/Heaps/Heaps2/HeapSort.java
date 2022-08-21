package Heaps.Heaps2;

import Heaps.Heaps1.MaxHeap;

import java.util.Collections;
import java.util.List;
import java.util.PriorityQueue;

public class HeapSort {
    // Steps:
    // we can create a heap out of the Array, (what kind of heap? max or min, lets see--)
    // After creating the heap, we can choose the first value(root value) and can move, now what value you want to move?
    // we can take a value and move it to end of the array and end of the array should be maximum for sorted array
    // So if we want a value from starting which should be maximum and move it to end, than we will create maxheap
    // after creatting the maxheap, we will pick the max value(0th index) and swap it with last index
    // now last index is sorted, So we can take a size variable and do size--, now onwards perform operation from 0 to size for that array
    // and so on till size>0
    // need to create the heapify function because we want to pass the size explicitly
    public void Heapify(List<Integer> A, int ind,int size){
        while(2*ind+1<size){
            int max=0;
            if(2*ind+2<size){
                max=Math.max(A.get(ind),Math.max(A.get(2*ind+1),A.get(2*ind+2)));
            }
            else{
                max=Math.max(A.get(ind),A.get(2*ind+1));
            }
            if(max==A.get(ind)){
                break;
            }
            else if(max==A.get(2*ind+1)){
                Collections.swap(A,ind,2*ind+1);
                ind=2*ind+1;
            }
            else if(2*ind+2<size && max==A.get(2*ind+2)){
                Collections.swap(A,ind,2*ind+2);
                ind=2*ind+2;
            }
        }
    }
    public List<Integer> heapSort(List<Integer> A){
        MaxHeap maxHeap= new MaxHeap();
        maxHeap.GenerateHeap(A);
        int size=A.size();
        while(size>0){
            int temp=A.get(size-1);
            A.set(size-1,A.get(0));
            A.set(0,temp);
            size--;
            Heapify(A,0,size);
        }
        return A;
    }
}
