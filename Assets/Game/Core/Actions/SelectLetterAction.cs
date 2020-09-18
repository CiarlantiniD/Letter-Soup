using System.Collections;
using System;

public class SelectLetterAction
{
    private readonly IGameRepository gameRepository;

    public SelectLetterAction(IGameRepository gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    public LetterState Execute(int x, int y)
    {
        Logger.Log("Click  -  ( " + x  + " ; " + y + " )");
        Position position = new Position(x, y);

        return gameRepository.Get().SelectPoition(position);
    }
}
