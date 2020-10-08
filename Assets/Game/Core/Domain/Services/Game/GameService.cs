using System;
using System.Collections.Generic;
using System.Linq;

public class GameService : IGameService
{
    public GridWithLetters Grid { get; private set; }
    public List<SerieDePosiciones> SerieDePosiciones { get; private set; } = new List<SerieDePosiciones>();

    public void SetNewGame(GridWithLetters grid)
    {
        Grid = grid;
        Grid.Words.Values.ToList().ForEach(listOfPositions => SerieDePosiciones.Add(new SerieDePosiciones(listOfPositions)));
    }

    public LetterState SelectLetterPosition(Position position)
    {
        if (position.x < 0 && position.y < 0)
            throw new UnvalidPositionException();

        if (position.x > Grid.Wight && position.y > Grid.Height)
            throw new UnvalidPositionException();

        foreach (var serie in SerieDePosiciones)
        {
           if(serie.HavePosition(position))
                return serie.PickInPosition(position);
        }

        throw new Exception("No encontor la posicion");
    }
}