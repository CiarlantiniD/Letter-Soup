using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class GameSericeShould
    {
        private IGameService gameService;

        private static Dictionary<Word, List<Position>> SomeWordsPositions = new Dictionary<Word, List<Position>>()
            {
                {new Word("uno"), new List<Position>{new Position(0,0), new Position(1, 0), new Position(2, 0) } },
                {new Word("dos"), new List<Position>{new Position(0,1), new Position(1, 1), new Position(2, 1) } },
                {new Word("six"), new List<Position>{new Position(0,2), new Position(1, 2), new Position(2, 2) } }
            };

        private readonly char[,] SomeCharArray = new char[3, 3]
            {
                {'u','n','o' },
                {'d','o','s' },
                {'s','i','x' }
            };

        private GridWithLetters GridWithLetters;

        [SetUp]
        public void Setup()
        {
            GridWithLetters = new GridWithLetters(new Grid(SomeCharArray), SomeWordsPositions);
            Logger.SetProvider(new UnityLogger());
            gameService = new GameService();
        }

        [Test]
        public void Save_Selected_Position()
        {
            // Given
            var position = new Position(0, 0);
            gameService.SetNewGame(GridWithLetters);

            // When
            var resutl = gameService.SelectLetterPosition(position);

            // Then
            Assert.IsTrue(LetterStateType.Selected == resutl.GetState());
        }

        [Test]
        public void Unselected_Position_When_Position_Was_Selected()
        {
            // Given
            var position = new Position(0, 0);
            gameService.SetNewGame(GridWithLetters);

            // When
            gameService.SelectLetterPosition(position);
            var resutl = gameService.SelectLetterPosition(position);

            // Then
            Assert.IsTrue(LetterStateType.Unselected == resutl.GetState());
        }

        [Test]
        public void Save_Selected_Position_When_Was_Select_Unselected_And_Selected_Again()
        {
            // Given
            var position = new Position(0, 0);
            gameService.SetNewGame(GridWithLetters);

            // When
            gameService.SelectLetterPosition(position);
            gameService.SelectLetterPosition(position);
            var resutl = gameService.SelectLetterPosition(position);

            // Then
            Assert.IsTrue(LetterStateType.Selected == resutl.GetState());
        }

        [Test]
        public void Throw_UnvalidPositionException_When_Position_Is_Higher_Than_Max_Of_Grid()
        {
            // Given
            var position = new Position(GridWithLetters.Wight + 1 , GridWithLetters.Height + 1);
            gameService.SetNewGame(GridWithLetters);

            // When - Then
            Assert.Throws<UnvalidPositionException>(delegate { gameService.SelectLetterPosition(position); });
        }

        [Test]
        public void Throw_UnvalidPositionException_When_Position_Is_Lower_Than_Zero()
        {
            // Given
            var xPosition = GridWithLetters.Wight - GridWithLetters.Wight - 1;
            var yPosition = GridWithLetters.Height - GridWithLetters.Height - 1;
            var position = new Position(xPosition, yPosition);
            gameService.SetNewGame(GridWithLetters);

            // When - Then
            Assert.Throws<UnvalidPositionException>(delegate { gameService.SelectLetterPosition(position); });
        }

        [Test]
        public void Cancel_Unselect_When_Word_Was_Full_Selected()
        {
            // Given
            gameService.SetNewGame(GridWithLetters);

            // When
            gameService.SelectLetterPosition(new Position(0, 0));
            gameService.SelectLetterPosition(new Position(1, 0));
            gameService.SelectLetterPosition(new Position(2, 0));
            var resutl = gameService.SelectLetterPosition(new Position(0, 0));

            // Then
            Assert.IsTrue(LetterStateType.Selected == resutl.GetState());
        }
    }
}


