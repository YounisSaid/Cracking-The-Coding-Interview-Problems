using System;
using System.Globalization;
using System.Xml.Linq;

namespace Binary_Search
{
    internal class Program
    {
      static int BinarySearch(int [] arr, int Left, int Right,int x)
        {
            int mid = (Left + Right) / 2;
            if(x == arr[mid]) return mid; //Element Found At mid

            if (Left > Right) return -1;

            // Left Ordered Normally
            if (arr[Left] < arr[mid])
            {
                if(x >= arr[Left]&&x < arr[mid])
                    return BinarySearch( arr ,Left ,mid - 1 ,x); // Search Left
                else return BinarySearch(arr, mid + 1, Right, x); // Search Right
            }


            // Right Ordered Normally
            else if (arr[Right] > arr[mid])
            {
                if (x <= arr[Right] && x > arr[mid])
                    return BinarySearch(arr, mid + 1, Right, x); // Search Right
                else return BinarySearch(arr, Left, mid - 1, x); // Search Left
            }

            // There are Duplicates
            else if (arr[Left] == arr[mid])
            {
                if(arr[Right] != arr[mid]) return BinarySearch(arr, mid + 1, Right, x); // Search Right
                else
                {
                    int Result = BinarySearch(arr, Left, mid - 1, x); // Search Left
                    if(Result == -1) return BinarySearch(arr, mid + 1, Right, x); // Search Right
                    else return Result;
                }
            }

            return -1;

        }
        static void Main(string[] args)
        {
            //10.3 * *Search in Rotated Array**: Given a sorted array of n integers that has been rotated an unknown number of times, write code to find an element in the array. You may assume that the array was originally sorted in increasing order.

            //EXAMPLE
            //Input: find 5 in { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14}
            //Output: 8(the index of 5 in the array)

            int [] arr = { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
            int index = BinarySearch(arr, 0, arr.Length - 1, 5); // Search for 5
            if (index == -1) Console.WriteLine("Element is not Found");
            else Console.WriteLine($"Element {arr[index]} is found at index {index}");
        }
    }
}
