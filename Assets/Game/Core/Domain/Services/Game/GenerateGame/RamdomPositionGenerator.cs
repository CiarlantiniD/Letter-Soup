using System;

public class RamdomPositionGenerator : IRamdomPositionGenerator
{
    private Position maxPosition;
    private Random random = new Random();

    public Position GetRandomPosition()
    {
        var x = random.Next(0, maxPosition.x);
        var y = random.Next(0, maxPosition.y);
        return new Position(x, y);
    }

    public void SetMaxPosition(Position position)
    {
        maxPosition = position;
    }
}