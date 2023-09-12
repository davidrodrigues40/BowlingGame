using BowlingGame.Models;

namespace BowlingGame.Abstractions.Models
{
    public interface IBowler
    {
        string Name { get; set; }
        Dictionary<int, IFrame> Frames { get; set; }
        int Score { get; set; }
    }
}
