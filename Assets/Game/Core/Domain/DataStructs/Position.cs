
public class Position
{
    public int x { get; }
    public int y { get; }

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // se tiene que borrar
    public bool IsEqual(Position position)
    {
        return x == position.x && y == position.y;
    }

    public override string ToString()
    {
        return $"Position({x},{y})";
    }

    public override bool Equals(object obj)
    {
        return obj is Position position &&
               x == position.x &&
               y == position.y;
    }

    public override int GetHashCode()
    {
        int hashCode = 1502939027;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        return hashCode;
    }
}
