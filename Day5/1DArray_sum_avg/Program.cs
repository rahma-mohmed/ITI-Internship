namespace _1DArray_sum_avg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sum, Average, Max, Min of user-provided integers

            Console.Write("Enter the number of integers: ");

            int count = int.Parse(Console.ReadLine());
            int[] numbers = new int[count];

            for(int i = 0;  i < count; i++)
            {
                Console.Write(string.Format("Enter integer {0}: ",i+1));
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();
            int min = numbers.Min();

            Console.WriteLine();
            Console.WriteLine($"Sum of integers: {sum}");
            Console.WriteLine($"Average of integers: {average}");
            Console.WriteLine($"Maximum: {max}");
            Console.WriteLine($"Minimum: {min}");
        }
    }
}
