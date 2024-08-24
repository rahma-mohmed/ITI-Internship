namespace _2DArray__degree_of__student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = 3;
            int subjects = 4;
            int[,] marks = new int[students, subjects];

            for (int i = 0; i < students; i++)
            {
                Console.WriteLine($"Enter marks for Student {i + 1}:");
                for (int j = 0; j < subjects; j++)
                {
                    Console.Write($"Subject {j + 1}: ");
                    marks[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("===========================================");
            for (int i = 0; i < students; i++)
            {
                int sum = 0;
                for (int j = 0; j < subjects; j++)
                {
                    sum += marks[i, j];
                }
                Console.WriteLine($"Sum of marks for Student {i + 1}: {sum}");
            }
            Console.WriteLine("===========================================");
            for (int j = 0; j < subjects; j++)
            {
                int sum = 0;
                for (int i = 0; i < students; i++)
                {
                    sum += marks[i, j];
                }
                double average = (double)sum / (double)students;
                Console.WriteLine($"Average marks for Subject {j + 1}: {average}");
            }

        }
    }
}
