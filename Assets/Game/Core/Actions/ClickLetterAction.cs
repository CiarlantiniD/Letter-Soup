using System.Collections;
using System;

public class ClickLetterAction
{
    private readonly IPositionSelected positionSelected;

    public Action OnFinishClick;

    public ClickLetterAction(IPositionSelected positionSelected)
    {
        this.positionSelected = positionSelected;
    }

    public TypeClickLetter Execute(int x, int y)
    {
        Logger.Log("Click  -  ( " + x  + " ; " + y + " )");

        Position position = new Position(x, y);
        Letter newLetterData;

        if (positionSelected.Exist(position))
        {
            Letter letterData = positionSelected.Get(position);

            if (letterData.TypeClickLetter == TypeClickLetter.Select)
                newLetterData = new Letter(position, TypeClickLetter.Unselect);
            else
                newLetterData = new Letter(position, TypeClickLetter.Select);

            positionSelected.Save(newLetterData);
        }
        else
            newLetterData = new Letter(position, TypeClickLetter.Select);

        OnFinishClick?.Invoke();
        return newLetterData.TypeClickLetter;
    }
}
