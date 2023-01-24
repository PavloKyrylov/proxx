using FluentAssertions;
using NUnit.Framework;
using Proxx.Common;
using Proxx.Domain;
using Proxx.Domain.Models;

namespace Proxx.Tests;

[TestFixture]
public class GameRunnerTestCase
{
    private static readonly object[] _testConfigs = new[]
    {
        new TestConfig(
            Size: 4,
            BlackHoles: new[] { 0, 1, 2, 3 },
            Moves: new[] { new TwoDimensionIndex(3, 3) },
            IsSucceed: true,
            ExpectedMoveResults: new[]
            {
                new[]
                {
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(0, 0)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(1, 0)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(2, 0)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 0)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(0, 1)),
                    (new Cell(3, CellState.Visible), new TwoDimensionIndex(1, 1)),
                    (new Cell(3, CellState.Visible), new TwoDimensionIndex(2, 1)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(3, 1)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 2)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 2)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(2, 2)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(3, 2)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 3)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 3)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(2, 3)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(3, 3))
                }
            }),
        new TestConfig(
            Size: 4,
            BlackHoles: new[] { 0, 1, 2, 3 },
            Moves: new[] { new TwoDimensionIndex(1, 1), new TwoDimensionIndex(1, 3), new TwoDimensionIndex(2, 3), new TwoDimensionIndex(3, 3) },
            IsSucceed: true,
            ExpectedMoveResults: new[]
            {
                new[]
                {
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 0)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 0)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 1)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 1)),
                    (new Cell(3, CellState.Visible), new TwoDimensionIndex(2, 1)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 1)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(0, 2)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(1, 2)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(0, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(1, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(2, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(3, 3))
                },
                new[]
                {
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 0)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 0)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 1)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 1)),
                    (new Cell(3, CellState.Visible), new TwoDimensionIndex(2, 1)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 1)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(0, 2)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(1, 2)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(0, 3)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(1, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(2, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(3, 3))
                },
                new[]
                {
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 0)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 0)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 1)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 1)),
                    (new Cell(3, CellState.Visible), new TwoDimensionIndex(2, 1)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 1)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(0, 2)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(1, 2)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(0, 3)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(1, 3)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(2, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(3, 3))
                },
                new[]
                {
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 0)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 0)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 1)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 1)),
                    (new Cell(3, CellState.Visible), new TwoDimensionIndex(2, 1)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 1)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(0, 2)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(1, 2)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(0, 3)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(1, 3)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(2, 3)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(3, 3))
                },
            }),
         new TestConfig(
            Size: 4,
            BlackHoles: new[] { 0, 1, 2, 3 },
            Moves: new[] { new TwoDimensionIndex(1, 1), new TwoDimensionIndex(3, 1) },
            IsSucceed: false,
            ExpectedMoveResults: new[]
            {
                new[]
                {
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 0)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 0)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 1)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 1)),
                    (new Cell(3, CellState.Visible), new TwoDimensionIndex(2, 1)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 1)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(0, 2)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(1, 2)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(0, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(1, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(2, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(3, 3))
                },
                new[]
                {
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 0)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 0)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 0)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(0, 1)),
                    (new Cell(0, CellState.Visible), new TwoDimensionIndex(1, 1)),
                    (new Cell(3, CellState.Visible), new TwoDimensionIndex(2, 1)),
                    (new Cell(-1, CellState.Visible), new TwoDimensionIndex(3, 1)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(0, 2)),
                    (new Cell(1, CellState.Visible), new TwoDimensionIndex(1, 2)),
                    (new Cell(2, CellState.Visible), new TwoDimensionIndex(2, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(3, 2)),
                    (new Cell(-1, CellState.Hidden), new TwoDimensionIndex(0, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(1, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(2, 3)),
                    (new Cell(1, CellState.Hidden), new TwoDimensionIndex(3, 3))
                }
            })
    };

    [TestCaseSource(nameof(_testConfigs))]
    public void RunGame_WhenInputParametersAreValid_ShouldRunGame(TestConfig testConfig)
    {
        //Arrange
        var gameIO = new FakeGameIO(testConfig.Size, testConfig.BlackHoles.Length, new Queue<TwoDimensionIndex>(testConfig.Moves));
        var generatedNumbers = new Stack<int>(testConfig.BlackHoles);
        var randomSequenceGenerator = new RandomSequenceGenerator(x => generatedNumbers.Pop());

        //Act
        GameRunner.RunGame(gameIO, x => new SquareGameField(randomSequenceGenerator, x));

        //Assert
        var actualResult = gameIO.MoveResultList.Select((x, i) => new { x.GameStatus, x.MoveCount, x.GameField });
        var expectedResult = testConfig.ExpectedMoveResults.Select((x, i) => new
        {
            GameStatus = i != testConfig.ExpectedMoveResults.Length - 1 ? GameStatus.InProgress : (testConfig.IsSucceed ? GameStatus.Successed : GameStatus.Failed),
            MoveCount = i + 1,
            GameField = x
        });
        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void RunGame_WhenSizeIsInvalid_ShouldThrowException()
    {
        //Arrange
        var gameIO = new FakeGameIO(3, 1, new Queue<TwoDimensionIndex>());
        var randomSequenceGenerator = new RandomSequenceGenerator(x => 0);

        //Act
        var action = () => GameRunner.RunGame(gameIO, x => new SquareGameField(randomSequenceGenerator, x));

        //Assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void RunGame_WhenBlackHoleCountIsInvalid_ShouldThrowException()
    {
        //Arrange
        var gameIO = new FakeGameIO(4, 0, new Queue<TwoDimensionIndex>());
        var randomSequenceGenerator = new RandomSequenceGenerator(x => 0);

        //Act
        var action = () => GameRunner.RunGame(gameIO, x => new SquareGameField(randomSequenceGenerator, x));

        //Assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void RunGame_WhenBlackHoleIsMoreThanFieldSizePlusTreshhold_ShouldThrowException()
    {
        //Arrange
        var gameIO = new FakeGameIO(4, 10, new Queue<TwoDimensionIndex>());
        var randomSequenceGenerator = new RandomSequenceGenerator(x => 0);

        //Act
        var action = () => GameRunner.RunGame(gameIO, x => new SquareGameField(randomSequenceGenerator, x));

        //Assert
        action.Should().Throw<ArgumentException>();
    }

    [Test]
    public void RunGame_WhenCellCoordinatesAreOutOfRange_ShouldThrowException()
    {
        //Arrange
        var gameIO = new FakeGameIO(4, 4, new Queue<TwoDimensionIndex>(new[] { new TwoDimensionIndex(10, 10) }));
        var randomSequenceGenerator = new RandomSequenceGenerator(x => 0);

        //Act
        var action = () => GameRunner.RunGame(gameIO, x => new SquareGameField(randomSequenceGenerator, x));

        //Assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}
