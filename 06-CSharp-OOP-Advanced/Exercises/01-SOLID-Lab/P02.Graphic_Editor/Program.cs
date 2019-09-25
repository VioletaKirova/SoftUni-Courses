namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape square = new Square();

            GraphicEditor graphicEditor = new GraphicEditor();

            graphicEditor.DrawShape(circle);
            graphicEditor.DrawShape(rectangle);
            graphicEditor.DrawShape(square);
        }
    }
}
