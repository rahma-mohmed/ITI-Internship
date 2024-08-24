namespace ComplexApp
{
    struct Complex
    {
        public float real;
        public float imaginary;

        public Complex(float x, float y)
        {
            real = x;
            imaginary = y;
        }

        public string Display()
        {
            return $"{real} + {imaginary}i";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(5.0f, 4.0f);
            Complex c2 = new Complex(1.0f, 2.0f);

            Complex c3 = AddComplex(c1, c2);
            Complex c4 = SubtractComplex(c1, c2);

            Console.WriteLine($"Complex number 1: {c1.Display()}");
            Console.WriteLine($"Complex number 2: {c2.Display()}");
            
            Console.WriteLine($"\nAdding result = {c3.Display()}");
            Console.WriteLine($"Subtracting result = {c4.Display()}");
        }

        static Complex AddComplex(Complex x, Complex y)
        {
            Complex res;
            res.real = x.real + y.real;
            res.imaginary = x.imaginary + y.imaginary;
            return res;
        }

        static Complex SubtractComplex(Complex x, Complex y)
        {
            Complex res;
            res.real = x.real - y.real;
            res.imaginary = x.imaginary - y.imaginary;
            return res;
        }

    }
}
