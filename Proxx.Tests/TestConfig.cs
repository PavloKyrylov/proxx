using Proxx.Common;
using Proxx.Domain.Models;

namespace Proxx.Tests;

public record TestConfig(int Size, int[] BlackHoles, TwoDimensionIndex[] Moves, bool IsSucceed, (Cell, TwoDimensionIndex)[][] ExpectedMoveResults);
