using Proxx.Domain.Abstract;

namespace Proxx.Domain.Models;

public class RectangleGameFieldSettings : IGameFieldSettings
{
    private const int _minFieldSizeAndBlackHoleDifference = 9;

    public int Width { get; }

    public int Height { get; }

    public int BlackHoleCount { get; }

    public RectangleGameFieldSettings(int width, int height, int blackHoleCount)
    {
        if (width <= 3)
        {
            throw new ArgumentOutOfRangeException(nameof(width));
        }
        if (height <= 3)
        {
            throw new ArgumentOutOfRangeException(nameof(height));
        }
        if (blackHoleCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(blackHoleCount));
        }
        if (width * height - blackHoleCount <= _minFieldSizeAndBlackHoleDifference)
        {
            throw new ArgumentException($"Black hole count must be less than field size plus {_minFieldSizeAndBlackHoleDifference}.");
        }
        Width = width;
        Height = height;
        BlackHoleCount = blackHoleCount;
    }

    public void Deconstruct(out int width, out int height, out int blackHoleCount)
    {
        width = Width;
        height = Height;
        blackHoleCount = BlackHoleCount;
    }
}
