using Proxx.Common;
using Proxx.Domain.Abstract;

namespace Proxx.Domain.Models;

public record MoveResult<TIndex>(GameStatus GameStatus, int MoveCount, IGameField<TIndex> GameField) where TIndex : IIndex;
