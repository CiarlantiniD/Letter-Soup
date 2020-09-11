
public class DataGrid
{
    public int Wight => Data.GetLength(0);
    public int Height => Data.GetLength(1);
    public char[,] Data { get; }

    public DataGrid(char [,] data)
    {
        Data = data;
    }

    public char GetLeterInPosition(int x, int y)
    {
        return Data[x, y];
    }
}
