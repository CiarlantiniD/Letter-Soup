using System.Collections.Generic;

public class GenerateNewGameAction
{
    private readonly AddWordsLeftToRightService addWordsService;
    private readonly FillGridService fillGridService;
    private readonly IShuffleWordsService shuffleWordsService;
    private readonly IGameService gameService;
    private readonly IWordsRepository words;

    public GenerateNewGameAction(AddWordsLeftToRightService addWordsService, FillGridService fillGridService, IShuffleWordsService shuffleWordsService, IGameService gameService, IWordsRepository words)
    {
        this.addWordsService = addWordsService;
        this.fillGridService = fillGridService;
        this.shuffleWordsService = shuffleWordsService;
        this.gameService = gameService;
        this.words = words;
    }

    public void Execute(int wight, int height, int minWordsForGrid)
    {
        List<Word> wordsForGame = words.GetAll();
        LetersGrid grid = new LetersGrid(wight, height);

        wordsForGame = shuffleWordsService.Shuffle(wordsForGame);

        if (minWordsForGrid < wordsForGame.Count)
        {
            int toremover = wordsForGame.Count - minWordsForGrid;
            wordsForGame.RemoveRange(minWordsForGrid, toremover);
        }

        grid = addWordsService.AddWords(grid, wordsForGame);
        grid = fillGridService.FillGrid(grid);

        gameService.SetNewGame(new Game(grid, wordsForGame));
    }
}
