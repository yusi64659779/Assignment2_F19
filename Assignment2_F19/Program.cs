﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment2_F19
{
    class Program
    {
        public static void Main(string[] args)
        {

            int target = 5;

            int[] nums = { 1, 3, 5, 6 };

            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));



            int[] nums1 = {1,2,2,3,3};

            int[] nums2 = {2,3,1,3,4};

            int[] intersect = Intersect(nums1, nums2);

            Console.Write("Intersection of two arrays is: ");

            DisplayArray(intersect);

            Console.WriteLine("\n");



            int[] A = {  9, 9, 8, 8,10};

            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));



            string keyboard = "pqrstuvwxyzabcdefghijklmno";

            string word = "munja";

            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));



            int[,] image = { { 1, 1, 0 ,1,0}, { 1, 0, 1,1,0 }, { 0, 0, 0 ,1,1} };

            int[,] flipAndInvertedImage = FlipAndInvertImage(image);

            Console.WriteLine("The resulting flipped and inverted image is:\n");

            Display2DArray(flipAndInvertedImage);

            Console.Write("\n");



            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };

            int minMeetingRooms = MinMeetingRooms(intervals);

            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);



            int[] arr = { -4, -1, 0, 3, 10 };

            int[] sortedSquares = SortedSquares(arr);

            Console.WriteLine("Squares of the array in sorted order is:");

            DisplayArray(sortedSquares);

            Console.Write("\n");



            string s = "abca";

            if (ValidPalindrome(s))
            {

                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);

            }

            else

            {

                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);

            }

        }



        public static void DisplayArray(int[] a)

        {

            foreach (int n in a)

            {

                Console.Write(n + " ");

            }

        }



        public static void Display2DArray(int[,] a)

        {

            for (int i = 0; i < a.GetLength(0); i++)

            {

                for (int j = 0; j < a.GetLength(1); j++)

                {

                    Console.Write(a[i, j] + "\t");

                }

                Console.Write("\n");

            }

        }



        public static int SearchInsert(int[] nums, int target)
        {
            Array.Sort(nums);
            // get_middle will be used to get the element in the middle of the array. Initialize to 0 for now.
            int get_middle = 0;
            // This is the lower element of the array. Initialize to 0 for now. 
            int low = 0;
            // This is the upper element of the array
            int high = (nums.Length) - 1;
            // This is the middle of the array. mid is rounded down automatically if (low + high) is not an even number
            int mid;
            // This variable is used to track where the middle is. You will later in this code how this prevents an infinite loop in the Binary Search
            int track_middle = 0;
            // Here is the Binary Search Algorithm
            try
            {
                while (low <= high)
                {
                    // Reset mid each time the while iterates
                    mid = (low + high) / 2;
                    // Get the middle element in the binary_search array
                    // Reset get middle each time the while loop iterates
                    get_middle = nums[mid];
                    // This will test to true if the match in the Binary Search is found
                    if (get_middle == target)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(mid);
                        // Break out of the loop once the match for the search is found
                        break;
                    }
                    // The && get_middle != track_middle test is conducted in case an integer is entered by the user that does not exist in the array
                    // Also, this if statement is used to re-assign the value of high if needed 
                    if (get_middle > target && get_middle != track_middle)
                    {
                        high = mid - 1;
                      // Keep track of the middle by assigning the current middle value (get_middle) to track_middle
                        track_middle = get_middle;
                    }
                    // This re-assigns the value of low as needed in the loop
                    else
                    {
                        // If no match is found, low will continue to increase 1 more until it exceeds high (as tested in the while loop), then the loop will stop
                        // Otherwise, low will be used to continue the search
                        low = mid + 1;
                    }
                }
                if (low > high)
                {
                    Console.WriteLine(low);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }
            return low;

        }



        public static int[] Intersect(int[] nums1, int[] nums2)

        {
            List<int> intersec = new List<int>();
            try
            {
                Dictionary<int, int> mydictionary1 = new Dictionary<int, int>();               
                foreach (int num in nums1)
                {
                    if (!mydictionary1.ContainsKey(num))
                    {
                        mydictionary1.Add(num, 1);
                    }
                    else
                    {
                        mydictionary1[num]++;
                    }
                }
                foreach (int num in nums2)
                {
                    if (mydictionary1.ContainsKey(num) && mydictionary1[num] > 0)
                    {
                        intersec.Add(num);
                        mydictionary1[num]--;
                    }
                }

            }

            catch

            {

                Console.WriteLine("Exception occured while computing Intersect()");

            }

            return intersec.ToArray();

           
            

        }



        public static int LargestUniqueNumber(int[] A)

        {
            int t=-1;
            try
            {
                Array.Sort(A);
                int i = A.Length - 1;
                for (; i > 0; i--)
                {
                    if (A[i] == A[i-1])
                    {
                        i--;
                    }
                    else
                    {
                        t = A[i];
                        break;
                    }   
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }
            return t;

        }



        public static int CalculateTime(string keyboard, string word)

        {         
            int r=0;
            if ((keyboard[0] - word[0]) > 0)
                r = 26 - (keyboard[0] - word[0]);
            else
                r = Math.Abs(keyboard[0] - word[0]);
            //Console.WriteLine(r);
            try
            {
                int a=0;
                int b=0;
                for (int j = 1; j < word.Length; j++)
                {
                    
                    if ((keyboard[0]-word[j])>0 && (keyboard[0] - word[j - 1])>0)
                    {
                        a = 26 - (keyboard[0] - word[j]);
                        //Console.Write(a);
                        b = 26 - (keyboard[0] - word[j - 1]);
                       // Console.WriteLine(b);
                    }
                    else if((keyboard[0] - word[j]) < 0 && (keyboard[0] - word[j - 1]) < 0)
                    {
                        a = Math.Abs(keyboard[0] - word[j]);
                       // Console.Write(a);
                        b = Math.Abs(keyboard[0] - word[j - 1]);
                        //Console.WriteLine(b);
                    }
                    else if((keyboard[0] - word[j])> 0 && (keyboard[0] - word[j - 1]) < 0)
                    {
                        a = 26 - (keyboard[0] - word[j]);
                        b = Math.Abs(keyboard[0] - word[j - 1]);
                    }
                    else if((keyboard[0] - word[j]) < 0 && (keyboard[0] - word[j - 1]) > 0)
                    {
                        a = Math.Abs(keyboard[0] - word[j]);
                        b = 26 - (keyboard[0] - word[j - 1]);
                    }
                    r = r + Math.Abs(a - b);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }
            return r;
        }



        public static int[,] FlipAndInvertImage(int[,] A)
        {
            int row = A.GetLength(0);
            int col = A.GetLength(1);
            int b, c, d;
            int[,] B = new int[row, col];
            try
            {             
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        b = A[i, j];
                        c = A[i, col - j - 1];
                        d = b;
                        b = 0;
                        b = c;
                        c = d;
                        B[i, j] = b;
                        if (B[i,j] == 0)
                            B[i,j] = 1;
                        else if (B[i, j] == 1)
                            B[i, j] = 0;                       
                    }                          
                }         
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }
            return B;
        }



        public static int MinMeetingRooms(int[,] intervals)

        {

            try

            {

                // Write your code here

            }

            catch

            {

                Console.WriteLine("Exception occured while computing MinMeetingRooms()");

            }



            return 0;

        }



        public static int[] SortedSquares(int[] A)

        {

            try

            {

                // Write your code here

            }

            catch

            {

                Console.WriteLine("Exception occured while computing SortedSquares()");

            }



            return new int[] { };

        }



        public static bool ValidPalindrome(string s)

        {

            try

            {

                // Write your code here

            }

            catch

            {

                Console.WriteLine("Exception occured while computing ValidPalindrome()");

            }



            return false;

        }

    }

}