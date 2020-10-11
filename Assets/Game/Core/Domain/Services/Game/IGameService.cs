using System;

public interface IGameService
{
    GridWithLetters Grid { get; }

    bool CheckIfWin();
    void SetNewGame(GridWithLetters grid);
    LetterState SelectLetterPosition(Position position);
}