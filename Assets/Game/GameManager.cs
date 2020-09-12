using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LetterGridWidget letterGridWidget;

    void Start()
    {
        Word word =  new Word("prueba");
        RepositoryProvider.WordsRepository.Add(word);
        RepositoryProvider.WordsRepository.Add(word);
        RepositoryProvider.WordsRepository.Add(word);
        RepositoryProvider.WordsRepository.Add(word);
        RepositoryProvider.WordsRepository.Add(word);

        ActionsProvider.GenerateNewGameAction.Execute(12, 12, 5);
        letterGridWidget.Load();
    }
}
