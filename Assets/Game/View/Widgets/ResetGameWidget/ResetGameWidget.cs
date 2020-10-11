using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGameWidget : MonoBehaviour, IResetGameWidget
{
    [SerializeField] private Button resetButton;

    public event Action OnResetGame;

    private ResetGameWidgetPresenter presenter;

    public void Load()
    {
        presenter = new ResetGameWidgetPresenter(this, ActionsProvider.GenerateNewGameAction);
        resetButton.onClick.AddListener(ResetGame);
    }

    private void ResetGame()
    {
        presenter.ResetGame();
    }

    public void NotifyResetGame()
    {
        OnResetGame?.Invoke();
    }
}
