using BowlingGame.Core.Enums;

namespace BowlingGame.Abstractions.Models;

public interface IRatedPlayer : IPlayer
{
    BowlerRating Rating { get; set; }
}
