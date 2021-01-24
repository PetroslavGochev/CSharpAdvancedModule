using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle:IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width,int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrawaLine(this.width, '*', '*');
            for (int i = 1; i < this.height-1; ++i)
            {
                DrawaLine(this.width, '*', ' ');
            }
            DrawaLine(this.width, '*', '*');
        }
        private void DrawaLine(int width,char end,char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width; ++i)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
