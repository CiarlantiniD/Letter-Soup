using System;
using System.Collections.Generic;

public class ShuffleWordsService : IShuffleWordsService
{
    private static Random rng = new Random();

    public List<Word> Shuffle(List<Word> words)
    {
        int n = words.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = words[k];
            words[k] = words[n];
            words[n] = value;
        }
        return words;
    }
}

