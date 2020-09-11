using System;
using UnityEngine;

namespace Tests
{
    public static class PrintGrid
    {
        public static void Print(DataGrid dataGrid)
        {
            string log = string.Empty;

            for (int x = -1; x < dataGrid.Wight; x++)
            {
                if(x == -1)
                {
                    log += "--";
                    continue;
                }

                log += " " + x + "  ";
            }

            Debug.Log("   " + log);

            for (int y = 0; y < dataGrid.Height; y++)
            {
                log = string.Empty;

                for (int x = 0; x < dataGrid.Wight; x++)
                {
                    char charToPrint = dataGrid.GetLeterInPosition(x, y);

                    if (charToPrint == '\0')
                        charToPrint = '_';

                    log += "(" + charToPrint + ") ";
                }

                Debug.Log(y + ". " + log);
            }
        }


    }
}


