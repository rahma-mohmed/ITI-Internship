using System.Security.Cryptography.X509Certificates;
using System.Collections;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
	public interface Interface1
	{

	}

	public class class1 : Interface1
	{

	}

	public class class2 : class1 
	{

	}

	public class Demo<T> where T : class1 , Interface1
	{
		public T V;
		public Demo(T x)
		{
			V = x;
		}

		public Demo()
		{

		}
	}

	public class Pair<T1 , T2>
	{
		public T1 x;
		public T2 y;

		public Pair(T1 a , T2 b)
		{
			x = a;
			y = b;
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			ArrayList arr = new ArrayList();
			arr.Add(10);
			arr.Add(20);
			arr.Add(30);
			//arr.Add(30);
			//arr.Add(30);
			Console.WriteLine(arr.Count);
			Console.WriteLine(arr.Capacity);

			string s = Console.ReadLine();
			try
			{
				//int x = int.Parse(s);
				//int y = 100 / x;
			}
			catch (DivideByZeroException e1)
			{
				Console.WriteLine("you cannot divide by zero");
			}

			catch (Exception ex)
			{
				//Console.WriteLine("Invalid Input");
				Console.WriteLine(ex.Message);
				//throw;
			}
			finally { 
				Console.WriteLine("End");
			}

			//try , catch , do while

			static void method2(int[] arr)
			{
				//? not null then return value
				//?? null
				// name ?? = "ali"
				//name = method() ?? "ali"

				Nullable<int> n = null;

				int? nn = null;

				string? st = null;
				

				if (nn.HasValue)
				{
                    Console.WriteLine(nn.Value);
                }

				int? x = arr?[0];
			}

			Collection x = new Collection();

			SortedList sl = new SortedList();
			sl.Add(20, "Ali");
			sl.Add(10, "Ahmed");


			foreach (DictionaryEntry pair in sl) {
				Console.WriteLine($"{pair.Key} : {pair.Value}");
			}



			Demo<class2> d = new Demo<class2>();

			/*
			 exception class
			1.message
			2.stackTrack 
			3.innerException
			 */
		}

		//collection
		//icollection add , remove, من الاول و الاخر
		//ilist من النصindex
		//idictionary  key , value

		//arrylist 
		//iconeable , ilist


		//sortedlist
		//iconeable , idictionary
		//key icomparable , icomparer

		//obj implement icomparable interface
		//او اباصي اوبجيكت بيامبلمينت

		//hash table not sorted list key , elemnt add - clear - contains key - remove - cout - item[key]
		//DictionaryEntry


		//Stack iconeable , icollections
		//Queue => enqueue , dequeue , peek , contains , ToArray

		public static void method()
		{
			throw new Exception("method");
		}
		//---------------------------------------------------------------
		//Generics
		static void Swap<T>(ref T x , ref T y)
		{
			T temp;
			temp = x;
			x = y;
			y = temp;
		}

		//--------------------------------------------------
		//Nullable

		//default<T>
	}
}
