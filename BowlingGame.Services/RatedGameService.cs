using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Dto.Models;

namespace BowlingGame.Services;

public class RatedGameService : IGameService<IRatedBowler>
{
    private readonly IBowlService _bowlService;
    private readonly IGame<IRatedBowler> _game;
    private readonly IScoreCalculator _scoreCalculator;

    public RatedGameService(IScoreCalculator scoreCalculator, IBowlService bowlService)
    {
        _scoreCalculator = scoreCalculator;
        _bowlService = bowlService;
        _game = new Game<IRatedBowler>();
    }

    public IGame<IRatedBowler> NewGame(IEnumerable<IRatedBowler> bowlers)
    {
        try
        {
            _game.Bowlers = bowlers;
            foreach (IRatedBowler item in bowlers)
            {
                item.Frames = _scoreCalculator.ClearScoreSheet();
                item.Score = 0;
            }

            return _game;
        }
        catch (Exception)
        {
            // TODO: log exception
            throw;
        }
    }

    public IGame<IRatedBowler> PlayGame(IGame<IRatedBowler> game)
    {
        try
        {
            for (int frame = 1; frame <= 10; frame++)
            {
                // play frame
                foreach (IRatedBowler bowler in game.Bowlers)
                {
                    PlayFrame(frame, bowler);
                }
            }

            _scoreCalculator.CalculateScore(game);

            return game;
        }
        catch (Exception)
        {
            // TODO: log exception
            throw;
        }
    }

    private void PlayFrame(int frame, IRatedBowler bowler)
    {
        if (frame == 10)
        {
            PlayTenthFrame(frame, bowler);
            return;
        }

        int firstBallPinCount = _bowlService.RollFirstBall(bowler.Rating);
        AddRole(bowler, frame, 1, firstBallPinCount);

        if (firstBallPinCount == 10 && frame < 10)
        {
            return;
        }

        int secondBallPinCount = _bowlService.RollSecondBall(firstBallPinCount, bowler.Rating);

        AddRole(bowler, frame, 2, secondBallPinCount);
    }

    private void PlayTenthFrame(int frame, IRatedBowler bowler)
    {
        int firstBallPinCount = _bowlService.RollFirstBall(bowler.Rating);
        int secondBallPinCount;
        int? thirdBallPinCount = null;

        AddRole(bowler, frame, 1, firstBallPinCount);

        secondBallPinCount = firstBallPinCount == 10
            ? _bowlService.RollFirstBall(bowler.Rating)
            : _bowlService.RollSecondBall(firstBallPinCount, bowler.Rating);

        AddRole(bowler, frame, 2, secondBallPinCount);

        if (secondBallPinCount == 10) // strike on second ball
            thirdBallPinCount = _bowlService.RollFirstBall(bowler.Rating);
        else if (firstBallPinCount + secondBallPinCount >= 10) // spare
            thirdBallPinCount = _bowlService.RollFirstBall(bowler.Rating);

        if (thirdBallPinCount.HasValue)
            AddRole(bowler, frame, 3, (int)thirdBallPinCount);

    }

    private static void AddRole(IRatedBowler bowler, int frame, int ballNumber, int pinsKnockedDown) => bowler.Frames[frame].Roles[ballNumber] = pinsKnockedDown;
}