using BowlingGame.Core.Enums;

namespace BowlingGame.Abstractions.Models;

public interface IRatedBowler : IBowler
{
    BowlerRating Rating { get; set; }
}
