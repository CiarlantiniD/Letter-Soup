
public static class ActionsProvider
{
    private static ClickLetterAction clickLetterAction;
    private static GenerateNewGameAction generateNewGameAction;
    private static GetLetterGridAction getLetterGridAction;

    public static ClickLetterAction ClickLetterAction =>
        clickLetterAction ?? (clickLetterAction = new ClickLetterAction(RepositoryProvider.GameRepository));

    public static GenerateNewGameAction GenerateNewGameAction =>
        generateNewGameAction ?? (generateNewGameAction = new GenerateNewGameAction(
            ServiceProvider.AddWordsLeftToRightService,
            ServiceProvider.FillGridService,
            ServiceProvider.ShuffleWordsService,
            RepositoryProvider.GameRepository,
            RepositoryProvider.WordsRepository));

    public static GetLetterGridAction GetLetterGridAction =>
        getLetterGridAction ?? (getLetterGridAction = new GetLetterGridAction(RepositoryProvider.GameRepository));
}