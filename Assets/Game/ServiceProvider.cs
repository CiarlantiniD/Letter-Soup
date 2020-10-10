
public class ServiceProvider
{
    public static IRamdomPositionGenerator RamdomPositionGenerator { get; private set; }
    public static AddWordsToGridLeftToRightService AddWordsLeftToRightService { get; private set; }
    public static FillGridService FillGridService { get; private set; }
    public static IShuffleWordsService ShuffleWordsService { get; private set; }
    public static ISelectionPositionService SelectionPositionService { get; private set; }
    public static IGameService GameService { get; private set; }

    public ServiceProvider()
    {
        RamdomPositionGenerator = new RamdomPositionGenerator();
        AddWordsLeftToRightService = new AddWordsToGridLeftToRightService(RamdomPositionGenerator);
        FillGridService = new FillGridService();
        ShuffleWordsService = new ShuffleWordsService();
        SelectionPositionService = new SelectionPositionService();
        GameService = new GameService(SelectionPositionService);
    }
}
