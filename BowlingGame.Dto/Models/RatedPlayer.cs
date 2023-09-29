using BowlingGame.Abstractions.Models;
using BowlingGame.Core.Enums;

namespace BowlingGame.Dto.Models;

public record RatedPlayer : Player, IRatedPlayer
{
    public BowlerRating Rating { get; set; }
}
