using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterComponent : MonoBehaviour, ILetterComponent
{
    [SerializeField] private Text letter;
    [SerializeField] private Button button;
    [SerializeField] private Image background;

    private LetterComponentPresenter presenter;

    private Color typeClickLetterSelected = Color.blue;
    private Color typeClickLetterUnselected = Color.white;

    private int x;
    private int y;

    public void Load(int x, int y)
    {
        this.x = x;
        this.y = y;

        presenter = new LetterComponentPresenter(ActionsProvider.ClickLetterAction, this);
        button.onClick.AddListener(ClickLetter);
    }

    private void ClickLetter()
    {
        presenter.SelectLetter(x, y);
    }

    public void SetLetter(char newLetter)
    {
        letter.text = newLetter.ToString();
    }

    public void ShowSelected()
    {
        background.color = typeClickLetterSelected;
    }

    public void ShowUnselected()
    {
        background.color = typeClickLetterUnselected;
    }
}
