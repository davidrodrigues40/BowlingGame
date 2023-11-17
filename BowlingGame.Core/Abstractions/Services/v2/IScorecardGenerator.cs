using BowlingGame.Core.Abstractions.Models.v2;

namespace BowlingGame.Core.Abstractions.Services.v2;
public interface IScorecardGenerator
{
    IScorecard GenerateScorecard(int bowlerId);
}
