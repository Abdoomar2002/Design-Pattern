using static System.Console;
namespace LSP
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public Rectangle()
        {
        }
        public override string ToString()
        {
            return $"Rectangle: {Width} : {Height}";
        }
    }
    public class Square :Rectangle
    {
        public override int Width 
        {
            get => base.Width; 
            set { base.Width = base.Height = value; }
        } 
        public override int Height 
        {
            get => base.Height; 
            set { base.Width = base.Height = value; }
        }
    }
    public static class Program
    {
        public static int Area(Rectangle rectangle)
        {
            rectangle.Width = 10; 
            rectangle.Height = 5;
            return rectangle.Width * rectangle.Height;
        }
        public static void Main(string[] args)
        {
            Rectangle rc= new Rectangle(2,3);
            WriteLine($"{rc} Area = {Area(rc)}");
            Square sq = new Square();
            sq.Width = 5;
            WriteLine($"{sq} Area = {Area(sq)}");
            Rectangle RcSq=new Square();
            RcSq.Width = 6;
            WriteLine($"{RcSq} Area = {Area(RcSq)}");
        }
    }
}