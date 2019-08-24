using System;

namespace DataStructureAlgorithms
{
    public class ArrayRotation
    {
        private readonly int[] arr;
        private readonly int rotationQuantity;

        public ArrayRotation(int[] arr, int rotationQuantity)
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

        public int[] leftRotate()
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

    }
}
