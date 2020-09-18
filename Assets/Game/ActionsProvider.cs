
public class ActionsProvider
{
    public static SelectLetterAction ClickLetterAction { get; private set; }
    public static GenerateNewGameAction GenerateNewGameAction { get; private set; }
    public static GetLetterGridAction GetLetterGridAction { get; private set; }

    public ActionsProvider()
    {
        ClickLetterAction = new SelectLetterAction(RepositoryProvider.GameRepository);

        GenerateNewGameAction = new GenerateNewGameAction(
            ServiceProvider.AddWordsLeftToRightService,
            ServiceProvider.FillGridService,
            ServiceProvider.ShuffleWordsService,
            RepositoryProvider.GameRepository,
            RepositoryProvider.WordsRepository);

        GetLetterGridAction = new GetLetterGridAction(RepositoryProvider.GameRepository);
    }
}