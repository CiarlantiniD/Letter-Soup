using System;
using System.Collections.Generic;

public class Game
{
    public LetersGrid Grid { get; private set; }
    public List<Word> Words { get; private set; }
    public List<Position> SelectedPositions { get; private set; }
    private GameWords gameWords;

    public Game(LetersGrid grid, List<Word> words)
    {
        Grid = grid;
        Words = words;
        SelectedPositions = new List<Position>();
        gameWords = new GameWords(grid.Words);
    }

    public LetterState SelectPoition(Position position)
    {
        var letterState = new LetterState();

        if (position.x < 0 && position.y < 0)
            throw new UnvalidPositionException();

        if (position.x > Grid.Wight && position.y > Grid.Height)
            throw new UnvalidPositionException();

        if (gameWords.CheckIfWordIsAvailable(position) == false)
        {

        }

        if (SelectedPositions.Exists( element => element.IsEqual(position)))
        {
            var index = SelectedPositions.FindIndex(element => element.IsEqual(position));
            SelectedPositions.RemoveAt(index);
            letterState.SetUnselected();
            gameWords.TryMarckPosition(position, LetterStateType.Unselected);
        }
        else
        {
            letterState.SetSelected();
            SelectedPositions.Add(position);
            gameWords.TryMarckPosition(position, LetterStateType.Selected);
        }
            
        return letterState;
    }

    private class GameWords
    {
        Dictionary<Word, GamePositionWord> words;

        public GameWords(Dictionary<Word, List<Position>> wordsFromGrid)
        {
            words = new Dictionary<Word, GamePositionWord>();

            foreach (var wordFromGrid in wordsFromGrid)
            {
                words.Add(wordFromGrid.Key, new GamePositionWord(wordFromGrid.Value));
            }
        }

        public void TryMarckPosition(Position position, LetterStateType stateType)
        {
            foreach (var word in words)
            {
                word.Value.CheckPosition(position, stateType);
            }
        }

        public bool CheckIfWordIsAvailable(Position position)
        {
            foreach (var word in words)
            {
                if (word.Value.CheckPositionExist(position))
                {
                    return word.Value.HaveAllPositionSelected() == false;
                }
            }

            return true;
        }

        private class GamePositionWord
        {
            Dictionary<Position, LetterStateType> positionWithState;

            public GamePositionWord(List<Position> positions)
            {
                positionWithState = new Dictionary<Position, LetterStateType>();

                foreach (var position in positions)
                {
                    positionWithState.Add(position, LetterStateType.Unselected);
                }
            }

            public void CheckPosition(Position position, LetterStateType stateType)
            {
                foreach (var item in positionWithState)
                {
                    if(item.Key == position)
                    {
                        positionWithState[item.Key] = stateType;
                    }
                }
            }

            public bool CheckPositionExist(Position position)
            {
                return positionWithState.ContainsKey(position);
            }

            public bool HaveAllPositionSelected()
            {
                foreach (var item in positionWithState)
                {
                    if (item.Value != LetterStateType.Selected)
                        return false;
                }

                return true;
            }
        }
    }
}