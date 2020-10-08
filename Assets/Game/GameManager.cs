using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LetterGridWidget letterGridWidget;
    [SerializeField] private ShowGameWords showGameWordsWidget;

    private ServiceProvider serviceProvider;
    private RepositoryProvider repositoryProvider;
    private ActionsProvider actionsProvider;

    void Start()
    {
        Logger.SetProvider(new UnityLogger());
        repositoryProvider = new RepositoryProvider();
        serviceProvider = new ServiceProvider();
        actionsProvider = new ActionsProvider();

        //RepositoryProvider.WordsRepository.Add(new Word("alfa"));
        //RepositoryProvider.WordsRepository.Add(new Word("beta"));
        //RepositoryProvider.WordsRepository.Add(new Word("gamma"));
        //RepositoryProvider.WordsRepository.Add(new Word("delta"));
        //RepositoryProvider.WordsRepository.Add(new Word("epsilon"));

        RepositoryProvider.WordsRepository.Add(new Word("rayo"));
        RepositoryProvider.WordsRepository.Add(new Word("finanzas"));
        RepositoryProvider.WordsRepository.Add(new Word("marciano"));
        RepositoryProvider.WordsRepository.Add(new Word("critico"));
        RepositoryProvider.WordsRepository.Add(new Word("norte"));

        ActionsProvider.GenerateNewGameAction.Execute(12, 12, 5);
        letterGridWidget.Load();
        showGameWordsWidget.Load(ActionsProvider.GetGameWordsAction.Execute());
    }
}
