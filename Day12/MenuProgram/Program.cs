namespace MenuProgram
{
    public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name} ";
        }
    }

    public class Employee : Human
    {
        public decimal Salary;

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name} , Salary: {Salary}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menu = { "  New  ", "Display", " Sort ", " Exit " };
            int width = Console.WindowWidth / 2;
            int height = Console.WindowHeight / 5;
            var x = 0;
            bool flag = true;

            //Task2
            List<Employee> emp = new List<Employee>();
            emp.Add(new Employee());
            emp.Add(new Employee());
            emp.Add(new Employee());

            do
            {
                Console.Clear();
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
                                for (int i = 0; i < emp.Count; i++)
                                {
                                    GetValues(emp[i]);
                                    Console.WriteLine("=======================================");
                                }
                                break;
                            case 1:
                                Console.WriteLine("Employee Data:\n");
                                for (int i = 0; i < emp.Count; i++)
                                {
                                    Console.WriteLine(emp[i]);
                                    Console.ReadLine();
                                }
                                break;
                            case 2:
                                //------------Sorting---------------
                                Console.Write("Sort by ID or Name or Salary ? ");
                                string inp = Console.ReadLine();

                                if (inp == "ID")
                                {
                                    Console.Write("Ascending or descending ? ");
                                    string inp2 = Console.ReadLine();
                                    Console.WriteLine();
                                    if (inp2 == "Ascending")
                                    {
                                        Console.WriteLine("Sort by ID Ascending: ");

                                        Comparison<Employee> IdAsc = delegate (Employee e1, Employee e2)
                                        {
                                            return e1.Id.CompareTo(e2.Id);
                                        };

                                        emp.Sort(IdAsc);
                                        PrintValue(emp);

                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort by ID Descending: ");

                                        Comparison<Employee> SortByIdDesc = delegate (Employee e1, Employee e2)
                                        {
                                            return -1 * e1.Id.CompareTo(e2.Id);
                                        };

                                        emp.Sort(SortByIdDesc);
                                        PrintValue(emp);
                                    }

                                }
                                else if (inp == "Name")
                                {
                                    Console.Write("Ascending or descending ? ");
                                    string inp2 = Console.ReadLine();
                                    Console.WriteLine();
                                    if (inp2 == "Ascending")
                                    {
                                        Console.WriteLine("Sort by Name Ascending: ");

                                        Comparison<Employee> SortByNameAsc = delegate (Employee e1, Employee e2)
                                        {
                                            return e1.Name.CompareTo(e2.Name);
                                        };

                                        emp.Sort(SortByNameAsc);
                                        PrintValue(emp);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort by Name Descending: ");

                                        Comparison<Employee> SortByNameDesc = delegate (Employee e1, Employee e2)
                                        {
                                            return -1 * e1.Name.CompareTo(e2.Name);
                                        };

                                        emp.Sort(SortByNameDesc);
                                        PrintValue(emp);
                                    }
                                }

                                if(inp == "Salary")
                                {
                                    Console.Write("Ascending or descending ? ");
                                    string inp2 = Console.ReadLine();
                                    Console.WriteLine();
                                    if (inp2 == "Ascending")
                                    {
                                        Console.WriteLine("Sort by Salary ame Ascending: ");

                                        Comparison<Employee> SortBySalaryAsc = delegate (Employee e1, Employee e2)
                                        {
                                            return e1.Salary.CompareTo(e2.Salary);
                                        };

                                        emp.Sort(SortBySalaryAsc);
                                        PrintValue(emp);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort by Salary Descending: ");

                                        Comparison<Employee> SortByNameDesc = delegate (Employee e1, Employee e2)
                                        {
                                            return -1 * e1.Salary.CompareTo(e2.Salary);
                                        };
                                        emp.Sort(SortByNameDesc);

                                        PrintValue(emp);
                                    }
                                }

                                break;

                            case 3:
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

        static void PrintValue(List<Employee> emp)
        {
            for (int i = 0; i < emp.Count; i++)
            {
                Console.WriteLine(emp[i]);
            }
            Console.ReadLine();
        }

        static void GetValues(Employee e)
        {
            bool Check = false;

            do
            {
                try
                {
                    Console.Write("Employee Name: ");
                    e.Name = Console.ReadLine();

                    if (e.Name == "")
                    {
                        throw new Exception("Invalid input: Name cannot be empty.");
                    }

                    Console.Write("Employee ID: ");
                    string Id = Console.ReadLine();
                    if (Id == "")
                    {
                        throw new Exception("Invalid input: ID cannot be empty.");
                    }
                    e.Id = int.Parse(Id);

                    Console.Write("Employee Salary: ");
                    e.Salary = decimal.Parse(Console.ReadLine());

                    Check = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid integer for the ID.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!Check);
        }
    }
}
