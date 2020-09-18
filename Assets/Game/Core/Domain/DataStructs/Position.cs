
public class Position
{
    public int x { get; }
    public int y { get; }

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool IsEqual(Position position)
    {
        return x == position.x && y == position.y;
    }
}
