using System;
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

            int target = 3;

            int[] nums = { 1, 3, 5, 6 };

            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));



            int[] nums1 = {1,2,2,3};

            int[] nums2 = {2,3,1,3,4};

            int[] intersect = Intersect(nums1, nums2);

            Console.Write("Intersection of two arrays is: ");

            DisplayArray(intersect);

            Console.WriteLine("\n");



            int[] A = { 1,8,1,5,3,3,6,6,6,9,7,7,10,10,10,11,12,12,12};
            //int[] A = {1,1,10,10,-1,-2,-2,0};

            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));



            string keyboard = "abcdefghijklmnopqrstuvwxyz";

            string word = "mds";

            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));



            int[,] image = { { 1, 1, 0 ,1,0}, { 1, 0, 1,1,0 }, { 0, 0, 0 ,1,1} };

            int[,] flipAndInvertedImage = FlipAndInvertImage(image);

            Console.WriteLine("The resulting flipped and inverted image is:\n");

            Display2DArray(flipAndInvertedImage);

            Console.Write("\n");



            int[,] intervals = {  { 5, 10 }, { 0, 30 }, { 15, 20 }, { 35, 50 }, { 14, 35 } };

            int minMeetingRooms = MinMeetingRooms(intervals);

            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);



            int[] arr = {-7,-3,2,3,11 };

            int[] sortedSquares = SortedSquares(arr);

            Console.Write("Squares of the array in sorted order is:");
            

            DisplayArray(sortedSquares);

            Console.WriteLine("\n");



            string s = "abcbea";

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
            
            try
            {
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
                        //Console.WriteLine("");
                        //Console.WriteLine(mid);
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
                    return low;
                }
                return low;
            }
            
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }
            return 0;

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
           
            try
            {
                int t = 0;
                int count = 1;
                Array.Sort(A);
                int i=A.Length-1;
                while (i>=1 && i < A.Length)
                {                   
                    if (A[i] == A[i - 1])
                    {
                        count++;
                        i--;
                    }
                    else if (count > 1)
                    {
                        count = 1;
                        i--;
                    }
                    else 
                    {
                        t = A[i];
                        break;
                    }
                }
                if(i==0 && count==1)
                {
                    t = A[i];
                }
                if(i==0 && count>1)
                {
                    t = -1;
                }
                return t;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }
           return new int { };
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

                Dictionary<char, int> Mydictionary = new Dictionary<char, int>();
                List<int> CommonKey = new List<int>();
                int i = 0;
                foreach (char l1 in keyboard)
                {
                    Mydictionary.Add(l1, i);
                    i++;

                }
                char start = keyboard[0];
                int x;
                int sum = 0;
                foreach (char l2 in word)
                {
                    x = Mydictionary[l2] - Mydictionary[start];
                    start = l2;
                    sum = sum + Math.Abs(x);
                }
                Console.WriteLine(sum);
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
            int row = intervals.GetLength(0);
            int col = intervals.GetLength(1);
            int n = 1;
            try
            {
                for(int i=0;i<row-1;i++)
                {
                    for (int j = 1; j < row; j++)
                    {
                        if(intervals[i,0]>intervals[j,0])
                        {
                            for(int k=0;k<col;k++)
                            {
                                var t = intervals[i, k];
                                intervals[i, k] = intervals[j, k];
                                intervals[j, k] = t;
                                Console.Write(" " + intervals[i, k]);
                            }
                        }
                    }
                }
                for(int i=0;i<row;i++)
                {
                    if (intervals[i, 1] > intervals[i + 1, 0])
                        n++;
                }
            }

            catch

            {

                Console.WriteLine("Exception occured while computing MinMeetingRooms()");

            }



            return n;

        }



        public static int[] SortedSquares(int[] A)

        {
            int[] B = new int[A.Length];
            try

            {

                for(int i=0;i<A.Length;i++)
                {
                    B[i] = Convert.ToInt32(Math.Pow(Convert.ToDouble(A[i]),Convert.ToDouble(2)));
                   
                }
                Array.Sort(B);               
            }
            catch
            {

                Console.WriteLine("Exception occured while computing SortedSquares()");

            }
            return B;
        }



        public static bool ValidPalindrome(string s)
        {
            try
            {
                int low = 0;
                int high = s.Length - 1;
                int count = 0;
                while(low<high)
                {
                    if(s[low]==s[high])
                    {                       
                        low++;
                        high--;
                    }
                    else
                    {
                        high--;
                        count++;
                        if (count > 1)
                            return false;
                    }
                }
            }
            catch
            {

                Console.WriteLine("Exception occured while computing ValidPalindrome()");

            }
            return true;

        }

    }

}