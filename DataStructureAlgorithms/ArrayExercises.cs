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
                    ArrayProperties arrayProperties = new ArrayProperties(arrTested, d);
                    arrTested = arrayProperties.RightRotateGCD();
                    int index = arrTested.Length - j - 1;
                    if (arrTested.Length - j - 1 < 0)
                        index = 0;

                    arrTested = arrayProperties.RemoveAt(index);
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
                ArrayProperties arrayProperties = new ArrayProperties(arr, d);
                arrTested = arrayProperties.leftRotateWithReverse();


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
                ArrayProperties arrayProperties = new ArrayProperties(arr, d);
                arrTested = arrayProperties.leftRotateWithReverse();


                Console.WriteLine("{0}", string.Join(" ", arrTested));
            }
        }

        public static void Exercise4ArrayLeader()
        {
            int testCase = int.Parse(Console.In.ReadLine());
            for (int i = 0; i < testCase; i++)
            {
                int inputSizeArray = int.Parse(Console.In.ReadLine());
                int[] arr = new int[inputSizeArray];
                string[] inputArray = Console.In.ReadLine().Trim().Split(" ");
                for (int j = 0; j < inputSizeArray; j++)
                    arr[j] = int.Parse(inputArray[j]);

                int[] arrTested = arr;
                ArrayProperties arrayProperties = new ArrayProperties(arr, 1);
                arrTested = arrayProperties.FindLeaders();

                int[] reversedArray = new int[arrTested.Length];
                int count = 0;
                for (int j = arrTested.Length - 1; j >= 0; j--)
                {
                    reversedArray[count] = arrTested[j];
                    count++;
                }

                Console.WriteLine("{0}", string.Join(" ", reversedArray));
            }
            
        }


        public static void Exercise5SearchInaRotatedArray()
        {
            int testCase = int.Parse(Console.In.ReadLine());
            for (int i = 0; i < testCase; i++)
            {
                int inputSizeArray = int.Parse(Console.In.ReadLine());
                int[] arr = new int[inputSizeArray];
                string[] inputArray = Console.In.ReadLine().Trim().Split(' ');
                for (int j = 0; j < inputSizeArray; j++)
                    arr[j] = int.Parse(inputArray[j]);

                int elementToBeSearched = int.Parse(Console.In.ReadLine());
                ArrayProperties arrProperties = new ArrayProperties(arr, 0);

                int discoveredElement = arrProperties.SearchElementInPivotedSortedArray(0, arr.Length - 1, elementToBeSearched);

                Console.WriteLine("{0}", discoveredElement);
            }
        }

    }
}
