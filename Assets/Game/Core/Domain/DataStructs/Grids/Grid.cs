
public class Grid<T>
{
    public T[,] Data { get; private set; }
    public int Wight => Data.GetLength(0);
    public int Height => Data.GetLength(1);

    public Grid(T [,] data)
    {
        Data = data;
    }

    public Grid(uint wight, uint height)
    {
        Data = new T[wight, height];
    }

    public T GetInPosition(int x, int y)
    {
        return Data[x,y];
    }

    public void SetValueInPosition(int x, int y, T value)
    {
        Data[x,y] = value;
    }
}