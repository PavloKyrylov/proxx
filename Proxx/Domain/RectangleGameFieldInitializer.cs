using Proxx.Common;
using Proxx.Domain.Models;

namespace Proxx;

internal static class RectangleGameFieldInitializer
{
    internal static Cell[][] Initialize(IRandomSequenceGenerator randomSequenceGenerator, RectangleGameFieldSettings settings, TwoDimensionIndex initializationCell)
    {
        var (width, height, blackHoleCount) = settings;
        if (initializationCell.X < 0 || initializationCell.X >= width || initializationCell.Y < 0 || initializationCell.Y >= height)
        {
            throw new ArgumentOutOfRangeException(nameof(initializationCell));
        }

        var field = InitializeField(width, height);
        PopulateBlackHoles(field, blackHoleCount, initializationCell, randomSequenceGenerator);
        PopulateNormalCells(field);
        return field;
    }

    private static Cell[][] InitializeField(int width, int height)
    {
        var field = new Cell[height][];
        for (int i = 0; i < height; i++)
        {
            field[i] = new Cell[width];
        }
        return field;
    }

    private static void PopulateBlackHoles(Cell[][] field, int blackHoleCount, TwoDimensionIndex initializationCell, IRandomSequenceGenerator randomSequenceGenerator)
    {
        var cellsToExclude = field
            .EnumerateElementsNearby(initializationCell)
            .Select(x => x.Index.ToSingleDimensionIndex(field.Length))
            .ToArray();
        randomSequenceGenerator
            .NextSequence(field.Length * field[0].Length, blackHoleCount, cellsToExclude)
            .Select(x => x.ToTwoDimensionIndex(field.Length))
            .ForEach(x => field[x.Y][x.X] = Cell.CreateHiddenBlackHoleCell());
    }

    private static void PopulateNormalCells(Cell[][] field)
    {
        field
            .EnumerateAllElements()
            .Where(x => !x.Value.IsBlackHole)
            .ForEach(x => PopulateNormalCell(field, x.Index));
    }

    private static void PopulateNormalCell(Cell[][] field, TwoDimensionIndex index)
    {
        var blackHoleCount = field
            .EnumerateElementsNearby(index)
            .Count(x => x.Index != index && x.Value.IsBlackHole);
        field[index.Y][index.X] = Cell.CreateHiddenCell((sbyte)blackHoleCount);
    }
}
