﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryForms;

namespace MenuApp
{
    internal class Line : Shape
    {
        public Point Start;
        public Point End;

        public Line(int x1 , int y1 , int x2 , int y2 , Color c)
        {
            Start = new Point(x1, y1);
            End = new Point(x2, y2);
            color = c;
        }
        public override void DrawShape()
        {
            DrawingClass.DrawLine(color , Start.X , Start.Y , End.X , End.Y);
        }
    }
}
