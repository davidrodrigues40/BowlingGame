using BowlingGame.Core.Abstractions.Models;

namespace BowlingGame.Core.Abstractions.Services;

public interface IScoreCalculator
{
    void CalculateScore(IGame game);
    Dictionary<int, IFrame> ClearScoreSheet();
}