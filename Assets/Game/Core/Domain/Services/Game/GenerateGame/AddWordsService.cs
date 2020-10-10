using System.Collections.Generic;

public interface AddWordsToGridService
{
    GridWithLetters AddWords(Grid<char> grid, List<Word> words);
}

public class AddWordsToGridLeftToRightService : AddWordsToGridService
{
    private readonly IRamdomPositionGenerator ramdomPositionGenerator;

    private Grid<char> grid;
    private Dictionary<Word, List<Position>> words = new Dictionary<Word, List<Position>>();

    public AddWordsToGridLeftToRightService(IRamdomPositionGenerator ramdomPositionGenerator)
    {
        this.ramdomPositionGenerator = ramdomPositionGenerator;
    }

    public GridWithLetters AddWords(Grid<char> grid, List<Word> words)
    {
        this.grid = grid;
        this.words.Clear();
        ramdomPositionGenerator.SetMaxPosition(new Position(grid.Wight, grid.Height));            

        foreach (var word in words)
        {
            Position initialRandomPosition = ramdomPositionGenerator.GetRandomPosition();
            List<Position> positions = GetPositions(word, initialRandomPosition);
            AddWord(word, positions);
        }

        return new GridWithLetters(this.grid, this.words);
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

        for (int y = initialPosition.y; y < grid.Height; y++)
        {
            for (; x < grid.Wight; x++)
            {
                position = new Position(x, y);

                if (CheckIfValidPlaceForWord(position, word))
                    return position;
            }
            x = 0;
        }

        for (int y = 0; y < grid.Height; y++)
        {
            for (; x < grid.Wight; x++)
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
        if (grid.Wight < maxPositionOfNewWord)
            return false;

        for (int x = position.x; x < maxPositionOfNewWord; x++)
        {
            if (grid.GetInPosition(x, position.y) != SpecialLetters.EMPTY_SPACE)
                return false;
        }

        return true;
    }

    private bool AddWord(Word word, List<Position> positions)
    {
        if (word.Lenght != positions.Count)
            return false;

        AddWordToGrid(word, positions);
        words.Add(word, positions);
        return true;
    }

    private void AddWordToGrid(Word word, List<Position> positions)
    {
        char[] charArray = word.ToCharArray();

        for (int i = 0; i < positions.Count; i++)
        {
            Position position = positions[i];

            if (grid.Data[position.x, position.y] != SpecialLetters.EMPTY_SPACE)
                throw new OcupateSpaceOnGridException();

            grid.Data[position.x, position.y] = charArray[i];
        }
    }
}