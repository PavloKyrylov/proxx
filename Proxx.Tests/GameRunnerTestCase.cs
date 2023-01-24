using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Proxx.Common;
using Proxx.Domain;
using Proxx.Domain.Models;

namespace Proxx.Tests;


[TestFixture]
public class GameRunnerTestCase
{
    [Test]
    public void RunGame_When_Should()
    {
        //Arrange
        var gameIO = new FakeGameIO(4, 4, new Queue<TwoDimensionIndex>(new[] { new TwoDimensionIndex(1, 1) }));
        var randomSequenceGenerator = Substitute.For<IRandomSequenceGenerator>();
        randomSequenceGenerator
            .NextSequence(Arg.Is(16), Arg.Is(4), Arg.Is(new[] { 1, 4, 8, 9 }))
            .Returns(new[] { 1, 2 });

        //Act
        GameRunner.RunGame(gameIO, x => new SquareGameField(randomSequenceGenerator, x));

        //Assert
        gameIO.MoveResultList
            .Select(x => new { x.GameStatus, x.MoveCount, GameField = x.GameField.Enumerate() })
            .Should().BeEquivalentTo(new[]
            {
                new { GameStatus = GameStatus.InProgress, MoveCount = 1, GameField = new TwoDimensionIndex[0] }
            });
    }
}
