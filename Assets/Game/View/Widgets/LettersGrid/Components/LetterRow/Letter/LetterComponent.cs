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

    private void Start()
    {
        button.onClick.AddListener(ClickLetter);
    }

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetLetter(char newLetter)
    {
        letter.text = newLetter.ToString();
    }

    private void ClickLetter()
    {
        TypeClickLetter currentState = Actions.ClickLetterAction.ClickLetterInPosition(x, y);

        switch (currentState)
        {
            case TypeClickLetter.Select:
                background.color = typeClickLetterSelected; break;
            case TypeClickLetter.Unselect:
                background.color = typeClickLetterUnselected; break;
            default:
                background.color = Color.grey; break;
        }
    }
}
