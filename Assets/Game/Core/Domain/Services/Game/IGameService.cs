using System.Collections.Generic;

public interface IGameService
{
    GridWithLetters Grid { get; }
    List<Position> SelectedPositions { get; }

    void SetNewGame(GridWithLetters grid);
    LetterState SelectLetterPosition(Position position);
}