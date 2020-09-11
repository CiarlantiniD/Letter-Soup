using System.Collections;
using System.Collections.Generic;
using System;

public class FillGridService
{
    private readonly Random random = new Random();

    private const char EMPTY_SPACE = '\0';

    private readonly char[] ABC =
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    public DataGrid FillGrid(DataGrid grid)
    {
        char[,] newGrid = grid.Data;

        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Wight; x++)
            {
                if (newGrid[x, y] == EMPTY_SPACE)
                    newGrid[x, y] = ABC[random.Next(0, ABC.Length)];
            }
        }

        return new DataGrid(newGrid);
    }
}
