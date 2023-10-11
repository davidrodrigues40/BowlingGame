using BowlingGame.Core.Abstractions.Models;

namespace BowlingGame.Core.Models;

public record ScoreCard : IScoreCard
{
    public string Name { get; set; } = string.Empty;
    public int Score { get; set; } = 0;
}
