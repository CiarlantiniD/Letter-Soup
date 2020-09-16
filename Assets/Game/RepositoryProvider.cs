
public class RepositoryProvider
{
    public static IGameRepository GameRepository { get; private set; }
    public static IWordsRepository WordsRepository { get; private set; }

    public RepositoryProvider()
    {
        GameRepository = new InMemoryGame();
        WordsRepository = new InMemoryWordsRepository();
    }
}