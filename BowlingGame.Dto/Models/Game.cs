using BowlingGame.Abstractions.Models;

namespace BowlingGame.Dto.Models;

public class Game<T> : IGame<T>
{
    public IEnumerable<T> Bowlers { get; set; } = new List<T>();
    public IScoreCard? Winner { get; set; }
}