using System;
using System.Collections.Generic;
using System.Linq;

public interface ISelectionPositionService
{
    void SetGridWithLetters(GridWithLetters grid);
    LetterState SelectPosition(Position position);
    bool HaveAllWordsPicked();
}

public class SelectionPositionService : ISelectionPositionService
{
    public List<SerieDePosiciones> SerieDePosiciones { get; private set; } = new List<SerieDePosiciones>();

    private Grid<LetterState> grid;

    public void SetGridWithLetters(GridWithLetters grid)
    {
        SerieDePosiciones.Clear();
        CreateGridWithUnselectedPositions(grid);
        grid.Words.Values.ToList().ForEach(listOfPositions => SerieDePosiciones.Add(new SerieDePosiciones(listOfPositions)));
    }

    private void CreateGridWithUnselectedPositions(GridWithLetters grid)
    {
        LetterState[,] statesArray = new LetterState[grid.Wight, grid.Height];

        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Wight; x++)
            {
                statesArray[x, y] = new LetterState(LetterStateType.Unselected);
            }
        }

        this.grid = new Grid<LetterState>(statesArray);
    }

    public LetterState SelectPosition(Position position)
    {
        LetterState state = GetCurrentState(position);

        if (GetStateIfHaveWordGameInPosition(position, out LetterState newState))
            state = newState;
        else
            ChangeStateInPosition(state);

        SaveStatePosition(position, state);
        return state;
    }

    private LetterState GetCurrentState(Position position)
    {
        return grid.GetInPosition(position.x, position.y);
    }

    private void ChangeStateInPosition(LetterState currentState)
    {
        if (currentState.GetState() == LetterStateType.Selected)
            currentState.SetUnselected();
        else if (currentState.GetState() == LetterStateType.Unselected)
            currentState.SetSelected();
    }

    private bool GetStateIfHaveWordGameInPosition(Position position, out LetterState state)
    {
        state = default;

        foreach (var serie in SerieDePosiciones)
        {
            if (serie.HavePosition(position))
            {
                state = serie.PickInPosition(position);
                return true;
            }
        }

        return false;
    }

    private void SaveStatePosition(Position position, LetterState state)
    {
        grid.SetValueInPosition(position.x, position.y, state);
    }

    public bool HaveAllWordsPicked()
    {
        foreach (var posiciones in SerieDePosiciones)
        {
            if (posiciones.IsBlocked == false)
                return false;
        }

        return true;
    }
}
