using System.Collections.Generic;
using System;

public class GenerateNewGameAction
{
    private readonly AddWordsToGridLeftToRightService addWordsService;
    private readonly FillGridService fillGridService;
    private readonly IShuffleWordsService shuffleWordsService;
    private readonly IGameService gameService;
    private readonly IWordsRepository words;

    private bool haveGameActive;
    public Action OnGameReset;

    public GenerateNewGameAction(AddWordsToGridLeftToRightService addWordsService, FillGridService fillGridService, IShuffleWordsService shuffleWordsService, IGameService gameService, IWordsRepository words)
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
        Grid<char> grid = new Grid<char>((uint)wight, (uint)height);
        GridWithLetters gridWithLetters;

        wordsForGame = shuffleWordsService.Shuffle(wordsForGame);

        if (minWordsForGrid < wordsForGame.Count)
        {
            int toremover = wordsForGame.Count - minWordsForGrid;
            wordsForGame.RemoveRange(minWordsForGrid, toremover);
        }

        gridWithLetters = addWordsService.AddWords(grid, wordsForGame);
        gridWithLetters = fillGridService.FillGrid(gridWithLetters);

        gameService.SetNewGame(gridWithLetters);

        if (haveGameActive)
            OnGameReset?.Invoke();
        
        Logger.Log("-- New Game --");
        haveGameActive = true;
    }
}
