namespace BowlingGame.Core.Abstractions.Models;

public interface IScoreCard
{
    string Name { get; set; }
    int Score { get; set; }
}
