package Heaps.Heaps2;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class HeapTestProgram {
    public static void main(String[] args) {
        HeapSort obj= new HeapSort();
        List<Integer> list=obj.heapSort(new ArrayList<>(Arrays.asList(5,2,8,1,7,4,3,0,6)));
        System.out.println(list);
    }
}
