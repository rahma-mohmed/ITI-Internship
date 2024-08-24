namespace MenuAppUsingClass
{
    public class Employee
    {
        public string Name;
        public int Id;
        public decimal Salary;
        private static int _IdCount = 1;
        public readonly string Gender;

        public Employee()
        {
            Id = _IdCount++;
        }

        public Employee(string gender)
        {
            Id = _IdCount++;
            Gender = gender;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menu = { "  New  ", "Display", " Exit " };
            int width = Console.WindowWidth / 2;
            int height = Console.WindowHeight / 4;
            var x = 0;
            bool flag = true;

            Employee[] emp = new Employee[3];

            do
            {
                Console.Clear();
                Console.WriteLine("(--------------Menu App using Class--------------)");
                for (int i = 0; i < menu.Length; i++)
                {
                    if (i == x)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition(width, height * (i + 1));
                    Console.WriteLine(menu[i]);
                }

                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        x--;
                        if (x < 0)
                        {
                            x = menu.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        x++;
                        if (x > menu.Length - 1)
                        {
                            x = 0;
                        }
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (x)
                        {
                            case 0:
                                Console.WriteLine("New Employee:\n");
                                for (int i = 0; i < emp.Length; i++)
                                {
                                    Console.Write("Employee Name : ");
                                    string Name = Console.ReadLine();
                                    Console.Write("Employee Salary : ");
                                    decimal Salary = int.Parse(Console.ReadLine());
                                    Console.Write("Employee Gender : ");
                                    string Gender = Console.ReadLine();
                                    emp[i] = new Employee(Gender) { Name = Name ,Salary = Salary};
                                    Console.WriteLine("===================================================");
                                }
                                break;
                            case 1:
                                Console.WriteLine("Employee Data:\n");
                                for (int i = 0; i < emp.Length; i++)
                                {
                                    DisplayValues(emp[i]);
                                }
                                break;
                            case 2:
                                flag = false;
                                break;
                        }
                        break;

                    case ConsoleKey.Escape:
                        flag = false;
                        break;

                    case ConsoleKey.Home:
                        x = 0;
                        break;

                    case ConsoleKey.End:
                        x = menu.Length - 1;
                        break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            } while (flag);
        }

        static void DisplayValues(Employee e)
        {
            Console.WriteLine($"Employee Name : {e.Name}");
            Console.WriteLine($"Employee ID : {e.Id}");
            Console.WriteLine($"Employee Salary : {e.Salary}");
            Console.WriteLine($"Employee Gender : {e.Gender}");
            Console.ReadLine();
        }
    }
}
