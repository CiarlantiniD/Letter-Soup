using System.Collections.Generic;

namespace Tests
{
    public class SomeRandomQueuedPositionGenerator : IRamdomPositionGenerator
    {
        private Queue<Position> positions = new Queue<Position>();
        private Position maxPosition;

        public int Count => positions.Count;

        public Position GetRandomPosition()
        {
            return positions.Dequeue();
        }

        public void SetMaxPosition(Position position)
        {
            maxPosition = position;
        }

        public void SetReturnPosition(Position position)
        {
            if (position.x > maxPosition.x || position.y > maxPosition.y)
                throw new System.Exception("Posicion invalida");

            positions.Enqueue(position);
        }
    }
}
