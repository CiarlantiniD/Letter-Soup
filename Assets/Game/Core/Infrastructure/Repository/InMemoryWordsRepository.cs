using System.Collections.Generic;

public class InMemoryWordsRepository : IWordsRepository
{
    public List<Word> repository = new List<Word>();

    public void Add(Word word)
    {
        repository.Add(word);
    }

    public List<Word> GetAll()
    {
        return repository;
    }
}