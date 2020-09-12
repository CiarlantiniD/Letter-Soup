
public class Grid
{
    public int Wight => Data.GetLength(0);
    public int Height => Data.GetLength(1);
    public char[,] Data { get; }

    public Grid(char [,] data)
    {
        Data = data;
    }

    public Grid (int wight, int height)
    {
        Data = new char[wight,height];
    }

    public char GetLeterInPosition(int x, int y)
    {
        return Data[x, y];
    }
}
