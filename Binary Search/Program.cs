using System.Globalization;

namespace Binary_Search
{
    internal class Program
    {
      static int RotatedBinarySearch(int [] arr, int Left, int Right,int x)
        {
            int mid = (Left + Right) / 2;
            if(x == arr[mid]) return mid; //Element Found At mid

            if (Left > Right) return -1;

            // Left Ordered Normally
            if (arr[Left] < arr[mid])
            {
                if(x >= arr[Left]&&x < arr[mid])
                    return RotatedBinarySearch( arr ,Left ,mid - 1 ,x); // Search Left
                else return RotatedBinarySearch(arr, mid + 1, Right, x); // Search Right
            }


            // Right Ordered Normally
            else if (arr[Right] > arr[mid])
            {
                if (x <= arr[Right] && x > arr[mid])
                    return RotatedBinarySearch(arr, mid + 1, Right, x); // Search Right
                else return RotatedBinarySearch(arr, Left, mid - 1, x); // Search Left
            }

            // There are Duplicates
            else if (arr[Left] == arr[mid])
            {
                if(arr[Right] != arr[mid]) return RotatedBinarySearch(arr, mid + 1, Right, x); // Search Right
                else
                {
                    int Result = RotatedBinarySearch(arr, Left, mid - 1, x); // Search Left
                    if(Result == -1) return RotatedBinarySearch(arr, mid + 1, Right, x); // Search Right
                    else return Result;
                }
            }

            return -1;

        }
        static int BinarySearch(List<int> list, int Value,int Left,int Right)
        {
            int mid ;
            while(Right>=Left)
            {
                mid = (Right + Left) / 2;
                if (list[mid] > Value || list[mid] == -1)
                {

                   return BinarySearch(list, Value, Left, mid - 1); //Search Left
                } 
                else if(list[mid] < Value) return BinarySearch(list, Value, mid+1,Right);//Search Right
                else return mid;
            }
            return -1;
        }

        static int BinarySearch(List<int> list,int Value)
        {
            int i = 1;
            while (list[i]!=-1 && list[i]<Value) i *= 2;

            return BinarySearch(list, Value,i/2,i);


        }

        static int Search(string [] strings, string str,int Low,int High) 
        {
            int mid = (High + Low) / 2;
            if (Low > High) return -1;

            //If mid is Empty We to find the closest Not Empty Place
            if (string.IsNullOrEmpty(strings[mid]))
            {
                int Left = mid - 1;
                int Right = mid + 1;
                while(true)
                {
                    //Out of Range
                    if (Left < Low && Right > High) return -1;
                    //Left is not Empty
                    else if (Left >= Low && !string.IsNullOrEmpty(strings[Left]))
                    {
                        mid = Left;
                        break;
                    }
                    //Right is not Empty
                    else if (Right <= High && !string.IsNullOrEmpty(strings[Right]))
                    {
                        mid = Right;
                        break; 
                    }
                    Right++;
                    Left--;

                }
            }

            //Now we need To Compare elements
            if (strings[mid].Equals(str)) return mid;
            else if (strings[mid].CompareTo(str) < 0) return Search(strings, str,mid+1,High); //Search Right
            else return Search(strings, str,Low, mid - 1); //Search Left
        }

        static int BinarySearch(string [] strings,string str)
        {
            if (string.IsNullOrEmpty(str) || strings == null) return -1;
            else return Search(strings, str, 0, strings.Length - 1);
        }
        static void Main(string[] args)
        {
            //10.3 * *Search in Rotated Array**: Given a sorted array of n integers that has been rotated an unknown number of times, write code to find an element in the array. You may assume that the array was originally sorted in increasing order.

            //EXAMPLE
            //Input: find 5 in { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14}
            //Output: 8(the index of 5 in the array)

            int [] arr = { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
            int index = RotatedBinarySearch(arr, 0, arr.Length - 1, 5); // Search for 5
            if (index == -1) Console.WriteLine("Element is not Found");
            else Console.WriteLine($"Element {arr[index]} is found at index {index}");

            //10.4 Sorted Search, No Size: You are given an array - like data structure Listy which lacks a size()
            //    method.It does, however, have an elementAt(i) method that returns the element at index i in O(1) time.
            //    If i is beyond the bounds of the data structure, it returns -1. (For this reason, the data structure only supports positive integers.) Given a Listy which contains sorted,
            //    positive integers, find the index at which an element X occurs.If X occurs multiple times, you may return any index.
            List<int> sortedList = new List<int> { 1, 3, 4, 5, 7, 10, 14, 15, 16, 19, 20, 25 };
            int valueToFind1 = 5;
            int index1 = BinarySearch(sortedList, valueToFind1);
            Console.WriteLine($"Searching for {valueToFind1}: Index = {index1} (Expected: 3)"); // 5 is at index 3

            int valueToFind3 = 2; // Not in the list
            int index2 = BinarySearch(sortedList, valueToFind3);
            Console.WriteLine($"Searching for {valueToFind3}: Index = {index2} (Expected: -1)");

            //10.5 Sparse Search: Given a sorted array of strings that is interspersed with empty strings, write a method to find the location of a given string.
            //  EXAMPLE
            //  Input: ball, { "at", "", "", "", "ball", "", "", "car", "", "", "dad", ""}
            //          Output: 4
            string[] sparseArray = { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "" };
            string target = "ball";
            int index3 = BinarySearch(sparseArray, target);
            Console.WriteLine($"Searching for {target}: Index = {index3} (Expected: 4)"); 

        }
    }
}
