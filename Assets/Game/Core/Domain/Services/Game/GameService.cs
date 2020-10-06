using System;
using System.Collections.Generic;

public class GameService : IGameService
{
    public LetersGrid Grid => throw new NotImplementedException();

    public List<Position> SelectedPositions => throw new NotImplementedException();

    public LetterState SelectLetterPosition(Position position)
    {
        throw new NotImplementedException();
    }

    public void SetNewGame(Game game)
    {
        throw new NotImplementedException();
    }
}