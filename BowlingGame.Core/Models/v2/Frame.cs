using BowlingGame.Core.Abstractions.Models.v2;

namespace BowlingGame.Core.Models.v2;
public record Frame : IFrame
{
    public int FrameNumber { get; set; }
    public IEnumerable<IRoll> Rolls { get; set; } = Enumerable.Empty<IRoll>();
    public int Score { get; set; }
}
