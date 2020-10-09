using System;
using System.Collections.Generic;

public class GridWithStatePositions
{
    public int Wight => Grid.Wight;
    public int Height => Grid.Height;
    public Grid<LetterState> Grid { get; }

    public GridWithStatePositions(Grid<LetterState> grid, Dictionary<Word, List<Position>> words)
    {
        Grid = grid;
        //Words = words;
    }
}
