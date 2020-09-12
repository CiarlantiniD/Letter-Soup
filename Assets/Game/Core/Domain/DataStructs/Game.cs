using System;
using System.Collections.Generic;

public class Game
{
    public Grid Grid => grid;
    public List<Word> Words => words;

    private readonly Grid grid;
    private readonly List<Word> words;

    public Game(Grid grid, List<Word> words)
    {
        this.grid = grid;
        this.words = words;
    }
}
