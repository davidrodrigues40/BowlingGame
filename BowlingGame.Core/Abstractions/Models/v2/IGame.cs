namespace BowlingGame.Core.Abstractions.Models.v2;

public interface IGame
{
    Guid Id { get; set; }
    IEnumerable<IBowler> Bowlers { get; set; }
    IEnumerable<IScorecard> Scorecards { get; set; }
}