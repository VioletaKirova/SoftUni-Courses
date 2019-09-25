namespace _02_PointInRectangle
{
    public class Rectangle
    {
        private Point bottomLeft;
        private Point topRight;

        public Rectangle(Point bottomLeft, Point topRight)
        {
            this.BottomLeft = bottomLeft;
            this.TopRight = topRight;
        }

        public Point BottomLeft
        {
            get { return this.bottomLeft; }
            set { this.bottomLeft = value; }
        }

        public Point TopRight
        {
            get { return this.topRight; }
            set { this.topRight = value; }
        }

        public bool Contains(Point point)
        {
            bool isInHorizontal = 
                this.BottomLeft.X <= point.X && 
                this.TopRight.X >= point.X;

            bool isInVertical = 
                this.BottomLeft.Y <= point.Y && 
                this.TopRight.Y >= point.Y;

            bool isInRectangle = isInHorizontal && isInVertical;

            return isInRectangle;
        }
    }
}
