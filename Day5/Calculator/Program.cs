namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Calculator----------------------------------------------------
            int c, d;
            Console.WriteLine("Enter the first operand: ");
            c = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second operand: ");
            d = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the operator:");
            char op = char.Parse(Console.ReadLine());

            if (op == '+')
            {
                Console.WriteLine("{0} {1} {2} = {3}", c, op, d, c + d);
            }
            else if (op == '-')
            {
                Console.WriteLine("{0} {1} {2} = {3}", c, op, d, c - d);
            }
            else if (op == '*')
            {
                Console.WriteLine("{0} {1} {2} = {3}", c, op, d, c * d);
            }
            else if (op == '/')
            {
                Console.WriteLine("{0} {1} {2} = {3}", c, op, d, c / d);
            }
            else if (op == '%')
            {
                Console.WriteLine("{0} {1} {2} = {3}", c, op, d, c % d);
            }
            else
            {
                Console.WriteLine("Invalid operator!!");
            }
        }
    }
}
