using Proxx.Common;
using Proxx.Domain.Models;

namespace Proxx.Domain.Abstract;

public interface IGameEngine<TIndex>
    where TIndex : IIndex
{
    MoveResult<TIndex> MakeMove(TIndex index);
}
