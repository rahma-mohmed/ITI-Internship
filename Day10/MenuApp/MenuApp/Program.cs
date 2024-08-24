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
    class SortByNameDesc : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Employee emp1 = x as Employee;
            Employee emp2 = y as Employee;

            return -1*emp1.Name.CompareTo(emp2.Name);
        }
    }

    class SortByNameAsc : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Employee emp1 = x as Employee;
            Employee emp2 = y as Employee;

            return emp1.Name.CompareTo(emp2.Name);
        }
    }

    //sorting by Id
    class SortByIdDesc : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Employee emp1 = x as Employee;
            Employee emp2 = y as Employee;

            return -1*emp1.Id.CompareTo(emp2.Id);
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

            Employee[] emp =
            {
                new Employee(),
                new Employee(),
                new Employee()
            };

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
                                for (int i = 0; i < emp.Length; i++)
                                {
                                    GetValues(emp[i]);
                                    Console.WriteLine("=======================================");
                                }
                                break;
                            case 1:
                                Console.WriteLine("Employee Data:\n");
                                for (int i = 0; i < emp.Length; i++)
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
                                        Array.Sort(emp);
                                        PrintValue(emp);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort by ID Descending: ");
                                        Array.Sort(emp, new SortByIdDesc());
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
                                        Array.Sort(emp, new SortByNameAsc());
                                        PrintValue(emp);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sort by Name Descending: ");
                                        Array.Sort(emp, new SortByNameDesc());
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

        static void PrintValue(Employee[] emp)
        {
            for (int i = 0; i < emp.Length; i++)
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
					if (e.Name == null)
					{
						throw new Exception("Name cannot be empty.");
					}

					Console.Write("Employee ID: ");
					e.Id = int.Parse(Console.ReadLine());

					Check = true;
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input. Please enter a valid integer for the ID.");
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine($"Invalid input: {ex.Message}");
				}
                catch(Exception ex)
                {
					Console.WriteLine(ex.Message);
				}
			} while (!Check);
		}
    }
}
