using System.Collections.Generic;

public interface AddWordsService
{
    LetersGrid AddWords(LetersGrid grid, List<Word> words);
}

public class AddWordsLeftToRightService : AddWordsService
{
    private readonly IRamdomPositionGenerator ramdomPositionGenerator;

    private LetersGrid newGrid;  

    public AddWordsLeftToRightService(IRamdomPositionGenerator ramdomPositionGenerator)
    {
        this.ramdomPositionGenerator = ramdomPositionGenerator;
    }

    public LetersGrid AddWords(LetersGrid grid, List<Word> words)
    {
        newGrid = grid;
        ramdomPositionGenerator.SetMaxPosition(new Position(grid.Wight, grid.Height));            

        foreach (var word in words)
        {
            Position initialRandomPosition = ramdomPositionGenerator.GetRandomPosition();
            List<Position> positions = GetPositions(word, initialRandomPosition);
            newGrid.AddWord(word, positions);
        }

        return newGrid;
    }

    private List<Position> GetPositions(Word word, Position initialPosition)
    {
        List<Position> positions = new List<Position>();

        var position = RepositioningInitalPositionIfNeeded(word, initialPosition);

        positions.Add(position);
        for (int i = 1; i < word.Lenght; i++)
        {
            position = new Position(position.x + 1, position.y);
            positions.Add(position);
        }
        return positions;
    }

    private Position RepositioningInitalPositionIfNeeded(Word word, Position initialPosition)
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
}