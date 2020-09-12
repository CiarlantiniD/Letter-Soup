
public class GetLetterGridAction
{
    private readonly IGameRepository gameRepository;

    public GetLetterGridAction(IGameRepository gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    public LetersGrid Execute()
    {
        return gameRepository.Get().Grid;
    }
}
