using System.Collections;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public partial class AddWordsServiceShould
    {
        private AddWordsService addWordsService;
        private IWordsRepository wordsRepository;
        private SomeRandomQueuedPositionGenerator ramdomPositionGenerator;
        private IShuffleWordsService shuffleWordsService;

        private static string SomeWord = "SomeWord";

        [SetUp]
        public void Setup()
        {
            wordsRepository = new InMemoryWordsRepository();
           
            ramdomPositionGenerator = new SomeRandomQueuedPositionGenerator();
            shuffleWordsService = new SomeShuffleWordsService();

            addWordsService = new AddWordsService(ramdomPositionGenerator);
        }

        [Test]
        public void Add_Word_Successfully_In_Zero_Position()
        {
            // Given
            var grid = new Grid(new char[10, 10]);
            wordsRepository.Add(new Word("Uno"));
            ramdomPositionGenerator.SetMaxPosition(new Position(10, 10));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 0));

            // When
            var result = addWordsService.AddWords(grid, wordsRepository.GetAll());

            // Then
            PrintGrid.Print(result);
            Assert.IsTrue(result.GetLeterInPosition(0, 0) == 'U');
            Assert.IsTrue(result.GetLeterInPosition(1, 0) == 'n');
            Assert.IsTrue(result.GetLeterInPosition(2, 0) == 'o');
        }


        [Test]
        public void Add_Word_Successfully_In_Random_Position()
        {
            // Given
            var grid = new Grid(new char[10, 10]);
            wordsRepository.Add(new Word("Uno"));
            ramdomPositionGenerator.SetMaxPosition(new Position(10, 10));
            ramdomPositionGenerator.SetReturnPosition(new Position(5, 5));

            // When
            var result = addWordsService.AddWords(grid, wordsRepository.GetAll());

            // Then

            PrintGrid.Print(result);
            Assert.IsTrue(result.GetLeterInPosition(5, 5) == 'U');
            Assert.IsTrue(result.GetLeterInPosition(6, 5) == 'n');
            Assert.IsTrue(result.GetLeterInPosition(7, 5) == 'o');
        }

        [Test]
        public void Add_Words_Successfully_In_Random_Positions()
        {
            // Given
            var grid = new Grid(new char[10, 10]);
            wordsRepository.Add(new Word("Uno"));
            wordsRepository.Add(new Word("Dos"));
            ramdomPositionGenerator.SetMaxPosition(new Position(10, 10));
            ramdomPositionGenerator.SetReturnPosition(new Position(5, 5));
            ramdomPositionGenerator.SetReturnPosition(new Position(5, 6));

            // When
            var result = addWordsService.AddWords(grid, wordsRepository.GetAll());

            // Then
            PrintGrid.Print(result);
            Assert.IsTrue(result.GetLeterInPosition(5, 5) == 'U');
            Assert.IsTrue(result.GetLeterInPosition(6, 5) == 'n');
            Assert.IsTrue(result.GetLeterInPosition(7, 5) == 'o');
            Assert.IsTrue(result.GetLeterInPosition(5, 6) == 'D');
            Assert.IsTrue(result.GetLeterInPosition(6, 6) == 'o');
            Assert.IsTrue(result.GetLeterInPosition(7, 6) == 's');
        }

        [Test]
        public void Repositioning_Word_Wiht_New_Position_When_Space_Have_A_Word_In()
        {
            // Given
            var grid = new Grid(new char[10, 10]);
            wordsRepository.Add(new Word("Uno"));
            wordsRepository.Add(new Word("Dos"));
            ramdomPositionGenerator.SetMaxPosition(new Position(10, 10));
            ramdomPositionGenerator.SetReturnPosition(new Position(5, 5));
            ramdomPositionGenerator.SetReturnPosition(new Position(3, 5));

            // When
            var result = addWordsService.AddWords(grid, wordsRepository.GetAll());

            // Then
            PrintGrid.Print(result);
            Assert.IsTrue(result.GetLeterInPosition(5, 5) == 'U');
            Assert.IsTrue(result.GetLeterInPosition(6, 5) == 'n');
            Assert.IsTrue(result.GetLeterInPosition(7, 5) == 'o');
            Assert.IsTrue(result.GetLeterInPosition(0, 6) == 'D');
            Assert.IsTrue(result.GetLeterInPosition(1, 6) == 'o');
            Assert.IsTrue(result.GetLeterInPosition(2, 6) == 's');
            Assert.IsTrue(ramdomPositionGenerator.Count == 0);
        }

        [Test]
        public void Repositioning_Word_Wiht_New_Position_When_Word_Do_Not_Fit_In_Grid()
        {
            // Given
            var grid = new Grid(new char[10, 10]);
            wordsRepository.Add(new Word("Uno"));
            ramdomPositionGenerator.SetMaxPosition(new Position(10, 10));
            ramdomPositionGenerator.SetReturnPosition(new Position(8, 5));

            // When
            var result = addWordsService.AddWords(grid, wordsRepository.GetAll());

            // Then
            PrintGrid.Print(result);
            Assert.IsTrue(result.GetLeterInPosition(0, 6) == 'U');
            Assert.IsTrue(result.GetLeterInPosition(1, 6) == 'n');
            Assert.IsTrue(result.GetLeterInPosition(2, 6) == 'o');
            Assert.IsTrue(ramdomPositionGenerator.Count == 0);
        }

        [Test]
        public void Throw_FullFillGridException_When_Grid_Is_Full()
        {
            // Given
            var grid = new Grid(new char[10, 10]);
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("0123456789"));
            wordsRepository.Add(new Word("error"));
            ramdomPositionGenerator.SetMaxPosition(new Position(10, 10));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 0));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 1));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 2));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 3));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 4));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 5));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 6));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 7));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 8));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 9));
            ramdomPositionGenerator.SetReturnPosition(new Position(9, 9));

            // When - Then
            Assert.Throws<FullFillGridException>(() => { addWordsService.AddWords(grid, wordsRepository.GetAll()); } );
        }
    }
}
