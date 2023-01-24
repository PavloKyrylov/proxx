using Proxx.Common;
using Proxx.Domain.Abstract;
using Proxx.Domain.Models;

namespace Proxx.Domain;

public static class GameRunner
{
    public static void RunGameWithSquareField(IGameIO<SquareGameFieldSettings, TwoDimensionIndex> gameIO)
    {
        var randomSequenceGenerator = new RandomSequenceGenerator();
        RunGame(gameIO, x => new SquareGameField(randomSequenceGenerator, x));
    }

    public static void RunGame<TGameFieldSettings, TIndex>(IGameIO<TGameFieldSettings, TIndex> gameIO, Func<TGameFieldSettings, IGameField<TIndex>> gameFieldFactory)
        where TGameFieldSettings : IGameFieldSettings
        where TIndex : IIndex
    {
        var settings = gameIO.InitializeGame();
        var gameEngine = new GameEngine<TIndex>(gameFieldFactory(settings));

        MoveResult<TIndex> moveResult;
        do
        {
            moveResult = gameEngine.MakeMove(gameIO.GetMoveCoordinates());
            gameIO.ShowMove(moveResult);
        }
        while (moveResult.GameStatus == GameStatus.InProgress);
    }
}
