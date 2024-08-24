using System.Security.Cryptography.X509Certificates;

namespace Stack
{
    public class MyStack
    {
        int[] arr;
        int top;
        int size;

        public MyStack()
        {
            size = 4;
            arr = new int[4];
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
                val = arr[top-1];
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
            MyStack st = new MyStack();
            for(int i = 0; i < left.Size; i++)
            {
                int x = left.Peek();
                st.Push(x);
            }
            for (int i = 0; i < right.Size; i++)
            {
                int x = right.Peek();
                st.Pop();
                st.Push(x);
            }
            return st;
        }

        public static implicit operator int[](MyStack x)
        {
            int[] array = new int[x.top];
            for (int i = 0; i < x.Size; i++)
            {
                int val = x.Peek();
                array[i] = val;
                x.Pop();
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
            s.Push(4);

            int[] arr = s;

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }

            int[] arr1 = { 5, 6, 7, 8 };
            MyStack s2 = new MyStack();

            s2 = (MyStack)arr1;

            Console.WriteLine($"third elemnt in Stack2 = {s2[2]}");
        }
    }
}
