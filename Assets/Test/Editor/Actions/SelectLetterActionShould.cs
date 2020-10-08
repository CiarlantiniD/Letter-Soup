using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class SelectLetterActionShould
    {
       // private SelectLetterAction selectLetter;
       // private IGameService gameService;

       // private static int SomeXPosition = 4;
       // private static int SomeYPosition = 5;

       // private static int SomeMaxXPosition = 10;
       // private static int SomeMaxYPosition = 10;

       // private readonly char [,] SomeCharArray = new char[10, 10]
       //     {
       //         {'x','x','x','x','x','x','x','x','x','x' },
       //         {'x','x','x','x','x','x','x','x','x','x' },
       //         {'x','x','x','x','x','x','x','x','x','x' },
       //         {'x','x','x','x','x','x','x','x','x','x' },
       //         {'x','x','x','x','x','x','x','x','x','x' },
       //         {'x','x','x','x','x','x','x','x','x','x' },
       //         {'x','x','x','x','x','x','x','x','x','x' },
       //         {'x','x','x','x','x','x','x','x','x','x' },
       //         {'x','x','x','x','x','x','x','x','x','x' },
       //         {'x','x','x','x','x','x','x','x','x','x' }
       //     };

       // [SetUp]
       // public void Setup()
       // {
       //     Logger.SetProvider(new UnityLogger());
       //     gameService = new GameService();
       //     selectLetter = new SelectLetterAction(gameService);
       // }

       // [Test]
       // public void Save_Selected_Position()
       // {
       //     // Given
       //     var newLetterGrid = new Grid(new char[10, 10]);
       //     var newListOfWords = new Dictionary<Word,List<Position>>();
       //     var newGame = new GridWithLetters(newLetterGrid, newListOfWords);
       //     gameService.SetNewGame(newGame);

       //     // When
       //     var resutl = selectLetter.Execute(SomeXPosition, SomeYPosition);

       //     // Then
       //     Assert.IsTrue(LetterStateType.Selected == resutl.GetState());
       // }

       // [Test]
       // public void Unselected_Position_When_Position_Was_Selected()
       // {
       //     // Given
       //     Position position = new Position(SomeXPosition, SomeYPosition);
       //     var newLetterGrid = new Grid(new char[10, 10]);
       //     var newListOfWords = new Dictionary<Word, List<Position>>();
       //     var newGame = new GridWithLetters(newLetterGrid, newListOfWords);
       //     gameService.SetNewGame(newGame);

       //     // When
       //     selectLetter.Execute(SomeXPosition, SomeYPosition);
       //     var resutl = selectLetter.Execute(SomeXPosition, SomeYPosition);

       //     // Then
       //     Assert.IsTrue(LetterStateType.Unselected == resutl.GetState());
       // }

       // [Test]
       // public void Save_Selected_Position_When_Was_Select_Unselected_And_Selected_Again()
       // {
       //     // Given
       //     Position position = new Position(SomeXPosition, SomeYPosition);
       //     var newLetterGrid = new Grid(new char[10, 10]);
       //     var newListOfWords = new Dictionary<Word, List<Position>>();
       //     var newGame = new GridWithLetters(newLetterGrid, newListOfWords);
       //     gameService.SetNewGame(newGame);

       //     // When
       //     selectLetter.Execute(SomeXPosition, SomeYPosition);
       //     selectLetter.Execute(SomeXPosition, SomeYPosition);
       //     var resutl = selectLetter.Execute(SomeXPosition, SomeYPosition);

       //     // Then
       //     Assert.IsTrue(LetterStateType.Selected == resutl.GetState());
       // }

       // [Test]
       // public void Throw_UnvalidPositionException_When_Position_Is_Higher_Than_Max_Of_Grid()
       // {
       //     // Given
       //     var SomeXPositionWithError = SomeMaxXPosition + 1;
       //     var SomeYPositionWithError = SomeMaxYPosition + 1;
       //     var newLetterGrid = new Grid(new char[SomeMaxXPosition, SomeMaxYPosition]);
       //     var newListOfWords = new Dictionary<Word, List<Position>>();
       //     var newGame = new GridWithLetters(newLetterGrid, newListOfWords);
       //     gameService.SetNewGame(newGame);

       //     // When - Then
       //     Assert.Throws<UnvalidPositionException>(delegate { selectLetter.Execute(SomeXPositionWithError, SomeYPositionWithError); } );
       //}

       // [Test]
       // public void Throw_UnvalidPositionException_When_Position_Is_Lower_Than_Zero()
       // {
       //     // Given
       //     var SomeXPositionWithError = -1;
       //     var SomeYPositionWithError = -1;
       //     var newLetterGrid = new Grid(new char[SomeMaxXPosition, SomeMaxYPosition]);
       //     var newListOfWords = new Dictionary<Word, List<Position>>();
       //     var newGame = new GridWithLetters(newLetterGrid, newListOfWords);
       //     gameService.SetNewGame(newGame);

       //     // When - Then
       //     Assert.Throws<UnvalidPositionException>(delegate { selectLetter.Execute(SomeXPositionWithError, SomeYPositionWithError); });
       // }

       // [Test]
       // public void Cancel_Unselect_When_Word_Was_Full_Selected()
       // {
       //     // Given
       //     Position position = new Position(0, 0);
       //     var charArray = SomeCharArray;
       //     charArray[0, 0] = 'p';
       //     charArray[1, 0] = 'r';
       //     charArray[2, 0] = 'u';
       //     charArray[3, 0] = 'e';
       //     charArray[4, 0] = 'b';
       //     charArray[5, 0] = 'a';

       //     var newLetterGrid = new Grid(charArray);
       //     var newListOfWords = new Dictionary<Word, List<Position>>();
       //     var newGame = new GridWithLetters(newLetterGrid, newListOfWords);
       //     gameService.SetNewGame(newGame);

       //     // When
       //     selectLetter.Execute(0, 0);
       //     selectLetter.Execute(1, 0);
       //     selectLetter.Execute(2, 0);
       //     selectLetter.Execute(3, 0);
       //     selectLetter.Execute(4, 0);
       //     selectLetter.Execute(5, 0);
       //     var resutl = selectLetter.Execute(0, 0);

       //     // Then
       //     Assert.IsTrue(LetterStateType.Selected == resutl.GetState());
       // }
    }
}


