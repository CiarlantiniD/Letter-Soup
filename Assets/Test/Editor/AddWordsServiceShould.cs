using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class AddWordsServiceShould
    {
        private AddWordsService addWordsService;
        private Words wordsRepository;
        private SomeRandomPositionGenerator ramdomPositionGenerator;
        private IShuffleWordsService shuffleWordsService;

        [SetUp]
        public void Setup()
        {
            wordsRepository = new InMemoryWordsRepository();
           
            ramdomPositionGenerator = new SomeRandomPositionGenerator();
            shuffleWordsService = new SomeShuffleWordsService();

            addWordsService = new AddWordsService(wordsRepository, ramdomPositionGenerator, shuffleWordsService);
        }

        [Test]
        public void Add_Word_Successfully_In_Zero_Position()
        {
            // Given
            var grid = new DataGrid(new char[10, 10]);
            wordsRepository.Add(new Word("Uno"));
            ramdomPositionGenerator.SetMaxPosition(new Position(10, 10));
            ramdomPositionGenerator.SetReturnPosition(new Position(0, 0));

            // When
            var result = addWordsService.AddWords(grid, 1);

            // Then
            PrintGrid(result);
            Assert.IsTrue(result.GetLeterInPosition(0, 0) == 'U');
            Assert.IsTrue(result.GetLeterInPosition(1, 0) == 'n');
            Assert.IsTrue(result.GetLeterInPosition(2, 0) == 'o');
        }


        [Test]
        public void Add_Word_Successfully_In_Random_Position()
        {
            // Given
            var grid = new DataGrid(new char[10, 10]);
            wordsRepository.Add(new Word("Uno"));
            ramdomPositionGenerator.SetMaxPosition(new Position(10, 10));
            ramdomPositionGenerator.SetReturnPosition(new Position(5, 5));

            // When
            var result = addWordsService.AddWords(grid, 1);

            // Then
            PrintGrid(result);
            Assert.IsTrue(result.GetLeterInPosition(5, 5) == 'U');
            Assert.IsTrue(result.GetLeterInPosition(6, 5) == 'n');
            Assert.IsTrue(result.GetLeterInPosition(7, 5) == 'o');
        }

        private void PrintGrid(DataGrid dataGrid)
        {
            string log = string.Empty;

            for (int x = -1; x < dataGrid.Wight; x++)
            {
                if(x == -1)
                {
                    log += "--";
                    continue;
                }

                log += " " + x + "  ";
            }

            Debug.Log("   " + log);

            for (int y = 0; y < dataGrid.Height; y++)
            {
                log = string.Empty;

                for (int x = 0; x < dataGrid.Wight; x++)
                {
                    char charToPrint = dataGrid.GetLeterInPosition(x, y);

                    if (charToPrint == '\0')
                        charToPrint = '_';

                    log += "(" + charToPrint + ") ";
                }

                Debug.Log(y + ". " + log);
            }
        }


        private void AddWordsToMemory()
        {
            wordsRepository.Add(new Word("Uno"));
            wordsRepository.Add(new Word("Dos"));
            wordsRepository.Add(new Word("Tres"));
            wordsRepository.Add(new Word("Cuatro"));
            wordsRepository.Add(new Word("Cinco"));
            wordsRepository.Add(new Word("Seis"));
            wordsRepository.Add(new Word("Siete"));
            wordsRepository.Add(new Word("Ocho"));
            wordsRepository.Add(new Word("Nueve"));
            wordsRepository.Add(new Word("Diez"));
        }



        public class SomeRandomPositionGenerator : IRamdomPositionGenerator
        {
            private Position position;
            private Position maxPosition;

            public Position GetRandomPosition()
            {
                return position;
            }

            public void SetMaxPosition(Position position)
            {
                maxPosition = position;
            }

            public void SetReturnPosition(Position position)
            {
                if (position.x > maxPosition.x || position.y > maxPosition.y)
                    throw new System.Exception("Posicion invalida");

                this.position = position;
            }
        }

        public class SomeShuffleWordsService : IShuffleWordsService
        {
            public List<Word> Shuffle(List<Word> words)
            {
                return words;
            }
        }
    }
}
