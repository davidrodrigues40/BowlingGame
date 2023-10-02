using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Dto.Models;

namespace BowlingGame.Services;

public class GameService : IGameService<IBowler>
{
    private readonly IScoreCalculator _scoreCalculator;
    private readonly IBowlService _bowlService;
    private readonly IEnumerable<IBowler> _bowlers;
    private readonly IGame<IBowler> _game;

    public GameService(IScoreCalculator scoreCalculator, IBowlService bowlService)
    {
        _scoreCalculator = scoreCalculator;
        _bowlService = bowlService;
        _bowlers = new List<IBowler>();
        _game = new Game<IBowler>();
    }

    public IGame<IBowler> NewGame(IEnumerable<IBowler> bowlers)
    {
        _game.Bowlers = bowlers;

        try
        {
            foreach (IBowler item in _game.Bowlers)
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

    public IGame<IBowler> PlayGame(IGame<IBowler> game)
    {
        try
        {
            for (int frame = 1; frame <= 10; frame++)
            {
                PlayFrame(frame, game.Bowlers.ElementAt(0));
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

        int firstBallPinCount = _bowlService.RollFirstBall();
        AddRole(bowler, frame, 1, firstBallPinCount);

        if (firstBallPinCount == 10)
        {
            return;
        }

        int secondBallPinCount = _bowlService.RollSecondBall(firstBallPinCount);

        AddRole(bowler, frame, 2, secondBallPinCount);
    }

    private void PlayTenthFrame(int frame, IBowler bowler)
    {
        int firstBallPinCount = _bowlService.RollFirstBall();
        int secondBallPinCount;
        int? thirdBallPinCount = null;

        AddRole(bowler, frame, 1, firstBallPinCount);

        secondBallPinCount = firstBallPinCount == 10 ? _bowlService.RollFirstBall() : _bowlService.RollSecondBall(firstBallPinCount);

        AddRole(bowler, frame, 2, secondBallPinCount);

        if (secondBallPinCount == 10) // strike on second ball
            thirdBallPinCount = _bowlService.RollFirstBall();
        else if (firstBallPinCount + secondBallPinCount == 10) // spare
            thirdBallPinCount = _bowlService.RollFirstBall();

        if (thirdBallPinCount.HasValue)
            AddRole(bowler, frame, 3, (int)thirdBallPinCount);

    }

    private static void AddRole(IBowler bowler, int frame, int ballNumber, int pinsKnockedDown) => bowler.Frames[frame].Roles[ballNumber] = pinsKnockedDown;
}