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
    internal class Rectangle : Shape
    {
        MenuApp.Point Start;
        int width;
        int height;

        public Rectangle(int x1 , int y1 , int w , int h , Color c)
        {
            //composition
            Start = new MenuApp.Point(x1, y1);
            width = w;
            height = h;
            color = c;
        }

        public override void DrawShape()
        {
            DrawingClass.DrawRectangle(color,Start.X , Start.Y, width, height,true);
        }
    }
}
