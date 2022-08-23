package Heaps.Heaps2;

import java.util.*;

//You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.
//
//        Define a pair (u, v) which consists of one element from the first array and one element from the second array.
//
//        Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.
//
//
//
//        Example 1:
//
//        Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
//        Output: [[1,2],[1,4],[1,6]]
//        Explanation: The first 3 pairs are returned from the sequence: [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
//        Example 2:
//
//        Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
//        Output: [[1,1],[1,1]]
//        Explanation: The first 2 pairs are returned from the sequence: [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
//        Example 3:
//
//        Input: nums1 = [1,2], nums2 = [3], k = 3
//        Output: [[1,3],[2,3]]
//        Explanation: All possible pairs are returned from the sequence: [1,3],[2,3]
//        https://leetcode.com/problems/find-k-pairs-with-smallest-sums/
//class customPair{
//    int sum;
//    int first;
//    int second;
//    customPair(int sum, int first, int second){
//        this.sum=sum;
//        this.first=first;
//        this.second=second;
//    }
//}
class customPairSorting implements Comparator<customPair> {
    @Override
    public int compare(customPair o1, customPair o2) {
        return o2.sum-o1.sum;
    }


}
class custom2DArraySort implements Comparator<List<Integer>> {



    @Override
    public int compare(List<Integer> o1, List<Integer> o2) {
        return o1.get(0)-o2.get(0) + o1.get(1)-o2.get(1);
    }
}
class KMinPairCombination {

    public List<List<Integer>> kSmallestPairs(int[] nums1, int[] nums2, int k) {
        PriorityQueue<customPair> pQ= new PriorityQueue<>(new customPairSort());
        int size1=nums1.length-1;
        int size2=nums2.length-1;
        for(int i=0;i<=size1;i++){
            for(int j=0;j<=size2;j++){
                if(pQ.size()<k){
                    pQ.offer(new customPair(nums1[i]+nums2[j],nums1[i],nums2[j]));
                }
                else{
                    if(nums1[i]+nums2[j]<pQ.peek().sum){
                        pQ.poll();
                        pQ.offer(new customPair(nums1[i]+nums2[j],nums1[i],nums2[j]));
                    }
                    else{
                        break;
                    }
                }
            }
        }
        List<List<Integer>> output= new ArrayList<>();
        while(pQ.size()>0){
            ArrayList<Integer> temp= new ArrayList<>();
            customPair pair=pQ.poll();
            temp.add(pair.first);
            temp.add(pair.second);
            output.add(temp);
        }
        Collections.sort(output, new custom2DArraySort());
        if(k>output.size()) return output;
        return output.subList(0,k);
    }
}
