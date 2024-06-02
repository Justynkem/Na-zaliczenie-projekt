public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    //Copy constructor
    public Point(Point other)
    {
        X = other.X;
        Y = other.Y;
    }
}