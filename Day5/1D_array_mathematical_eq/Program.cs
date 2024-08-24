namespace _1D_array_mathematical_eq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Calculate the result of a mathematical operation

            Console.WriteLine("Enter a mathematical operation: ");
            string operation = Console.ReadLine();

            if (operation.Contains('*'))
            {
                string[] p = operation.Split('*');
                int n1 = int.Parse(p[0]);
                int n2 = int.Parse(p[1]);
                Console.WriteLine(string.Format("{0} * {1} = {2}", n1, n2, n1 * n2));
            }
            else if (operation.Contains("+"))
            {
                string[] p = operation.Split("+");
                int n1 = int.Parse(p[0]);
                int n2 = int.Parse(p[1]);
                Console.WriteLine(string.Format("{0} + {1} = {2}", n1, n2, n1 + n2));
            }
            else if (operation.Contains("-"))
            {
                string[] p = operation.Split("-");
                int n1 = int.Parse(p[0]);
                int n2 = int.Parse(p[1]);
                Console.WriteLine(string.Format("{0} - {1} = {2}", n1, n2, n1 - n2));
            }
            else if (operation.Contains("/"))
            {
                string[] p = operation.Split("/");
                int n1 = int.Parse(p[0]);
                int n2 = int.Parse(p[1]);
                Console.WriteLine(string.Format("{0} / {1} = {2}", n1, n2, n1 / n2));
            }
        }
    }
}
