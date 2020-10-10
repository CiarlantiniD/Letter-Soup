using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGridWidgetPresenter
{
    private readonly ILetterGridWidget view;

    public LetterGridWidgetPresenter(ILetterGridWidget view)
    {
        this.view = view;
    }

    public void Load()
    {
        view.SetLettersGridPosition(ActionsProvider.GetLetterGridAction.Execute());
    }

    public void OnNewGame()
    {
        view.SetLettersGrid(ActionsProvider.GetLetterGridAction.Execute());
    }
}
