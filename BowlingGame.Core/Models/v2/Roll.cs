using BowlingGame.Core.Abstractions.Models.v2;

namespace BowlingGame.Core.Models.v2;
public record Roll : IRoll
{
    public int? Pins { get; set; } = null;
    public int RollNumber { get; set; }
}
