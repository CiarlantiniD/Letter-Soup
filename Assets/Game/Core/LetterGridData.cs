
public class LetterGridData
{
    public int Wight => data.Length;
    public int Height => data.Length;
    private readonly char[,] data;

    public LetterGridData(char [,] data)
    {
        this.data = data;
    }

    public char GetLeterInPosition(int x, int y)
    {
        return data[x, y];
    }
}
