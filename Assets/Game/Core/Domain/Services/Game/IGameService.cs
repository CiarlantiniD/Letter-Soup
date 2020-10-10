
public interface IGameService
{
    GridWithLetters Grid { get; }

    void SetNewGame(GridWithLetters grid);
    LetterState SelectLetterPosition(Position position);
}