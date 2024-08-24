using System;

namespace Day6
{
    public class MyStack
    {
        int[] arr;
        int top;
        int size;

        public MyStack()
        {
            size = 3;
            arr = new int[size];
            top = 0;
        }

        public MyStack(int s)
        {
            size = s;
            arr = new int[s];
            top = 0;
        }

        public void Push(int x)
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

        public int Pop()
        {
            int val = -1;
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

        public int Peek()
        {
            int val = -1;
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

        public int Size
        {
            get { return size; }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < top)
                {
                    return arr[index];
                }
                return -1;
            }
        }

        public static MyStack operator +(MyStack left, MyStack right)
        {
            MyStack st = new MyStack(left.size + right.size);

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

        public static implicit operator int[](MyStack x)
        {
            int[] array = new int[x.top];
            for (int i = 0; i < x.top; i++)
            {
                array[i] = x.arr[i];
            }
            return array;
        }

        public static explicit operator MyStack(int[] array)
        {
            MyStack stack = new MyStack(array.Length);
            foreach (int item in array)
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
            MyStack s = new MyStack();
            s.Push(1);
            s.Push(2);
            s.Push(3);

            int[] arr1 = { 5, 6, 7 };

            MyStack s2 = (MyStack)arr1;
            Console.WriteLine($"Third element in Stack2 = {s2[2]}");

            int[] arr = s;

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }

            MyStack sk1 = new MyStack(3);
            sk1.Push(10);
            sk1.Push(20);
            sk1.Push(30);

            MyStack sk2 = new MyStack(2);
            sk2.Push(40);
            sk2.Push(50);


            MyStack s3 = sk1 + sk2;
            Console.WriteLine($"Size of combined stack: {s3.Size}");

            Console.WriteLine("Element in new stack after combination : ");
            int[] arr2 = s3;
            foreach (int item in arr2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
