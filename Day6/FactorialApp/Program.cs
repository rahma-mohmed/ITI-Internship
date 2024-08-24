using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FactorialApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            long res = Factorial(num);
            Console.WriteLine($"factorial of {num} = {res}");
        }

        static long Factorial(int n)
        {
            if(n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n* Factorial(n-1);
            }
        }
    }
}
