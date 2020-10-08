using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GetGameWordsAction
{
    private readonly IGameService gameService;

    public GetGameWordsAction(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public List<Word> Execute()
    {
        return gameService.Grid.Words.Keys.ToList();
    }
}
