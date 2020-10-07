
public class GetLetterGridAction
{
    private readonly IGameService gameService;

    public GetLetterGridAction(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public GridWithLetters Execute()
    {
        return gameService.Grid;
    }
}
