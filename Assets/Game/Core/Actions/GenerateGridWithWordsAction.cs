using System.Collections;
using System.Collections.Generic;

public class GenerateGridWithWordsAction
{
    private readonly AddWordsService addWordsService;
    private readonly FillGridService fillGridService;

    public GenerateGridWithWordsAction(AddWordsService addWordsService, FillGridService fillGridService)
    {
        this.addWordsService = addWordsService;
        this.fillGridService = fillGridService;
    }

    public DataGrid Execute(int wight, int height, int words)
    {
        DataGrid dataGrid;
        dataGrid = addWordsService.AddWords(new DataGrid(new char[wight,height]), words);
        dataGrid = fillGridService.FillGrid(dataGrid);
        return dataGrid;
    }
}
