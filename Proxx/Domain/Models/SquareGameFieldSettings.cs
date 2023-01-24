namespace Proxx.Domain.Models;

public class SquareGameFieldSettings : RectangleGameFieldSettings
{
    public SquareGameFieldSettings(int size, int blackHoleCount) : base(size, size, blackHoleCount)
    {
    }
}
