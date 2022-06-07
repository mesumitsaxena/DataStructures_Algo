using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch3
{
    //Given an array of integers A of size N and an integer B.
    //The College library has N books.The ith book has A[i] number of pages.
    //You have to allocate books to B number of students so that the maximum number of pages allocated to a student is minimum.
    internal class AllocateBooks
    {
        // Main motive is to allot all the books to B or less students, but configuration should be such that it maximum number of pages should be alloted would be minimum among B students.
        // what do we mean by maximum number of pages should be minimum? lets understand.
        // suppose we allot some number of pages to each student but still some books or pages left, then that is invalid condition
        // we want that point when if we increment the count of pages per student and all the books are alloted, we want that point after the invalid condition when it is become valid.
        // we can allot all the pages to 1 student which will be maxmimum pages are alloted
        // ****but we want that minimum number of pages distribution when each student will get maxmimum number of pages
        // understand in this way FFFFF[T]TTTT , so first five false means these number of pages if alloted to eacg
        // all the books will not be alloted, and the moment when we we see [T] which means this is the point when if we allot these number of pages to student then 
        // all the books will be alloted to students. that is what maximum number of pages should be minimum means


        // First of all if there are B students and we have less than B books, then we can not allot the books, so we will return -1
        // Now, how do I decide how many pages we have to allot or how many books we will allot.
        //
        // Case 1: Suppose we are having same number of student as of books, so we will give each book to each student
        // in that case maximum number of pages which are alloted will be the book with max pages.
        // if we say student each student getthe  number of pages which is minimum then student with maxmimum pages will shout hey i got the maximum pages, so that is why we will consider maximum number if all will get 1 book
        // Case 2: Suppose we have only 1 student then we will allot all the books to the student, so sum of all pages will be max number of pages alloted

        // So startin range would be max page to sum of all pages
        // Now check if from starting range if it is possible to allot the books to all the students, if no, then check on the right hand side
        // if yes than that could be our answer and check on the left hand side
        public int books(List<int> A, int B)
        {
            // if number of students are more than books, then we cant allot books to each student
            if (B > A.Count) return -1;
            // Maximum number of range will be sum of all pages(if all books will be alloted to 1 student)
            int maxrange = 0;
            // Start Range would be maxmimum number of page in among all books
            int startrange = Int32.MinValue;
            for (int i = 0; i < A.Count; i++)
            {
                // Calculate max range
                maxrange += A[i];
                //calculate starting range
                if (A[i] > startrange)
                {
                    startrange = A[i];
                }
            }
            int left = startrange;
            int right = maxrange;
            int ans = 0;    
            while (left <= right)
            {
                int mid = (left + right) / 2;
                // if mid(number of pages) says yes we can allot these number of pages to each student
                // ans we can still allot all the books then we can say this can be our answer, numbers after that can also be the answer(because larger number of pages if we allocate then we will be able to complete all books)
                // lets store the answer and look for better answer on left
                if (check(A, B, mid))
                {
                    ans = mid;
                    right = mid - 1;
                }
                // if mid(number of pages) says no we can not allot these number of pages to each student
                // it means less number of pages will also not be able to allot the books
                // So look for the answer on right side
                else
                {
                    left = mid + 1;
                }
            }
            // now return the manimize maximum answer
            return ans;
        }
        public bool check(List<int> A, int B, int mid)
        {
            // lets allot the first book to student1
            int student = 1;
            int current_book = A[0];
            for (int i = 1; i < A.Count; i++)
            {
                //now check if next book pages can be included? if number of pages with currentbook is exceeding with mid
                // means lets assign this book to another student
                if (current_book + A[i] > mid)
                {
                    student++;
                    current_book = A[i];
                }
                // else assign this book to current student
                else
                {
                    current_book += A[i];
                }
            }
            // in the end, if total books are alloted to B students or less than B students then it is fine and return true
            if (student <= B) return true;
            // if all the books are not alloted to B students then this mid is not maximum so return false check for 
            // next mid which will be greater so check on right hand side.
            return false;
        }
    }
}
