using EmployeeClassLibrary;
namespace MenuAppV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menu = { "  New  ", "Display", " Exit " };
            int width = Console.WindowWidth / 2;
            int height = Console.WindowHeight / 4;
            var x = 0;
            bool flag = true;

            Employee emp = new Employee();

            do
            {
                Console.Clear();
                Console.WriteLine("(--------------Menu App using Class Library--------------)");
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
                                GetValues(emp);
                                 break;
                            case 1:
                                Console.WriteLine("Employee Data:\n");
                                DisplayValues(emp);
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

        static void GetValues(Employee e)
        {
            Console.Write("Employee Name : ");
            e.Name = Console.ReadLine();
            Console.Write("Employee ID : ");
            e.Id = int.Parse(Console.ReadLine());
            Console.Write("Employee Salary : ");
            e.Salary = int.Parse(Console.ReadLine());
        }

        static void DisplayValues(Employee e)
        {
            Console.WriteLine($"Employee Name : {e.Name}");
            Console.WriteLine($"Employee ID : {e.Id}");
            Console.WriteLine($"Employee Salary : {e.Salary}");
            Console.ReadLine();
        }
    }
}
