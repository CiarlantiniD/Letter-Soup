using System.Collections.Generic;

public class LetersGrid
{
    public int Wight => Data.GetLength(0);
    public int Height => Data.GetLength(1);
    public char[,] Data { get; private set; }

    Dictionary<Word, List<Position>> words = new Dictionary<Word, List<Position>>();

    public bool AddWord(Word word, List<Position> positions)
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

            if (Data[position.x, position.y] != SpecialLetters.EMPTY_SPACE)
                throw new OcupateSpaceOnGridException();

            Data[position.x, position.y] = charArray[i];
        }
    }

    public LetersGrid(char [,] data)
    {
        Data = data;
    }

    public LetersGrid (int wight, int height)
    {
        Data = new char[wight,height];
    }

    public char GetLeterInPosition(int x, int y)
    {
        return Data[x, y];
    }
}
