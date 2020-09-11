using System.Collections.Generic;

namespace Tests
{
    public class SomeShuffleWordsService : IShuffleWordsService
    {
        public List<Word> Shuffle(List<Word> words)
        {
            return words;
        }
    }
}
