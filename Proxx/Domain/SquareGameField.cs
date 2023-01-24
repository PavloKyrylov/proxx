﻿using Proxx.Common;
using Proxx.Domain.Models;

namespace Proxx.Domain;

public class SquareGameField : RectangleGameField
{
    public SquareGameField(IRandomSequenceGenerator randomSequenceGenerator, SquareGameFieldSettings settings) : base(randomSequenceGenerator, settings)
    {
    }
}
