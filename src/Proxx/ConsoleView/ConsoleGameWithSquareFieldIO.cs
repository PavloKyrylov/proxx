using Proxx.Common;
using Proxx.Domain;
using Proxx.Domain.Abstract;
using Proxx.Domain.Models;

namespace Proxx.ConsoleView;

internal class ConsoleGameWithSquareFieldIO : IGameIO<SquareGameFieldSettings, TwoDimensionIndex>
{
    public SquareGameFieldSettings InitializeGame()
    {
        Console.WriteLine("PLease input the size of square:");
        var size = ReadInt();
        Console.WriteLine("PLease input the count of black holes:");
        var blackHoleCount = ReadInt();
        PrintGameWithEmptyField(size);
        return new SquareGameFieldSettings(size, blackHoleCount);
    }

    public TwoDimensionIndex GetMoveCoordinates()
    {
        Console.WriteLine("PLease input click coordinates in format \"YCoordinate XCoordinate\":");
        return ReadTwoDimensionIndex();
    }

    public void ShowMove(MoveResult<TwoDimensionIndex> moveResult)
    {
        var (gameStatus, moveCount, gameField) = moveResult;
        PrintGameField(gameField);
        Console.WriteLine($"Move count: {moveCount}. Game status: {gameStatus}");
    }

    private void PrintGameField(IGameField<TwoDimensionIndex> gameField, bool showHiddenCells = false)
    {
        foreach (var row in gameField.Enumerate().GroupBy(x => x.Index.Y).OrderBy(x => x.Key))
        {
            foreach (var (value, _) in row.OrderBy(x => x.Index.X))
            {
                WriteCell(value, showHiddenCells);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private void PrintGameWithEmptyField(int size)
    {
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                WriteCell(Cell.CreateHiddenCell(0), false);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private void WriteCell(Cell cell, bool showHiddenCells)
    {
        Console.Write($"| {(cell.IsHidden && !showHiddenCells ? "*" : cell.Value == CellValue.BlackHole ? "H" : cell.Value.ToString())} ");
    }

    private int ReadInt()
    {
        var input = Console.ReadLine();
        if (input is null)
        {
            throw new InvalidOperationException("Input is empty");
        }
        return int.TryParse(input, out var result) ? result : throw new InvalidOperationException("Input is invalid");
    }

    private TwoDimensionIndex ReadTwoDimensionIndex()
    {
        var input = Console.ReadLine();
        if (input is null)
        {
            throw new InvalidOperationException("Input is empty");
        }
        var inputArray = input.Split(" ");
        if (inputArray.Length != 2)
        {
            throw new InvalidOperationException("Input is invalid");
        }
        if (!(int.TryParse(inputArray[0], out var y) && int.TryParse(inputArray[1], out var x)))
        {
            throw new InvalidOperationException("Input is invalid");
        }
        return new TwoDimensionIndex(x, y);
    }
}
