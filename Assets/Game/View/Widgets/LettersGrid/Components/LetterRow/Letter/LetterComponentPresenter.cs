using System.Collections;
using System.Collections.Generic;

public class LetterComponentPresenter
{
    private SelectLetterAction action { get; }
    private ILetterComponent view { get; }

    public LetterComponentPresenter(SelectLetterAction action, ILetterComponent view)
    {
        this.action = action;
        this.view = view;
    }

    public void SelectLetter(int x, int y)
    {
        var letterState = action.Execute(x, y);
        SetView(letterState);
    }

    private void SetView(LetterState state)
    {
        if (state.GetState() == LetterStateType.Selected)
            view.ShowSelected();
        if (state.GetState() == LetterStateType.Unselected)
            view.ShowUnselected();
    }

}
