using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Enums;

namespace BowlingGame.Core.Models;

public record Player : IPlayer
{
    public string Name { get; set; } = string.Empty;
    public BowlerRating Rating { get; set; }
}
