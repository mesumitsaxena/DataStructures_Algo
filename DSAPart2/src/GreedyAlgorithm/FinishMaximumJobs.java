package GreedyAlgorithm;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;

//There are N jobs to be done, but you can do only one job at a time.
//
//        Given an array A denoting the start time of the jobs and an array B denoting the finish time of the jobs.
//
//        Your aim is to select jobs in such a way so that you can finish the maximum number of jobs.
//
//        Return the maximum number of jobs you can finish.
//        Input Format
//        The first argument is an integer array A of size N, denoting the start time of the jobs.
//        The second argument is an integer array B of size N, denoting the finish time of the jobs.
//
//
//
//        Output Format
//        Return an integer denoting the maximum number of jobs you can finish.
//
//
//
//        Example Input
//        Input 1:
//
//        A = [1, 5, 7, 1]
//        B = [7, 8, 8, 8]
//        Input 2:
//
//        A = [3, 2, 6]
//        B = [9, 8, 9]
//
//
//        Example Output
//        Output 1:
//
//        2
//        Output 2:
//
//        1
//
//
//        Example Explanation
//        Explanation 1:
//
//        We can finish the job in the period of time: (1, 7) and (7, 8).
//        Explanation 2:
//
//        Since all three jobs collide with each other. We can do only 1 job.
class Pair implements Comparable<Pair>{
    int start;
    int end;

    Pair(int start, int end){
        this.start=start;
        this.end=end;
    }

    @Override
    public int compareTo(Pair o1) {
        return this.end-o1.end;
    }
}
public class FinishMaximumJobs {
    // Here, any job which is ending first will create more opportunity to take up more jobs.
    // example:  suppose there are many meetings, there can be meeting from 7am to 10 am, then 9am to 11am, then 12 to 2 pm
    // and 1 to 3pm etc
    // Obviously we cant be there in 2 meetings, so overlap will not be counted
    // Now, how can we attend max number of meetings?
    // any meeting which is ending early, will allow us to attend more meetings.
    // So if we sort both arrays based on ending time array, then we can choose first pair, as it is ending early
    // then check if last meeting ending time is less than next meeting starting time, if yes, then we can skip
    // that meeting as it is overlapping
    // if last meeting ending time is less than next meeting starting time, than include the next meeting
    // and so on
    // prepare an pair in order to sort both array based on ending time

    public int solve(ArrayList<Integer> A, ArrayList<Integer> B) {
        ArrayList<Pair> pairs= new ArrayList<>();
        for(int i=0;i<A.size();i++){
            pairs.add(new Pair(A.get(i),B.get(i)));
        }
        Collections.sort(pairs);
        int lastTime=pairs.get(0).end;
        int count=1;
        for(int i=1;i<pairs.size();i++){
            Pair currentTime=pairs.get(i);
            if(lastTime<=currentTime.start){
                count++;
                lastTime=currentTime.end;
            }

        }
        return count;
    }
}
