﻿using BowlingGame.Abstractions.Models;

namespace BowlingGame.Dto.Models;

public record BowlerRatingModel : IBowlerRating
{
    public int Key { get; set; } = 0;
    public string Value { get; set; } = string.Empty;
}
