using BowlingGame.Abstractions.Models;

namespace BowlingGame.Dto.Models;

public record ScoreCard : IScoreCard
{
    public string Name { get; set; } = string.Empty;
    public int Score { get; set; } = 0;
}
