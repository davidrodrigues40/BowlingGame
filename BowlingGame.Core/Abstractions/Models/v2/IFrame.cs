namespace BowlingGame.Core.Abstractions.Models.v2;
public interface IFrame
{
    int FrameNumber { get; set; }
    IEnumerable<IRoll> Rolls { get; set; }
    int Score { get; set; }
}
