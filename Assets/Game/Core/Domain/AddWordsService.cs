using System.Collections;
using System;

public class AddWordsService
{
    private readonly Words wordsRepository;
    private readonly IRamdomPositionGenerator ramdomPositionGenerator;
    private readonly IShuffleWordsService shuffleWordsService;

    private DataGrid newDataGrid;

    private const char EMPTY_SPACE = '\0';

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

        if(wordsForGrid < listOfWords.Count)
        {
            int toremover = listOfWords.Count - wordsForGrid;
            listOfWords.RemoveRange(wordsForGrid, toremover);
        }
            

        foreach (var word in listOfWords)
        {
            Position randomPosition = ramdomPositionGenerator.GetRandomPosition();

            if (CheckIfValidPlaceForWord(randomPosition, word) == false)
                randomPosition = RepositingWord(randomPosition, word);

            AddWordToGrid(randomPosition, word);
        }

        return newDataGrid;
    }

    private Position RepositingWord(Position initialPosition, Word word)
    {
        Position position;
        int x = initialPosition.x;

        for (int y = initialPosition.y; y < newDataGrid.Height; y++)
        {
            for (; x < newDataGrid.Wight; x++)
            {
                position = new Position(x, y);

                if (CheckIfValidPlaceForWord(position, word))
                    return position;
            }
            x = 0;
        }

        for (int y = 0; y < newDataGrid.Height; y++)
        {
            for (; x < newDataGrid.Wight; x++)
            {
                position = new Position(x, y);

                if (CheckIfValidPlaceForWord(position, word))
                    return position;
            }
        }

        throw new FullFillGridException();
    }

    private bool CheckIfValidPlaceForWord(Position position, Word word)
    {
        var maxPositionOfNewWord = position.x + word.Lenght;
        if (newDataGrid.Wight < maxPositionOfNewWord)
            return false;

        for (int x = position.x; x < maxPositionOfNewWord; x++)
        {
            if (newDataGrid.GetLeterInPosition(x, position.y) != EMPTY_SPACE)
                return false;
        }

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