using MenuApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryForms;


namespace MenuAppGraph
{
    internal class Circle : Shape
    {
        public MenuApp.Point center;
        public int radius;

        public Circle(int x , int y , int r , Color c)
        {
            center = new MenuApp.Point(x , y );
            radius = r;
            color = c;
        }

        public override void DrawShape()
        {
            DrawingClass.DrawCircle(color, center.X , center.Y , radius , true);
        }
    }
}
