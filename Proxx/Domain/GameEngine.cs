using Proxx.Common;
using Proxx.Domain.Abstract;
using Proxx.Domain.Models;

namespace Proxx.Domain;

internal class GameEngine<TIndex> : IGameEngine<TIndex>
    where TIndex : IIndex
{
    private readonly IGameField<TIndex> _gameField;
    private int _moveCount = 0;
    private GameStatus _gameStatus = GameStatus.InProgress;

    public GameEngine(IGameField<TIndex> gameField)
    {
        _gameField = gameField;
    }

    public MoveResult<TIndex> MakeMove(TIndex index)
    {
        EnsureGameIsInProgress(_gameStatus);

        var cell = _gameField.OpenCell(index);
        if (cell.IsBlackHole)
        {
            _gameStatus = GameStatus.Failed;
        }

        if (_gameField.AreAllCellsOpened())
        {
            _gameStatus = GameStatus.Successed;
        }

        _moveCount++;

        return new MoveResult<TIndex>(_gameStatus, _moveCount, _gameField);
    }

    private void EnsureGameIsInProgress(GameStatus gameStatus)
    {
        if (gameStatus != GameStatus.InProgress)
        {
            throw new InvalidOperationException();
        }
    }
}
