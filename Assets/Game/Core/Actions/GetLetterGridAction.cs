
public class GetLetterGridAction
{
    private readonly IGameService gameService;

    public GetLetterGridAction(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public LetersGrid Execute()
    {
        return gameService.Grid;
    }
}
