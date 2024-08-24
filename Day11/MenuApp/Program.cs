using System;
using System.Collections;

namespace MenuApp
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

    public class Employee : Human , IComparable
    {
        public int CompareTo(object? obj)
        {
            Employee emp = obj as Employee;
            return this.Id.CompareTo(emp.Id);
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }

    //sorting by Name
    class SortByNameDesc<T> : IComparer<T> where T : Employee
    {
        public int Compare(T? x, T? y)
        {
            Employee emp1 = x as Employee;
            Employee emp2 = y as Employee;

            return -1*emp1.Name.CompareTo(emp2.Name);
        }
    }

    class SortByNameAsc<T> : IComparer<T> where T : Employee
    {
        public int Compare(T? x, T? y)
        {
            Employee emp1 = x as Employee;
            Employee emp2 = y as Employee;

            return emp1.Name.CompareTo(emp2.Name);
        }
    }

    //sorting by Id
    class SortByIdDesc<T> : IComparer<T> where T : Employee
	{
		public int Compare(T? x, T? y)
		{
			return -1 * x.Id.CompareTo(y.Id);
		}
	}

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menu = { "  New  ", "Display"," Sort "," Exit " };
            int width = Console.WindowWidth / 2;
            int height = Console.WindowHeight / 5;
            var x = 0;
            bool flag = true;

            //Task2
            List<Employee> emp = new List<Employee>();
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
                                Console.Write("Sort by ID or Name ? ");
                                string inp = Console.ReadLine();

                                if (inp == "ID")
                                {
                                    Console.Write("Ascending or descending ? ");
                                    string inp2 = Console.ReadLine();
                                    Console.WriteLine();
                                    if (inp2 == "Ascending")
                                    {
                                        Console.WriteLine("Sort by ID Ascending: ");
										emp.Sort();
										PrintValue(emp);
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort by ID Descending: ");
                                        emp.Sort(new SortByIdDesc<Employee>());
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
                                        emp.Sort(new SortByNameAsc<Employee>());
                                        PrintValue(emp);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort by Name Descending: ");
                                        emp.Sort(new SortByNameAsc<Employee>());
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
