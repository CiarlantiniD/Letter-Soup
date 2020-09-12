using System.Collections;
using System.Collections.Generic;

public static class ActionsProvider
{
    private static ClickLetterAction clickLetterAction;

    public static ClickLetterAction ClickLetterAction => clickLetterAction ?? (clickLetterAction = new ClickLetterAction(new InMemoryPositionSelected()));

}