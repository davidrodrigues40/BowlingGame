using BowlingGame.Core.Enums;

namespace BowlingGame.Core.Abstractions.Models;

public interface IBowler
{
    string Name { get; set; }
    Dictionary<int, IFrame> Frames { get; set; }
    int Score { get; set; }
    BowlerRating Rating { get; set; }
}
