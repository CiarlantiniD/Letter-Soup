using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGridWidget : MonoBehaviour, ILetterGridWidget
{

    [SerializeField] private LetterRowComponent[] letterRows;

    private LetterGridWidgetPresenter presenter;

    //Temporal
    private void Start()
    {
        Load();
    }
        

    public void Load()
    {
        presenter = new LetterGridWidgetPresenter(this);
        presenter.Load();
    }

    public void SetGrid(Grid letterGridData)
    {
        for (int y = 0; y < 12; y++)
        {
            for (int x = 0; x < 12; x++)
            {
                letterRows[y].SetLetterInPosition(x, letterGridData.GetLeterInPosition(x, y));
                letterRows[y].SetLetterPosition(x, y);
            }
        }
    }
}
