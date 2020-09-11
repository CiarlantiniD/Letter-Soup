using System.Collections;

public class AddWordsService
{
    private readonly Words wordsRepository;
    private readonly IRamdomPositionGenerator ramdomPositionGenerator;
    private readonly IShuffleWordsService shuffleWordsService;

    private DataGrid newDataGrid;

    public AddWordsService(Words wordsRepository, IRamdomPositionGenerator ramdomPositionGenerator, IShuffleWordsService shuffleWordsService)
    {
        this.wordsRepository = wordsRepository;
        this.ramdomPositionGenerator = ramdomPositionGenerator;
        this.shuffleWordsService = shuffleWordsService;
    }

    public DataGrid AddWords(DataGrid dataGrid, int wordsForGrid)
    {
        newDataGrid = new DataGrid(new char[dataGrid.Wight, dataGrid.Height]);
        ramdomPositionGenerator.SetMaxPosition(new Position(dataGrid.Wight, dataGrid.Height));

        var listOfWords = wordsRepository.GetAll();
        listOfWords = shuffleWordsService.Shuffle(listOfWords);
        listOfWords.RemoveRange(wordsForGrid, listOfWords.Count-1);

        foreach (var word in listOfWords)
        {
            Position randomPosition = default;

            for (int i = 0; i < 100; i++) // Revisar
            {
                randomPosition = ramdomPositionGenerator.GetRandomPosition();

                if (CheckIfValidPlaceForWord(randomPosition, word))
                    break;

                if (i == 100)
                    throw new System.Exception("Se pudrio todo");
            }

            AddWordToGrid(randomPosition, word);
        }

        return newDataGrid;
    }

    private bool CheckIfValidPlaceForWord(Position position, Word word)
    {
        var maxPositionOfNewWord = position.x + word.Lenght;
        if (newDataGrid.Wight < maxPositionOfNewWord)
            return false;

        return true;
    }

    private void AddWordToGrid(Position position, Word word)
    {
        char[,] grid = newDataGrid.Data;
        char[] wordDesglosada = word.Value.ToCharArray();
        var maxPosition = position.x + word.Lenght;
        int count = 0;

        for (int x = position.x; x < maxPosition; x++)
        {
            grid[x, position.y] = wordDesglosada[count];
            ++count;
        }

        newDataGrid = new DataGrid(grid);
    }

}