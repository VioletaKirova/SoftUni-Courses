using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Height = height;
            this.Width = width;
        }

        public double Length
        {
            get { return length; }
            private set { length = value; }
        }

        public double Width
        {
            get { return width; }
            private set { width = value; }
        }

        public double Height
        {
            get { return height; }
            private set { height = value; }
        }

        public double GetSurfaceArea()
        {
            return (this.Width * this.Height + this.Width * this.Length + this.Height * this.Length) * 2;
        }

        public double GetLateralSurfaceArea()
        {
            return (this.Width * this.Height + this.Length * this.Height) * 2;
        }

        public double GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
