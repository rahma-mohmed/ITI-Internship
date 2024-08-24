using ClassLibraryForms;
using MenuApp;
namespace MenuAppGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DrawingClass.StartDraw(1000 , 600);

            Circle c = new Circle(80 , 80 , 150 , Color.Yellow);
            //c.DrawShape();

            Line l = new Line(550 , 100 , 400 , 400 , Color.Red);
            //l.DrawShape();

            Rectangle rec = new Rectangle(600, 100, 300, 200 , Color.HotPink);
            //rec.DrawShape();

            Shape[] sh = {c, l, rec};

            Picture pic = new Picture(sh);
            pic.Draw();

            DrawingClass.EndDraw();
        }
    }
}
