using BowlingGame.Abstractions.Models;

namespace BowlingGame.Dto.Models;

public record Game : IGame
{
    public IEnumerable<IBowler> Bowlers { get; set; } = new List<IBowler>();
    public IScoreCard? Winner { get; set; }
}