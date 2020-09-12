
public static class RepositoryProvider
{
    private static IGameRepository gameRepository;
    private static IWordsRepository wordsRepository;

    public static IGameRepository GameRepository => gameRepository ?? (gameRepository = new InMemoryGame());
    public static IWordsRepository WordsRepository => wordsRepository ?? (wordsRepository = new InMemoryWordsRepository());
}
