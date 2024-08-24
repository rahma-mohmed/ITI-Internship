namespace Simple_menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Simple menu---------------------------------------------------
            Console.WriteLine("calculate (1)sum - (2)min - (3)max");
            int q = int.Parse(Console.ReadLine());

            int xx, yy;
            Console.WriteLine("Enter the first number: ");
            xx = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            yy = int.Parse(Console.ReadLine());


            int min, max;
            if (xx < yy)
            {
                min = xx;
                max = yy;
            }
            else
            {
                min = yy;
                max = xx;
            }

            switch (q)
            {
                case 1:
                    Console.WriteLine(string.Format("{0} + {1} = {2}", xx, yy, xx + yy));
                break;

                case 2:
                    Console.WriteLine("minimum = {0}", min);
                break;
                    
                case 3:
                    Console.WriteLine("maximum = {0}", max);
                break;
            }
        }
    }
}
