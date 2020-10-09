using System.Collections.Generic;

public class GridWithLetters
{
    public int Wight => Grid.Wight;
    public int Height => Grid.Height;
    public Grid<char> Grid { get; }
    public Dictionary<Word, List<Position>> Words { get; }

    public GridWithLetters(Grid<char> grid, Dictionary<Word, List<Position>> words)
    {
        Grid = grid;
        Words = words;
    }

    public char GetLeterInPosition(int x, int y)
    {
        return Grid.GetInPosition(x, y);
    }
}
