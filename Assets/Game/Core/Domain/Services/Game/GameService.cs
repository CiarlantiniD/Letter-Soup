
public class GameService : IGameService
{
    public GridWithLetters Grid { get; private set; }

    private readonly ISelectionPositionService selectionPositionService;


    public GameService(ISelectionPositionService selectionPositionService)
    {
        this.selectionPositionService = selectionPositionService;
    }

    public void SetNewGame(GridWithLetters grid)
    {
        Grid = grid;
        selectionPositionService.SetGridWithLetters(grid);
    }

    public LetterState SelectLetterPosition(Position position)
    {
        if (position.x < 0 && position.y < 0)
            throw new UnvalidPositionException();

        if (position.x > Grid.Wight && position.y > Grid.Height)
            throw new UnvalidPositionException();

        return selectionPositionService.SelectPosition(position);
    }
}