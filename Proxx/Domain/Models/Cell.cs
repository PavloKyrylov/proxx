namespace Proxx.Domain.Models;

public record struct Cell(sbyte Value, CellState State)
{
    public bool IsBlackHole => Value == CellValue.BlackHole;

    public bool IsHidden => State == CellState.Hidden;

    public bool IsVisible => State == CellState.Visible;

    public static Cell CreateHiddenCell(sbyte value) => new(value, CellState.Hidden);

    public static Cell CreateHiddenBlackHoleCell() => new(CellValue.BlackHole, CellState.Hidden);

    public Cell ToVisibleCell()
    {
        if (State == CellState.Visible)
        {
            throw new InvalidOperationException();
        }
        return this with { State = CellState.Visible };
    }
}
