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
            int[] arrRotated = this.arr;
            int gcd = Gcd(this.rotationQuantity, this.arr.Length);
            for (int i = 0; i < gcd; i++)
            {
                /* move i-th values of blocks */
                int temp = arr[i];
                int j = i;
                while (true)
                {
                    int k = j + this.rotationQuantity;
                    if (k >= arr.Length)
                        k = k - arr.Length;
                    if (k == i)
                        break;
                    arr[j] = arr[k];
                    j = k;
                }
                arr[j] = temp;
            }

            return arrRotated;
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
