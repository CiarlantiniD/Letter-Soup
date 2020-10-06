
public class ActionsProvider
{
    public static SelectLetterAction ClickLetterAction { get; private set; }
    public static GenerateNewGameAction GenerateNewGameAction { get; private set; }
    public static GetLetterGridAction GetLetterGridAction { get; private set; }

    public ActionsProvider()
    {
        ClickLetterAction = new SelectLetterAction(ServiceProvider.GameService);

        GenerateNewGameAction = new GenerateNewGameAction(
            ServiceProvider.AddWordsLeftToRightService,
            ServiceProvider.FillGridService,
            ServiceProvider.ShuffleWordsService,
            ServiceProvider.GameService,
            RepositoryProvider.WordsRepository);

        GetLetterGridAction = new GetLetterGridAction(ServiceProvider.GameService);
    }
}