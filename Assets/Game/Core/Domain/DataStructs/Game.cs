using System;
using System.Collections.Generic;

public class Game
{
    public LetersGrid Grid { get; private set; }
    public List<Word> Words { get; private set; }
    public List<Position> SelectedPositions { get; private set; }

    public Game(LetersGrid grid, List<Word> words)
    {
        Grid = grid;
        Words = words;
        SelectedPositions = new List<Position>();
    }

    public LetterState SelectPoition(Position position)
    {
        var letterState = new LetterState();

        if (position.x < 0 && position.y < 0)
            throw new UnvalidPositionException();

        if (position.x > Grid.Wight && position.y > Grid.Height)
            throw new UnvalidPositionException();

        if (SelectedPositions.Exists( element => element.IsEqual(position)))
        {
            var index = SelectedPositions.FindIndex(element => element.IsEqual(position));
            SelectedPositions.RemoveAt(index);
            letterState.SetUnselected();
        }
        else
        {
            letterState.SetSelected();
            SelectedPositions.Add(position);
        }
            
        return letterState;
    }
}
