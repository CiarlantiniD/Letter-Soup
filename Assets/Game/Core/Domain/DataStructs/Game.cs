using System;
using System.Collections.Generic;

public class Game
{
    public LetersGrid Grid { get; private set; }
    public List<Word> Words { get; private set; }

    public Game(LetersGrid grid, List<Word> words)
    {
        Grid = grid;
        Words = words;
    }
}
