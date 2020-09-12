using System.Collections;
using System;

public class ClickLetterAction
{
    private readonly IGameRepository gameRepository;

    public Action OnFinishClick;

    public ClickLetterAction(IGameRepository gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    public void Execute(int x, int y)
    {
        Logger.Log("Click  -  ( " + x  + " ; " + y + " )");

        Position position = new Position(x, y);

        return;

        OnFinishClick?.Invoke();
    }
}
