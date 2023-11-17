using BowlingGame.Core.Abstractions.Models.v2;

namespace BowlingGame.Core.Models.v2;

public record ScoreCard : IScorecard
{
    public int BowlerId { get; set; }
    public IEnumerable<IFrame> Frames { get; set; } = Enumerable.Empty<IFrame>();
    public int Score { get; set; }
}
