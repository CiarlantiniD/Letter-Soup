using System.Collections;
using System.Collections.Generic;

public class LetterState
{
    private LetterStateType type;

    public void SetSelected()
    {
        type = LetterStateType.Selected;
    }

    public void SetUnselected()
    {
        type = LetterStateType.Unselected;
    }

    public LetterStateType GetState()
    {
        return type;
    }
}

public enum LetterStateType
{
    Selected = 0,
    Unselected
}