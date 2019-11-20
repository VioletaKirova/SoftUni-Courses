using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }

        public void Draw()
        {
            Console.WriteLine(DrawLine('*', width));

            for (int i = 0; i < height - 2; i++)
            {
                Console.WriteLine("*" + DrawLine(' ', width - 2) + "*");
            }

            Console.WriteLine(DrawLine('*', width));
        }

        private string DrawLine(char symbol, int length)
        {
            return new string(symbol, length);
        }
    }
}
