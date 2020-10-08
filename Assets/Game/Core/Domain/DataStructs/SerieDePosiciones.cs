using System;
using System.Collections.Generic;
using System.Linq;

public class SerieDePosiciones
{
    public bool IsBlocked { get; private set; }
    private Dictionary<Position, LetterState> statePosition = new Dictionary<Position, LetterState>();

    public SerieDePosiciones(List<Position> positions)
    {
        positions.ForEach(position => statePosition.Add(position, new LetterState(LetterStateType.Unselected)));
    }

    public bool HavePosition(Position position)
    {
        return statePosition.ContainsKey(position);
    }

    public LetterState PickInPosition(Position position)
    {
        var currentStateOfPosition = statePosition[position];

        if (IsBlocked)
            return currentStateOfPosition;

        switch (currentStateOfPosition.GetState())
        {
            case LetterStateType.Selected: currentStateOfPosition.SetUnselected(); break;
            case LetterStateType.Unselected: currentStateOfPosition.SetSelected(); break;
            default: throw new UnrecognizedLetterStatusException();
        }

        HaveBlocked();
        return currentStateOfPosition;
    }

    private void HaveBlocked()
    {
        IsBlocked = statePosition.Values.ToList().All(state => state.GetState() == LetterStateType.Selected);
    }
}
