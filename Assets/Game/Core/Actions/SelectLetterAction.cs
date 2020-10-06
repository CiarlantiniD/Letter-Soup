using System.Collections;
using System;

public class SelectLetterAction
{
    private readonly IGameService gameService;

    public SelectLetterAction(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public LetterState Execute(int x, int y)
    {
        Logger.Log("Click  -  ( " + x  + " ; " + y + " )");
        Position position = new Position(x, y);

        return gameService.SelectLetterPosition(position);
    }
}
