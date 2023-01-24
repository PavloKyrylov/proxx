using Proxx.Common;
using Proxx.Domain;
using Proxx.Domain.Models;

namespace Proxx.Tests;

internal class FakeGameIO : IGameIO<SquareGameFieldSettings, TwoDimensionIndex>
{
    private readonly int _size;
    private readonly int _blackHoleCount;
    private readonly Queue<TwoDimensionIndex> _moveQueue;

    public List<(GameStatus GameStatus, int MoveCount, (Cell Value, TwoDimensionIndex Index)[] GameField)> MoveResultList { get; } = new();

    public FakeGameIO(int size, int blackHoleCount, Queue<TwoDimensionIndex> moveQueue)
    {
        _size = size;
        _blackHoleCount = blackHoleCount;
        _moveQueue = moveQueue;
    }

    public SquareGameFieldSettings InitializeGame() => new SquareGameFieldSettings(_size, _blackHoleCount);

    public TwoDimensionIndex GetMoveCoordinates() => _moveQueue.Dequeue();

    public void ShowMove(MoveResult<TwoDimensionIndex> moveResult)
    {
        MoveResultList.Add((moveResult.GameStatus, moveResult.MoveCount, moveResult.GameField.Enumerate().ToArray()));
    }
}
