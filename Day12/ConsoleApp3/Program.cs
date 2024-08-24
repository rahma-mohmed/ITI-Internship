namespace ConsoleApp3
{
    public class c1
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return $"x = {x} y = {y}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<c1> list = new List<c1>()
            {

                new c1 {x = 20 , y = 10 },
                new c1 {x = 10 , y = 50 },
                new c1 {x = 30 , y = 10 }
            };

            foreach (c1 c in list) { 
                Console.WriteLine(c.ToString());
            }

            //delegate
            Comparison<c1> comp = SortByX;

            list.Sort(SortByX);

            //lamda 
            list.Sort((c1, c2) => c1.x.CompareTo(c2.x));

            //anoymous
            list.Sort(delegate (c1 a, c1 b)
            {
                return a.x.CompareTo(b.x);
            });

            foreach (c1 c in list)
            {
                Console.WriteLine(c.ToString());
            }
        }

        static int SortByX(c1 a , c1 b)
        {
            return a.x.CompareTo(b.x);
        }
    }
}
