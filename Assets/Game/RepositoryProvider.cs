
public class RepositoryProvider
{
    public static IWordsRepository WordsRepository { get; private set; }

    public RepositoryProvider()
    {
        WordsRepository = new InMemoryWordsRepository();
    }
}