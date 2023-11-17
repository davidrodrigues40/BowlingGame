using BowlingGame.Core.Abstractions.Models.v2;
using BowlingGame.Core.Enums;

namespace BowlingGame.Core.Models.v2;
public record Bowler : IBowler
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public BowlerRating Rating { get; set; }
}
