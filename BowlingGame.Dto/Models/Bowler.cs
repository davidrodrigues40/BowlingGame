using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Enums;

namespace BowlingGame.Dto.Models;
public record Bowler : IBowler
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<int, IFrame> Frames { get; set; } = new();
    public int Score { get; set; } = 0;
    public BowlerRating Rating { get; set; } = BowlerRating.Beginner;

    public Bowler() { }
}
