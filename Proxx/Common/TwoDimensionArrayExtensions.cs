namespace Proxx.Common;

internal static class TwoDimensionArrayExtensions
{
    internal static int ToSingleDimensionIndex(this TwoDimensionIndex index, int height) => index.Y * height + index.X;

    internal static TwoDimensionIndex ToTwoDimensionIndex(this int singleDimensionIndex, int height) => new(singleDimensionIndex % height, singleDimensionIndex / height);

    internal static bool TryGetValue<TValue>(this TValue[][] array, TwoDimensionIndex index, out TValue value)
        where TValue : struct
    {
        if (array.IsValidIndex(index))
        {
            var (xIndex, yIndex) = index;
            value = array[yIndex][xIndex];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    internal static TValue GetValue<TValue>(this TValue[][] array, TwoDimensionIndex index)
        where TValue : struct
    {
        var (xIndex, yIndex) = index;
        return array[yIndex][xIndex];
    }

    internal static void SetValue<TValue>(this TValue[][] array, TwoDimensionIndex index, TValue value)
        where TValue : struct
    {
        var (xIndex, yIndex) = index;
        array[yIndex][xIndex] = value;
    }

    internal static IEnumerable<(TValue Value, TwoDimensionIndex Index)> EnumerateAllElements<TValue>(this TValue[][] array)
        where TValue : struct
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                yield return (array[i][j], new TwoDimensionIndex(j, i));
            }
        }
    }

    internal static IEnumerable<(TValue Value, TwoDimensionIndex Index)> EnumerateElementsNearby<TValue>(this TValue[][] array, TwoDimensionIndex index)
        where TValue : struct
    {
        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                var currentIndex = index with { X = index.X + j, Y = index.Y + i };
                if (array.IsValidIndex(currentIndex))
                {
                    yield return (array[currentIndex.Y][currentIndex.X], currentIndex);
                }
            }
        }
    }

    private static bool IsValidIndex<TValue>(this TValue[][] array, TwoDimensionIndex index)
        where TValue : struct
    {
        var (xIndex, yIndex) = index;
        return yIndex >= 0 && yIndex <= array.Length - 1 && xIndex >= 0 && xIndex <= array[yIndex].Length - 1;
    }
}
