namespace ConsoleApp1
{

    public class c1
    {
        int x;
    }
    public class c2 : c1
    {
        int z;
    }

    public delegate int del(int x , int y);

    public delegate c1 del2();

    public delegate T del3<out T>();

    public delegate void del4<in T>(T item);

    class Class1
    {
        public event del2 D;
        public void method()
        {
            D();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 e = new Class1();
            e.D += method1;
            e.D += method3;
            e.method();

            Func<int, int, int> A = sum;
            Console.WriteLine(A(1, 2));

            del D = sum;
            Console.WriteLine(D(10, 20));

            del2 D2 = method1;

            del3<c1> D3;
            D3 = method1;
            c1 x = D3();

            D3 = method3;

            del3<c1> D4 = method1;
            c1 x2 = D4();
            //c2 y2 = D4();

        }

        static int sum(int x , int y)
        {
            return x + y;
        }

        static c1 method1()
        {
            Console.WriteLine("m1");
            return new c1();
        }

        static c2 method3()
        {
            Console.WriteLine("m2");
            return new c2();
        }

    }
}
