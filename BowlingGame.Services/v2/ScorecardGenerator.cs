using BowlingGame.Core.Abstractions.Models.v2;
using BowlingGame.Core.Abstractions.Services.v2;
using BowlingGame.Core.Models.v2;

namespace BowlingGame.Services.v2;
public class ScorecardGenerator : IScorecardGenerator
{
    private readonly Roll _roll = new();
    private readonly List<IRoll> _rolls = new()
    {
       new Roll() { RollNumber = 1 },
       new Roll() { RollNumber = 2 }
    };
    private readonly Frame _frame = new();

    public IScorecard GenerateScorecard(int bowlerId)
    {
        var frames = new List<IFrame>();

        for (var i = 1; i <= 10; i++)
        {
            var frame = _frame with { FrameNumber = i, Rolls = _rolls };

            if (i == 10)
            {
                var newRolls = frame.Rolls.ToList();
                newRolls.Add(_roll with { RollNumber = 3 });
                frame.Rolls = newRolls;
            }

            frames.Add(frame);
        }

        var scoreCard = new ScoreCard
        {
            BowlerId = bowlerId,
            Frames = frames,
            Score = 0
        };

        return scoreCard;
    }
}
