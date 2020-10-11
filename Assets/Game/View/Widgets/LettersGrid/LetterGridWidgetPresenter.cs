using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGridWidgetPresenter
{
    private readonly ILetterGridWidget view;

    private GridWithLetters currentGridWithLetters;

    public LetterGridWidgetPresenter(ILetterGridWidget view)
    {
        this.view = view;
    }

    public void Load()
    {
        currentGridWithLetters = ActionsProvider.GetLetterGridAction.Execute();
        view.SetLettersGridPosition(currentGridWithLetters);
    }

    public void OnNewGame()
    {
        view.SetLettersGrid(ActionsProvider.GetLetterGridAction.Execute());
    }

    public void OnWinGame()
    {
        view.TurnOffAll();

        foreach (var winWordsPositions in currentGridWithLetters.Words.Values)
        {
            foreach (var winWordPositions in winWordsPositions)
            {
                view.HightlightLetter(winWordPositions);
            }
        }
    }
}
