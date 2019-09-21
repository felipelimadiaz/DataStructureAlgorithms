using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructureAlgorithms
{
    public class ArrayProperties
    {
        private readonly int[] arr;
        private readonly int rotationQuantity;

        public ArrayProperties(int[] arr, int rotationQuantity)
        {
            this.arr = arr;
            this.rotationQuantity = rotationQuantity;
        }

        private int Gcd(int a, int b)
        {
            if (b == 0)
                return a;

            else
                return Gcd(b, a % b);
        }

        public int[] leftRotateWithReverse()
        {
            int n = this.arr.Length;
            ReverseArray(0, this.rotationQuantity - 1);
            ReverseArray(this.rotationQuantity, n - 1);
            ReverseArray(0, n - 1);

            return this.arr;
        }


        public int[] RightRotateGCD()
        {
            int[] arrRotated = this.arr;
            if (this.arr.Length <= 1)
            {
                return arrRotated;
            }
            int gcd = Gcd(this.rotationQuantity, arrRotated.Length);
            int position;
            for (int i = 0; i < gcd; i++)
            {
                position = i;
                int count = arrRotated.Length / gcd - 1;
                for (int j = 0; j < count; j++)
                {
                    position = (position + this.rotationQuantity) % this.arr.Length;
                    arrRotated[i] ^= arrRotated[position];
                    arrRotated[position] ^= arrRotated[i];
                    arrRotated[i] ^= arrRotated[position];
                }
            }

            return arrRotated;
        }

        public void ReverseArray(int start, int end)
        {
            int temporary;
            while (start < end)
            {
                temporary = this.arr[start];
                this.arr[start] = this.arr[end];
                this.arr[end] = temporary;
                start++;
                end--;
            }

        }

        public int[] RemoveAt(int index)
        {
            int[] reducedArray = new int[this.arr.Length - 1];
            int i = 0; 
            int j = 0;
            while (i < this.arr.Length)
            {
                if (i != index)
                {
                    reducedArray[j] = this.arr[i];
                    j++;
                }

                i++;
            }

            return reducedArray;
        }

        public int[] FindLeaders()
        {
            List<int> leadersElement = new List<int>();
            int currMax = this.arr[this.arr.Length - 1];
            leadersElement.Add(this.arr[this.arr.Length - 1]);
            for (int i = this.arr.Length - 2; i >= 0; i--)
            {
                if (this.arr[i] >= currMax)
                {
                    leadersElement.Add(this.arr[i]);
                    currMax = this.arr[i];
                }
                    
            }

            return leadersElement.ToArray();
        }

        public int Max()
        {
            int max = this.arr[0];
            for (int i = 1; i < this.arr.Length; i++)
            {
                if (max < this.arr[i])
                    max = this.arr[i];
            }

            return max;
        }

        public int FindPivot(int low, int high)
        {
            if (low > high)
                return -1;

            if (high == low)
                return low;

            int mid = (low + high) / 2;

            if (mid < high && this.arr[mid] > this.arr[mid + 1])
                return mid;

            if (mid > low && this.arr[mid] < this.arr[mid - 1])
                return mid - 1;

            if (this.arr[low] >= this.arr[mid])
                return FindPivot(low, mid - 1);

            return FindPivot(mid + 1, high);
        }

        public int SearchElementInPivotedSortedArray(int low, int high, int key)
        {
            if (low > high)
                return -1;

            int mid = (low + high) / 2;

            if (this.arr[mid] == key)
                return mid;

            if (this.arr[low] <= this.arr[mid])
            {
                if (this.arr[low] <= key && this.arr[mid] >= key)
                {
                    return SearchElement(low, mid - 1, key);
                }
                else
                {
                    return SearchElement(mid + 1, high, key);
                }
            }
            else
            {
                if (this.arr[mid] <= key && this.arr[high] >= key)
                {
                    return SearchElement(mid + 1, high, key);
                }
                else
                {
                    return SearchElement(low, mid - 1, key);
                }
            }
        }

        public int BinarySearch(int low, int high, int key)
        {
            if (high < low)
                return -1;

            int mid = (low + high) / 2;
            if (key == this.arr[mid])
                return mid;
            if (key > this.arr[mid])
                return BinarySearch(mid + 1,high,key);

            return BinarySearch(0, mid - 1, key);
        }

        public int FindElementInSortedArray(int key)
        {
            int pivot = this.FindPivot(0, this.arr.Length -1);

            if (this.arr[pivot] == key)
                return pivot;

            if (this.arr[0] < key)
                this.BinarySearch(0, pivot - 1, key);

            return BinarySearch(pivot + 1, this.arr.Length - 1, key);
        }

    }
}
