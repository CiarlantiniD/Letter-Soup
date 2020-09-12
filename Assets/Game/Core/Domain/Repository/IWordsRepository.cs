using System.Collections.Generic;

public interface IWordsRepository
{
    void Add(Word word);
    List<Word> GetAll();
}
