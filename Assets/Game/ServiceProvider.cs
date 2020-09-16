
public class ServiceProvider
{
    public static IRamdomPositionGenerator RamdomPositionGenerator { get; private set; }
    public static AddWordsLeftToRightService AddWordsLeftToRightService { get; private set; }
    public static FillGridService FillGridService { get; private set; }
    public static IShuffleWordsService ShuffleWordsService { get; private set; }

    public ServiceProvider()
    {
        RamdomPositionGenerator = new RamdomPositionGenerator();
        AddWordsLeftToRightService = new AddWordsLeftToRightService(RamdomPositionGenerator);
        FillGridService = new FillGridService();
        ShuffleWordsService = new ShuffleWordsService();
    }
}
