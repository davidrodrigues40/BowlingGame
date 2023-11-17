using BowlingGame.Core.Abstractions.Models.v2;

namespace BowlingGame.Core.Models.v2;

public record Game : IGame
{
    public Guid Id { get; set; }
    public IEnumerable<IBowler> Bowlers { get; set; } = new List<IBowler>();
    public IEnumerable<IScorecard> Scorecards { get; set; } = new List<IScorecard>();
}