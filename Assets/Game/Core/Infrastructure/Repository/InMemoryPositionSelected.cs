using System.Collections.Generic;

public class InMemoryPositionSelected : IPositionSelected
{
    private Dictionary<Position, Letter> repository = new Dictionary<Position, Letter>();

    public void Save(Letter letterData)
    {
        if (repository.ContainsKey(letterData.Position))
            repository[letterData.Position] = letterData;
        else
            repository.Add(letterData.Position, letterData);
    }

    public Letter Get(Position position)
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