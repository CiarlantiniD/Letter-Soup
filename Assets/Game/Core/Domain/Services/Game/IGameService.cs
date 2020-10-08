using System.Collections.Generic;

public interface IGameService
{
    GridWithLetters Grid { get; }
    List<SerieDePosiciones> SerieDePosiciones { get; }

    void SetNewGame(GridWithLetters grid);
    LetterState SelectLetterPosition(Position position);
}