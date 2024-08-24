namespace Magic_box
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Magic_box-----------------------------------------------------
            Console.Write("Enter the magic box size: ");
            int n = int.Parse(Console.ReadLine());


            int row, col, i;
            row = 1;
            col = 1;
            i = 1;

            int winShift = Console.WindowWidth / (n + 1);
            int winHeight = Console.WindowHeight / (n + 1);

            for (i = 1; i <= n * n; i++)
            {
                Console.SetCursorPosition(col * winShift, row * winHeight);
                Console.WriteLine(i);

                if (i % n == 0)
                {
                    row++;
                    if (row > n)
                    {
                        row = 1;
                    }
                }
                else
                {
                    row--;
                    col--;
                    if (row <= 0)
                    {
                        row = n;
                    }
                    if (col <= 0)
                    {
                        col = n;
                    }
                }
            }
        }
    }
}
