
public class InMemoryGame : IGameRepository
{
    private Game game;

    public void Delete()
    {
        game = null;
    }

    public Game Get()
    {
        if (game == null)
            throw new System.Exception("Dont have a game");

        return game;
    }

    public bool HaveGame()
    {
        return game != null;
    }

    public void Save(Game game)
    {
        this.game = game;
    }
}
