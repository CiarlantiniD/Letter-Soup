using System.Collections;
using System.Collections.Generic;

public class ResetGameWidgetPresenter
{
    private IResetGameWidget view;
    private GenerateNewGameAction generateNewGameAction;

    public ResetGameWidgetPresenter(IResetGameWidget view, GenerateNewGameAction generateNewGameAction)
    {
        this.view = view;
        this.generateNewGameAction = generateNewGameAction;
    }

    public void ResetGame()
    {
        generateNewGameAction.Execute(GameManager.Wight,GameManager.Height, GameManager.CountWords);
    }
}
