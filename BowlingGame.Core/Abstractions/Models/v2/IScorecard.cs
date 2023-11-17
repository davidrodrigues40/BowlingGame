namespace BowlingGame.Core.Abstractions.Models.v2;

public interface IScorecard
{
    int BowlerId { get; set; }
    IEnumerable<IFrame> Frames { get; set; }
    int Score { get; set; }
}
