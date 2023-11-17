using BowlingGame.Core.Abstractions.Models;

namespace BowlingGame.Core.Models;

public record Frame : IFrame
{
    public Dictionary<int, int> Rolls { get; set; } = new();
    public int Score { get; set; } = 0;
}