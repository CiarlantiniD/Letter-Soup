
public class Grid
{
    public char[,] Data { get; }
    public int Wight => Data.GetLength(0);
    public int Height => Data.GetLength(1);

    public Grid(char [,] data)
    {
        Data = data;
    }

    public Grid(uint wight, uint height)
    {
        Data = new char[wight, height];
    }

    public char GetLeterInPosition(int x, int y)
    {
        return Data[x, y];
    }
}