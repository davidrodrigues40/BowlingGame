namespace BowlingGame.Core.Abstractions.Models.v2;
public interface IRoll
{
    int? Pins { get; set; }
    int RollNumber { get; set; }
}
