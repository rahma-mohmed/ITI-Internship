namespace BubbleSort
{
    public delegate bool Del(int a, int b);

    internal class Program
    {
        public static void Swap(ref int a, ref int b)
        { 
            int temp = a; a = b; b = temp;
        }

        public static void BubbleSort(int[] arr , Del D)
        {
            for (int i = 0; i < arr.Length; i++) { 
                for(int j = 0; j < arr.Length-1-i; j++)
                {
                    if (D(arr[j] , arr[j+1]))
                    {
                        Swap(ref arr[j] , ref arr[j+1]);
                    }
                }
            }
        }

        public static bool SortAscending(int a , int b)
        {
            return a > b;
        }

        public static bool SortDescending(int a, int b)
        {
            return a < b;
        }

        static void Main(string[] args)
        {
            Del D1 = SortAscending;

            int[]arr = {5,2,1,6,8,3,4};

            BubbleSort(arr, D1);

            Console.WriteLine("-Array Sorting in Ascending Order :");
 
            foreach (int a in arr) Console.Write($"{a} ");

            Console.WriteLine();
            Console.WriteLine("------------------------------------");

            Del D2 = SortDescending;

            BubbleSort(arr, D2);

            Console.WriteLine("-Array Sorting in Descinding Order :");

            foreach (int a in arr) Console.Write($"{a} ");
        }
    }
}
