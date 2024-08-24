namespace GeoShapApp
{
    class GeoShape
    {
        protected int d1;
        protected int d2;

        public GeoShape()
        {
            d1 = d2 = 1;
        }

        public GeoShape(int x)
        {
            d1 = d2 = x;
        }

        public GeoShape(int x , int y)
        {
            d1 = x;
            d2 = y;
        }

        public virtual float area()
        {
            return 0;
        }
    }

    class Circle : GeoShape
    {
        public Circle() { }

        public Circle(int r) : base(r)
        {
            
        }

        public int _r
        {
            set
            {
                d1 = d2 = value;
            }

            get
            {
                return d1;
            }
        }

        public override float area()
        {
            return 3.14f * _r * _r;
        }
    }

    class Rectangle : GeoShape
    {
        public Rectangle() { }

        public Rectangle(int w, int h) : base(w, h)
        {

        }

        public int _w
        {
            set
            {
                d1 = value;
            }

            get
            {
                return d1;
            }
        }

        public int _h
        {
            set
            {
                d2 = value;
            }

            get
            {
                return d2;
            }
        }

        public override float area()
        {
            return _h * _w;
        }
    }

    class Triangle : GeoShape
    {
        public Triangle() { }

        public Triangle(int b , int h) : base(b , h)
        {
            
        }

        public int _b
        {
            set
            {
                d1 = value;
            }

            get
            {
                return d1;
            }
        }

        public int _h
        {
            set
            {
                d2 = value;
            }

            get
            {
                return d2;
            }
        }

        public override float area()
        {
            return 0.5f * _h * _b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Rectangle area: ");
            Rectangle rec = new Rectangle(4 , 3);
            Console.WriteLine(rec.area());

            Console.Write("Triangle area: ");
            Triangle tr = new Triangle(3 , 4);
            Console.WriteLine(tr.area());

            Console.Write("Circle area: ");
            Circle circle = new Circle(2);
            Console.WriteLine(circle.area());

            float s = 0.0f;

            GeoShape[] shapes = new GeoShape[] { rec , tr, circle };

            for (int i = 0; i < shapes.Length; i++) { 
                s += shapes[i].area();
            }

            Console.WriteLine($"Areas Summation : {s}");
        }
    }
}
