
public class ServiceProvider
{
    private static IRamdomPositionGenerator ramdomPositionGenerator;
    private static AddWordsLeftToRightService addWordsLeftToRightService;
    private static FillGridService fillGridService;
    private static IShuffleWordsService shuffleWordsService;

    public static IRamdomPositionGenerator RamdomPositionGenerator =>
        ramdomPositionGenerator ?? (ramdomPositionGenerator = new RamdomPositionGenerator());

    public static AddWordsLeftToRightService AddWordsLeftToRightService =>
        addWordsLeftToRightService ?? (addWordsLeftToRightService = new AddWordsLeftToRightService(ramdomPositionGenerator));

    public static FillGridService FillGridService =>
        fillGridService ?? (fillGridService = new FillGridService());

    public static IShuffleWordsService ShuffleWordsService =>
        shuffleWordsService ?? (shuffleWordsService = new ShuffleWordsService());
}
