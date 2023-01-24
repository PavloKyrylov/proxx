using Proxx.Common;
using Proxx.Domain.Abstract;
using Proxx.Domain.Models;

namespace Proxx.Domain;

public interface IGameIO<TGameFieldSettings, TIndex>
    where TGameFieldSettings : IGameFieldSettings
    where TIndex : IIndex
{
    TGameFieldSettings InitializeGame();

    TIndex GetMoveCoordinates();

    void ShowMove(MoveResult<TIndex> moveResult);
}
