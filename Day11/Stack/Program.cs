using System;

namespace Day6
{
	public interface GenericInterface<T>
	{
		public T GetByIndex(MyStack<T> st, int index);
	}

	public class MyStack<T> : GenericInterface<T>
	{
		T[] arr;
		int top;
		int size;

		public MyStack()
		{
			size = 3;
			arr = new T[size];
			top = 0;
		}

		public MyStack(int s)
		{
			size = s;
			arr = new T[s];
			top = 0;
		}

		public void Push(T x)
		{
			if (top < size)
			{
				arr[top] = x;
				top++;
			}
			else
			{
				Console.WriteLine("Stack is full!!");
			}
		}

		public T Pop()
		{
			T val = default(T);
			if (top > 0)
			{
				top--;
				val = arr[top];
			}
			else
			{
				Console.WriteLine("Stack is Empty!!");
			}
			return val;
		}

		public T Peek()
		{
			T val = default(T);
			if (top > 0)
			{
				val = arr[top - 1];
			}
			else
			{
				Console.WriteLine("Stack is Empty!!");
			}
			return val;
		}

		//------------------------------------------------
		public T GetByIndex(MyStack<T> st,  int index) 
		{
			return st[index];
		}
		//--------------------------------------------------

		public int Size
		{
			get { return size; }
		}

		public T this[int index]
		{
			get
			{
				if (index >= 0 && index < top)
				{
					return arr[index];
				}
				return default(T);
			}
		}

		public static MyStack<T> operator +(MyStack<T> left, MyStack<T> right)
		{
			MyStack<T> st = new MyStack<T>(left.size + right.size);

			for (int i = 0; i < left.top; i++)
			{
				st.Push(left.arr[i]);
			}

			for (int i = 0; i < right.top; i++)
			{
				st.Push(right.arr[i]);
			}

			return st;
		}

		public static implicit operator T[](MyStack<T> x)
		{
			T[] array = new T[x.top];
			for (int i = 0; i < x.top; i++)
			{
				array[i] = x.arr[i];
			}
			return array;
		}

		public static explicit operator MyStack<T>(T[] array)
		{
			MyStack<T> stack = new MyStack<T>(array.Length);
			foreach (T item in array)
			{
				stack.Push(item);
			}
			return stack;
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			MyStack<int> s = new MyStack<int>();
			s.Push(1);
			s.Push(2);
			s.Push(3);

			Console.WriteLine($"second element in Stack = {s.GetByIndex(s , 1)}");

			/*int[] arr = s;

			foreach (int item in arr)
			{
				Console.WriteLine(item);
			}

			MyStack<int> sk1 = new MyStack<int>(3);
			sk1.Push(10);
			sk1.Push(20);
			sk1.Push(30);

			MyStack<int> sk2 = new MyStack<int>(2);
			sk2.Push(40);
			sk2.Push(50);


			MyStack<int> s3 = sk1 + sk2;
			Console.WriteLine($"Size of combined stack: {s3.Size}");

			Console.WriteLine("Element in new stack after combination : ");
			int[] arr2 = s3;
			foreach (int item in arr2)
			{
				Console.WriteLine(item);
			}*/
		}
	}
}

