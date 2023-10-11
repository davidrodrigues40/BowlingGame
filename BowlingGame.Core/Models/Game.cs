using BowlingGame.Core.Abstractions.Models;

namespace BowlingGame.Core.Models;

public record Game : IGame
{
    public IEnumerable<IBowler> Bowlers { get; set; } = new List<IBowler>();
    public IScoreCard? Winner { get; set; }
}