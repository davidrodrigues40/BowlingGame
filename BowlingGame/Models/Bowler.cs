using BowlingGame.Abstractions.Models;

namespace BowlingGame.Models
{
    public record Bowler : IBowler
    {
        public string Name { get; set; } = string.Empty;
        public Dictionary<int, IFrame> Frames { get; set; } = new();
        public int Score { get; set; } = 0;

        public Bowler() { }
    }
}
