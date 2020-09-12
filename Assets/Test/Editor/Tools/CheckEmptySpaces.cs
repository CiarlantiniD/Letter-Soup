using System;

namespace Tests
{
    public static class CheckEmptySpaces
    {
        public static bool Check(Grid dataGrid)
        {
            for (int y = 0; y < dataGrid.Height; y++)
            {
                for (int x = 0; x < dataGrid.Wight; x++)
                {
                    if (dataGrid.GetLeterInPosition(x, y) == '\0')
                        return false;
                }
            }

            return true;
        }
    }
}