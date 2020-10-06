using System.Collections.Generic;

public interface IGameService
{
    LetersGrid Grid { get; }
    List<Position> SelectedPositions { get; }

    void SetNewGame(Game game);
    LetterState SelectLetterPosition(Position position);
}