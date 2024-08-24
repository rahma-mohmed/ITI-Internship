namespace Student_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of classrooms: ");
            int numberOfClassrooms = int.Parse(Console.ReadLine());

            int[][] classroom = new int[numberOfClassrooms][];

            for (int i = 0; i < numberOfClassrooms; i++) {

                Console.Write($"Enter the number of student in classroom {i+1}: ");
                int studentNum = int.Parse(Console.ReadLine());

                classroom[i] = new int[studentNum];

                Console.WriteLine($"classroom {i + 1}: ");
                for (int j = 0; j < studentNum; j++)
                {
                    Console.Write($"Enter the mark of student {j+ 1}: ");
                    classroom[i][j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("======================================================");
            }

            for (int i = 0; i < numberOfClassrooms; i++) {
                int s = 0;
                for (int j = 0; j < classroom[i].Length; j++) { 
                    s += classroom[i][j];
                }
                double avg = (double)s/(double)classroom[i].Length;
                Console.WriteLine($"Average mark for class room {i + 1} = {avg}");
            }
        }
    }
}
