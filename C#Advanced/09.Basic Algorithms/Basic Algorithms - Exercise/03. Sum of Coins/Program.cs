using System;

namespace _03._Sum_of_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 0, 0, 0 };
            ArrayManipulator(array,array.Length-1);
        }
        static void ArrayManipulator(int[] array,int index)
        {
            if(index == -1)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }
            for (int i = 0; i <= 9; i++)
            {
                array[index] = i;
                Console.WriteLine(string.Join(" ", array));
            }
            ArrayManipulator(array, index -1);
                        

        }
    }
}
