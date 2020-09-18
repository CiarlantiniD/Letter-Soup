using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SelectLetterActionShould
    {
        private SelectLetterAction action;
        private IGameRepository repository;

        private static int SomeXPosition = 4;
        private static int SomeYPosition = 5;

        private static int SomeMaxXPosition = 10;
        private static int SomeMaxYPosition = 10;

        [SetUp]
        public void Setup()
        {
            Logger.SetProvider(new UnityLogger());
            repository = new InMemoryGame();
            action = new SelectLetterAction(repository);
        }

        [Test]
        public void Save_Selected_Position()
        {
            // Given
            Position position = new Position(SomeXPosition, SomeYPosition);
            var newLetterGrid = new LetersGrid(new char[10, 10]);
            var newListOfWords = new List<Word>();
            var newGame = new Game(newLetterGrid, newListOfWords);
            repository.Save(newGame);

            // When
            var resutl = action.Execute(SomeXPosition, SomeYPosition);

            // Then
            List<Position> selectedPositions = repository.Get().SelectedPositions;
            Assert.IsTrue(position.IsEqual(selectedPositions[0]));
            Assert.IsTrue(LetterStateType.Selected == resutl.GetState());
        }

        [Test]
        public void Unselected_Position_When_Position_Was_Selected()
        {
            // Given
            Position position = new Position(SomeXPosition, SomeYPosition);
            var newLetterGrid = new LetersGrid(new char[10, 10]);
            var newListOfWords = new List<Word>();
            var newGame = new Game(newLetterGrid, newListOfWords);
            repository.Save(newGame);

            // When
            action.Execute(SomeXPosition, SomeYPosition);
            var resutl = action.Execute(SomeXPosition, SomeYPosition);

            // Then
            List<Position> selectedPositions = repository.Get().SelectedPositions;
            Assert.IsTrue(selectedPositions.Count == 0);
            Assert.IsTrue(LetterStateType.Unselected == resutl.GetState());
        }

        [Test]
        public void Save_Selected_Position_When_Was_Select_Unselected_And_Selected_Again()
        {
            // Given
            Position position = new Position(SomeXPosition, SomeYPosition);
            var newLetterGrid = new LetersGrid(new char[10, 10]);
            var newListOfWords = new List<Word>();
            var newGame = new Game(newLetterGrid, newListOfWords);
            repository.Save(newGame);

            // When
            action.Execute(SomeXPosition, SomeYPosition);
            action.Execute(SomeXPosition, SomeYPosition);
            var resutl = action.Execute(SomeXPosition, SomeYPosition);

            // Then
            List<Position> selectedPositions = repository.Get().SelectedPositions;
            Assert.IsTrue(position.IsEqual(selectedPositions[0]));
            Assert.IsTrue(LetterStateType.Selected == resutl.GetState());
        }

        [Test]
        public void Throw_UnvalidPositionException_When_Position_Is_Higher_Than_Max_Of_Grid()
        {
            // Given
            var SomeXPositionWithError = SomeMaxXPosition + 1;
            var SomeYPositionWithError = SomeMaxYPosition + 1;
            var newLetterGrid = new LetersGrid(new char[SomeMaxXPosition, SomeMaxYPosition]);
            var newListOfWords = new List<Word>();
            var newGame = new Game(newLetterGrid, newListOfWords);
            repository.Save(newGame);

            // When - Then
            Assert.Throws<UnvalidPositionException>(delegate { action.Execute(SomeXPositionWithError, SomeYPositionWithError); } );
       }

        [Test]
        public void Throw_UnvalidPositionException_When_Position_Is_Lower_Than_Zero()
        {
            // Given
            var SomeXPositionWithError = -1;
            var SomeYPositionWithError = -1;
            var newLetterGrid = new LetersGrid(new char[SomeMaxXPosition, SomeMaxYPosition]);
            var newListOfWords = new List<Word>();
            var newGame = new Game(newLetterGrid, newListOfWords);
            repository.Save(newGame);

            // When - Then
            Assert.Throws<UnvalidPositionException>(delegate { action.Execute(SomeXPositionWithError, SomeYPositionWithError); });
        }
    }
}


