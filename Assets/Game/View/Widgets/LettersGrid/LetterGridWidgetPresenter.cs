using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGridWidgetPresenter
{
    private readonly ILetterGridWidget view;

    public LetterGridWidgetPresenter(ILetterGridWidget view)
    {
        this.view = view;
    }

    public void Load()
    {
        char[,] data = new char[12,12]
        {
            {'q','w','e','r','t','y','u','i','o','p','a','s' },
            {'s','d','f','g','h','j','k','l','ñ','z','x','c' },
            {'v','b','m','q','g','s','e','t','w','s','q','g' },
            {'u','s','f','w','d','s','e','s','f','y','w','d' },
            {'q','w','e','r','t','y','u','i','o','p','a','s' },
            {'s','d','f','g','h','j','k','l','ñ','z','x','c' },
            {'v','b','m','q','g','s','e','t','w','s','q','g' },
            {'u','s','f','w','d','s','e','s','f','y','w','d' },
            {'q','w','e','r','t','y','u','i','o','p','a','s' },
            {'s','d','f','g','h','j','k','l','ñ','z','x','c' },
            {'v','b','m','q','g','s','e','t','w','s','q','g' },
            {'u','s','f','w','d','s','e','s','f','y','w','d' }
        };

        view.SetGrid(new DataGrid(data));
    }
}
