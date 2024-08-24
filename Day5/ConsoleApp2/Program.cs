namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //get sum and average------------------------------------------
            double x, y;
            Console.WriteLine("Enter the first number: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Format("Summation = {0}", x + y));
            Console.WriteLine(string.Format("Average = {0}", (x + y) / 2.0));

        }
    }
}
