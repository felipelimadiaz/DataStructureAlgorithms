using System;
using System.IO;
using System.Linq;

namespace DataStructureAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            int testCase = int.Parse(Console.In.ReadLine());
            for (int i = 0; i < testCase; i++)
            {
                int inputSizeArray = int.Parse(Console.In.ReadLine());
                int[] arr = new int[inputSizeArray];
                string[] inputLine = Console.In.ReadLine().Trim().Split(" ");
                for (int z = 0; z < inputSizeArray; z++)
                    arr[z] = int.Parse(inputLine[z]);

                int d = 1;
                int[] arrTested = arr;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    ArrayRotation newRotation = new ArrayRotation(arrTested, d);
                    arrTested = newRotation.RightRotateGCD();
                    int index = arrTested.Length - j - 1;
                    if (arrTested.Length - j - 1 < 0)
                        index = 0;

                    arrTested = newRotation.RemoveAt(index);
                }

                Console.WriteLine(arrTested[0].ToString());
            }
        }

    }
}
