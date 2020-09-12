using System.Collections.Generic;

public class GenerateNewGameAction
{
    private readonly AddWordsLeftToRightService addWordsService;
    private readonly FillGridService fillGridService;
    private readonly IShuffleWordsService shuffleWordsService;
    private readonly IGameRepository game;
    private readonly IWordsRepository words;

    public GenerateNewGameAction(AddWordsLeftToRightService addWordsService, FillGridService fillGridService, IShuffleWordsService shuffleWordsService, IGameRepository game, IWordsRepository words)
    {
        this.addWordsService = addWordsService;
        this.fillGridService = fillGridService;
        this.shuffleWordsService = shuffleWordsService;
        this.game = game;
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

        game.Save(new Game(grid, wordsForGame));
    }
}
