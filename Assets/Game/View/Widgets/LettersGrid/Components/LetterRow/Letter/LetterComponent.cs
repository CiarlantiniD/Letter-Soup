using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterComponent : MonoBehaviour
{
    [SerializeField] private Text letter;
    [SerializeField] private Button button;
    [SerializeField] private Image background;

    private Color typeClickLetterSelected = Color.blue;
    private Color typeClickLetterUnselected = Color.white;

    private int x;
    private int y;

    public void Load(int x, int y)
    {
        this.x = x;
        this.y = y;

        button.onClick.AddListener(ClickLetter);
    }

    public void SetLetter(char newLetter)
    {
        letter.text = newLetter.ToString();
    }

    private void ClickLetter()
    {
        ActionsProvider.ClickLetterAction.Execute(x, y);
    }
}
