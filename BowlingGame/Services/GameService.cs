using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Models;

namespace BowlingGame.Services;

public class GameService : IGameService
{
	private readonly IScoreCalculator _scoreCalculator;
	private readonly IBowlService _bowlService;
	private readonly IEnumerable<IBowler> _bowlers;
	private readonly IGame _game;

	public GameService(IScoreCalculator scoreCalculator, IBowlService bowlService)
	{
		_scoreCalculator = scoreCalculator;
		_bowlService = bowlService;
		_bowlers = new List<IBowler>();
		_game = new Game();
	}

	public IGame NewGame(IEnumerable<IBowler> bowlers)
	{
		try
		{
			_game.Bowlers = bowlers;
            foreach (var item in bowlers)
            {
                item.Frames = ClearScoreSheet();
				item.Score = 0;
            }
        }
		catch (Exception)
		{
			// log/handle exception
		}

		return _game;
	}

	public IGame PlayGame(IGame game)
	{
		try
		{
			for (var frame = 1; frame <= 10; frame++)
			{
				// play frame
				foreach (var bowler in game.Bowlers)
				{
                    PlayFrame(frame, bowler);
                }				
			}

			_scoreCalculator.CalculateScore(game);
		}
		catch (Exception)
		{
			// log/handle exception
		}

		return game;
	}

	private void PlayFrame(int frame, IBowler bowler)
	{
        int firstBallPinCount = _bowlService.RollFirstBall();
        bowler = AddRole(bowler, frame, 1, firstBallPinCount);

        if (firstBallPinCount == 10 && frame < 10)
        {
			return;
        }

        int secondBallPinCount = _bowlService.RollSecondBall(firstBallPinCount);

        bowler = AddRole(bowler, frame, 2, secondBallPinCount);

        if (frame != 10) return;

        if (firstBallPinCount + secondBallPinCount < 10) return;

        int thirdBall = _bowlService.RollBall(10 - secondBallPinCount);
        bowler = AddRole(bowler, frame, 3, thirdBall);
    }

	private static IBowler AddRole(IBowler bowler, int frame, int ballNumber, int pinsKnockedDown)
	{
        bowler.Frames[frame].Roles[ballNumber] = pinsKnockedDown;
		return bowler;
	}

	private static Dictionary<int, IFrame> ClearScoreSheet()
	{
		var frames = new Dictionary<int, IFrame>();

		for (var x = 1; x <= 10; x++)
			frames.Add(x, new Frame());

		return frames;
	}
}