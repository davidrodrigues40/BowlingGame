using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Dto.Models;

namespace BowlingGame.Services;

public class GameService : IGameService
{
    private readonly IBowlService _bowlService;
    private readonly IGame _game;
    private readonly IScoreCalculator _scoreCalculator;

    public GameService(IScoreCalculator scoreCalculator, IBowlService bowlService)
    {
        _scoreCalculator = scoreCalculator;
        _bowlService = bowlService;
        _game = new Game();
    }

    public IGame NewGame(IEnumerable<IBowler> bowlers)
    {
        try
        {
            _game.Bowlers = bowlers;
            foreach (IBowler item in bowlers)
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

    public IGame PlayGame(IGame game)
    {
        try
        {
            for (int frame = 1; frame <= 10; frame++)
            {
                // play frame
                foreach (IBowler bowler in game.Bowlers)
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

    private void PlayFrame(int frame, IBowler bowler)
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

    private void PlayTenthFrame(int frame, IBowler bowler)
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

    private static void AddRole(IBowler bowler, int frame, int ballNumber, int pinsKnockedDown) => bowler.Frames[frame].Roles[ballNumber] = pinsKnockedDown;
}