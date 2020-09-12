using System.Collections.Generic;

public class AddWordsService
{
    private readonly IRamdomPositionGenerator ramdomPositionGenerator;

    private Grid newGrid;  

    public AddWordsService(IRamdomPositionGenerator ramdomPositionGenerator)
    {
        this.ramdomPositionGenerator = ramdomPositionGenerator;
    }

    public Grid AddWords(Grid grid, List<Word> words)
    {
        newGrid = new Grid(new char[grid.Wight, grid.Height]);
        ramdomPositionGenerator.SetMaxPosition(new Position(grid.Wight, grid.Height));            

        foreach (var word in words)
        {
            Position randomPosition = ramdomPositionGenerator.GetRandomPosition();

            if (CheckIfValidPlaceForWord(randomPosition, word) == false)
                randomPosition = RepositingWord(randomPosition, word);

            AddWordToGrid(randomPosition, word);
        }

        return newGrid;
    }

    private Position RepositingWord(Position initialPosition, Word word)
    {
        Position position;
        int x = initialPosition.x;

        for (int y = initialPosition.y; y < newGrid.Height; y++)
        {
            for (; x < newGrid.Wight; x++)
            {
                position = new Position(x, y);

                if (CheckIfValidPlaceForWord(position, word))
                    return position;
            }
            x = 0;
        }

        for (int y = 0; y < newGrid.Height; y++)
        {
            for (; x < newGrid.Wight; x++)
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
        if (newGrid.Wight < maxPositionOfNewWord)
            return false;

        for (int x = position.x; x < maxPositionOfNewWord; x++)
        {
            if (newGrid.GetLeterInPosition(x, position.y) != SpecialLetters.EMPTY_SPACE)
                return false;
        }

        return true;
    }

    private void AddWordToGrid(Position position, Word word)
    {
        char[,] grid = newGrid.Data;
        char[] wordDesglosada = word.Value.ToCharArray();
        var maxPosition = position.x + word.Lenght;
        int count = 0;

        for (int x = position.x; x < maxPosition; x++)
        {
            grid[x, position.y] = wordDesglosada[count];
            ++count;
        }

        newGrid = new Grid(grid);
    }

}