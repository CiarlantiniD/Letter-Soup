using System.Collections;
using System;

public class SelectLetterAction
{
    public event Action OnWinGame;

    private readonly IGameService gameService;

    public SelectLetterAction(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public LetterState Execute(int x, int y)
    {
        Logger.Log("Click  -  ( " + x  + " ; " + y + " )");
        Position position = new Position(x, y);

        var pickedPositionState = gameService.SelectLetterPosition(position);

        if (gameService.CheckIfWin())
        {
            Logger.Log("-- Game Finish --");
            OnWinGame?.Invoke();
        }
            

        return pickedPositionState;
    }
}
