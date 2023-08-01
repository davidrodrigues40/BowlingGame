using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services;

public interface IScoreCalculator
{
	void CalculateScore(IGame game);
}