namespace BowlingGame.Abstractions.Models;

public interface IScoreCard
{
    string Name { get; set; }
    int Score { get; set; }
}
