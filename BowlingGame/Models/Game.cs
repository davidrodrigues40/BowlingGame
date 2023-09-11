using BowlingGame.Abstractions.Models;

namespace BowlingGame.Models;

public class Game : IGame
{
    public IEnumerable<IBowler> Bowlers { get; set; } = new List<IBowler>();
    public IScoreCard? Winner { get; set; }
}