using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Models;

namespace BowlingGame.Services;

public class GameService : IGameService
{
	private readonly IScoreCalculator _scoreCalculator;
	private readonly IBowler _bowler;
	private readonly IGame _game;

	public GameService(IScoreCalculator scoreCalculator, IBowler bowler)
	{
		_scoreCalculator = scoreCalculator;
		_bowler = bowler;
		_game = new Game();
	}

	public IGame NewGame()
	{
		try
		{
			_game.Frames = ClearScoreSheet();
			_game.Score = 0;
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
				int firstBallPinCount = _bowler.RollFirstBall();
				game = AddRole(game, frame, 1, firstBallPinCount);

				if (firstBallPinCount == 10 && frame < 10)
				{
					continue;
				}

				int secondBallPinCount = _bowler.RollSecondBall(firstBallPinCount);

				game = AddRole(game, frame, 2, secondBallPinCount);

				if (frame != 10) continue;

				if (firstBallPinCount + secondBallPinCount < 10) continue;

				int thirdBall = _bowler.RollBall(10 - secondBallPinCount);
				game = AddRole(game, frame, 3, thirdBall);
			}

			_scoreCalculator.CalculateScore(game);
		}
		catch (Exception)
		{
			// log/handle exception
		}

		return game;
	}

	private static IGame AddRole(IGame game, int frame, int ballNumber, int pinsKnockedDown)
	{
		game.Frames[frame].Roles[ballNumber] = pinsKnockedDown;
		return game;
	}

	private static Dictionary<int, IFrame> ClearScoreSheet()
	{
		var frames = new Dictionary<int, IFrame>();

		for (var x = 1; x <= 10; x++)
			frames.Add(x, new Frame());

		return frames;
	}
}