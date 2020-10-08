
public enum LetterStateType
{
    Selected = 0,
    Unselected
}

public class LetterState
{
    private LetterStateType type;

    public LetterState(LetterStateType type)
    {
        this.type = type;
    }

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

