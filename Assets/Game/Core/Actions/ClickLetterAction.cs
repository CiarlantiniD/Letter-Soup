using System.Collections;
using System.Collections.Generic;

public class ClickLetterAction
{
    private readonly InMemoryLetters letters;

    public ClickLetterAction(InMemoryLetters letters)
    {
        this.letters = letters;
    }

    public TypeClickLetter ClickLetterInPosition(int x, int y)
    {
        UnityEngine.Debug.Log("Click  -  ( " + x  + " ; " + y + " )");

        Position position = new Position(x, y);
        LetterData newLetterData;

        if (letters.Exist(position))
        {
            LetterData letterData = letters.Get(position);

            if (letterData.TypeClickLetter == TypeClickLetter.Select)
                newLetterData = new LetterData(position, TypeClickLetter.Unselect);
            else
                newLetterData = new LetterData(position, TypeClickLetter.Select);

            letters.Save(newLetterData);
        }
        else
            newLetterData = new LetterData(position, TypeClickLetter.Select);

        return newLetterData.TypeClickLetter;
    }
}

public enum TypeClickLetter
{
    Select = 0,
    Unselect
}

public static class Actions
{
    private static ClickLetterAction clickLetterAction;

    public static ClickLetterAction ClickLetterAction => clickLetterAction ?? (clickLetterAction = new ClickLetterAction(new InMemoryLetters()));
}

public class LetterData
{
    public Position Position { get; }
    public TypeClickLetter TypeClickLetter { get; }

    public LetterData(Position position, TypeClickLetter typeClickLetter)
    {
        this.Position = position;
        this.TypeClickLetter = typeClickLetter;
    }
}

public class InMemoryLetters
{
    private Dictionary<Position, LetterData> repository = new Dictionary<Position, LetterData>();

    public void Save(LetterData letterData)
    {
        if (repository.ContainsKey(letterData.Position))
            repository[letterData.Position] = letterData;
        else
            repository.Add(letterData.Position, letterData);
    }

    public LetterData Get(Position position)
    {
        if (repository.ContainsKey(position))
            return repository[position];

        throw new System.Exception("Error Value in repo");
    }

    public bool Exist(Position position)
    {
        return repository.ContainsKey(position);
    }
}