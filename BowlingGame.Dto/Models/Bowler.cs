using BowlingGame.Core.Abstractions.Models;

namespace BowlingGame.Dto.Models;
public record Bowler : Player, IBowler
{
    public Dictionary<int, IFrame> Frames { get; set; } = new();
    public int Score { get; set; } = 0;
}