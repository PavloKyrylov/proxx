using Proxx.Common;
using Proxx.Domain.Models;

namespace Proxx.Domain.Abstract;

public interface IGameField<TIndex>
    where TIndex : IIndex
{
    Cell OpenCell(TIndex index);

    bool AreAllCellsOpened();

    IEnumerable<(Cell Value, TIndex Index)> Enumerate();
}
