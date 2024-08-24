using MenuApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAppGraph
{
    internal class Picture
    {
        //aggregation
        Shape[] shapes;

        public Picture(Shape[] shapes)
        {
            this.shapes = shapes;
        }

        public void Draw()
        {
            foreach (var shape in shapes)
            {
                shape.DrawShape();
            }
        }
    }
}
