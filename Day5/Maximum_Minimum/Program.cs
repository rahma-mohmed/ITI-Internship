namespace Maximum_Minimum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //get maximum and minimum--------------------------------------
            int a, b;
            Console.WriteLine("Enter the first number: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            b = int.Parse(Console.ReadLine());

            int mx, mn;
            if (a > b)
            {
                mx = a;
                mn = b;
            }
            else
            {
                mx = b;
                mn = a;
            }
            Console.WriteLine("Maximum :{0}", mx);
            Console.WriteLine("Minimum :{0}", mn);
        }
    }
}
