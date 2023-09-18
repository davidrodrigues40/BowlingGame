using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services;

public interface IScoreCalculator
{
	void CalculateScore(IGame<IBowler> game);
	void CalculateScore(IGame<IRatedBowler> game);
}