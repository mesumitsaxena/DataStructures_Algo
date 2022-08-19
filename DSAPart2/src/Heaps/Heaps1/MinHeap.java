package Heaps.Heaps1;

import java.util.Collections;
import java.util.List;

public class MinHeap {
    public void GenerateHeap(List<Integer> heapArray){
        int ind=(heapArray.size()/2)-1;
        for(int i=ind;i>=0;i--){
            Heapify(heapArray,i);
        }
    }
    public void swap(List<Integer> heapArray, int from, int to){
        Collections.swap(heapArray,from,to);
    }
    public void Insert(List<Integer> heapArray, int val){
        heapArray.add(val);
        int valIndex=heapArray.size()-1;
        int parentIndex=(valIndex-1)/2;
        while(valIndex>0){
            if(heapArray.get(valIndex)<heapArray.get(parentIndex)){
                swap(heapArray,valIndex,parentIndex);
            }
            valIndex=parentIndex;
            parentIndex=(valIndex-1)/2;
        }
    }
    public int extractMin(List<Integer> heapArray){
        int min=heapArray.get(0);
        int lastIndex=heapArray.size()-1;
        swap(heapArray,0,lastIndex);
        heapArray.remove(lastIndex);
        int ind=0;
        Heapify(heapArray,0);
        return min;
    }
    public void Heapify(List<Integer> heapArray, int ind){
        int leftChildIndex=(2*ind+1);
        int rightChildIndex=(2*ind+2);
        int heapSize=heapArray.size();
        while(leftChildIndex<heapSize){
            int min=0;
            if(rightChildIndex<heapSize){
                min=Math.min(heapArray.get(ind),Math.min(heapArray.get(leftChildIndex),heapArray.get(rightChildIndex)));
            }
            else{
                min=Math.min(heapArray.get(ind),heapArray.get(leftChildIndex));
            }
            if(min==heapArray.get(ind)){
                break;
            }
            else if(min==heapArray.get(leftChildIndex)){
                swap(heapArray,ind,leftChildIndex);
                ind=leftChildIndex;
            }
            else if(rightChildIndex<heapSize && min==heapArray.get(rightChildIndex)) {
                swap(heapArray, ind, rightChildIndex);
                ind = rightChildIndex;
            }
            leftChildIndex=2*ind+1;
            rightChildIndex=2*ind+2;
        }

    }
}
