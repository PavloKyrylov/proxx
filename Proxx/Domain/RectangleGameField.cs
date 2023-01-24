using Proxx.Common;
using Proxx.Domain.Abstract;
using Proxx.Domain.Models;

namespace Proxx.Domain;

public class RectangleGameField : IGameField<TwoDimensionIndex>
{
    private readonly IRandomSequenceGenerator _randomSequenceGenerator;
    private readonly RectangleGameFieldSettings _settings;
    private Cell[][]? _field;

    public RectangleGameField(IRandomSequenceGenerator randomSequenceGenerator, RectangleGameFieldSettings settings)
    {
        _randomSequenceGenerator = randomSequenceGenerator;
        _settings = settings;
    }

    public Cell OpenCell(TwoDimensionIndex index)
    {
        if (_field is null)
        {
            _field = RectangleGameFieldInitializer.Initialize(_randomSequenceGenerator, _settings, index);
        }

        if (!_field.TryGetValue(index, out var cell))
        {
            throw new InvalidOperationException();
        }

        if (cell.IsVisible)
        {
            return cell;
        }

        if (cell.Value == 0)
        {
            OpenZeroCellsNearby(_field, index);
        }
        else
        {
            _field.SetValue(index, cell.ToVisibleCell());
        }

        return _field.GetValue(index);
    }

    public bool AreAllCellsOpened()
    {
        if (_field is null)
        {
            return false;
        }

        return _field
            .EnumerateAllElements()
            .Where(x => !x.Value.IsBlackHole)
            .All(x => x.Value.IsVisible);
    }

    public IEnumerable<(Cell Value, TwoDimensionIndex Index)> Enumerate()
    {
        if (_field is null)
        {
            throw new InvalidOperationException("Field has not been initialized yet");
        }
        return _field.EnumerateAllElements();
    }

    private void OpenZeroCellsNearby(Cell[][] field, TwoDimensionIndex index)
    {
        var indexes = new Stack<TwoDimensionIndex>();
        indexes.Push(index);
        while (indexes.TryPop(out var currentIndex))
        {
            if (field.TryGetValue(currentIndex, out var cell) && cell.IsHidden)
            {
                field.SetValue(currentIndex, cell.ToVisibleCell());
                if (cell.Value == 0)
                {
                    field
                        .EnumerateElementsNearby(currentIndex)
                        .ForEach(x => indexes.Push(x.Index));
                }
            }
        }
    }
}
