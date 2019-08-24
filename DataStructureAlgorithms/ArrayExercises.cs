using System;

namespace DataStructureAlgorithms
{
    public class ArrayExercises
    {
        public static void Exercise1RotateAndDeleteArray()
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

        public static void Exercise2RotatingAnArray()
        {
            int testCase = int.Parse(Console.In.ReadLine());
            for (int i = 0; i < testCase; i++)
            {
                int inputSizeArray = int.Parse(Console.In.ReadLine());
                int[] arr = new int[inputSizeArray];
                string[] inputLine = Console.In.ReadLine().Trim().Split(" ");
                for (int z = 0; z < inputSizeArray; z++)
                    arr[z] = int.Parse(inputLine[z]);

                int d = int.Parse(Console.In.ReadLine());
                int[] arrTested = arr;
                ArrayRotation newRotation = new ArrayRotation(arr, d);
                arrTested = newRotation.leftRotate();


                Console.WriteLine("{0}", string.Join(" ", arrTested));
            }
        }

        public static void Exercise3Array()
        {
            int testCase = int.Parse(Console.In.ReadLine());
            for (int i = 0; i < testCase; i++)
            {
                string[] inputArray = Console.In.ReadLine().Trim().Split(" ");
                int[] arr = new int[int.Parse(inputArray[0])];
                int d = int.Parse(inputArray[1]);
                string[] inputLine = Console.In.ReadLine().Trim().Split(" ");
                for (int z = 0; z < int.Parse(inputArray[0]); z++)
                    arr[z] = int.Parse(inputLine[z]);

                int[] arrTested = arr;
                ArrayRotation newRotation = new ArrayRotation(arr, d);
                arrTested = newRotation.leftRotate();


                Console.WriteLine("{0}", string.Join(" ", arrTested));
            }
        }
    }
}
