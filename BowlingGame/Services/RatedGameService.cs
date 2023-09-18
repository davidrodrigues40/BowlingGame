using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Models;

namespace BowlingGame.Services;

public class RatedGameService : IRatedGameService
{
	private readonly IScoreCalculator _scoreCalculator;
	private readonly IBowlService _bowlService;
	private readonly IEnumerable<IRatedBowler> _bowlers;
	private readonly IGame<IRatedBowler> _game;

	public RatedGameService(IScoreCalculator scoreCalculator, IBowlService bowlService)
	{
		_scoreCalculator = scoreCalculator;
		_bowlService = bowlService;
		_bowlers = new List<IRatedBowler>();
		_game = new Game<IRatedBowler>();
	}

	public IGame<IRatedBowler> NewGame(IEnumerable<IRatedBowler> bowlers)
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

	public IGame<IRatedBowler> PlayGame(IGame<IRatedBowler> game)
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

	private void PlayFrame(int frame, IRatedBowler bowler)
	{
		if(frame == 10)
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

        if (frame != 10) return;

        if (firstBallPinCount + secondBallPinCount < 10) return;

        int thirdBall = _bowlService.RollBall(10 - secondBallPinCount, bowler.Rating);
        AddRole(bowler, frame, 3, thirdBall);
    }

	private void PlayTenthFrame(int frame, IRatedBowler bowler)
	{
        int firstBallPinCount = _bowlService.RollFirstBall(bowler.Rating);
		int secondBallPinCount;
		int? thirdBallPinCount = null;

        AddRole(bowler, frame, 1, firstBallPinCount);

		if (firstBallPinCount == 10) // strike on first ball
            secondBallPinCount = _bowlService.RollFirstBall(bowler.Rating);
		else
			secondBallPinCount = _bowlService.RollSecondBall(firstBallPinCount, bowler.Rating);

        AddRole(bowler, frame, 2, secondBallPinCount);

        if (secondBallPinCount == 10) // strike on second ball
			thirdBallPinCount = _bowlService.RollFirstBall(bowler.Rating);
		else if(firstBallPinCount + secondBallPinCount >= 10) // spare
			thirdBallPinCount = _bowlService.RollFirstBall(bowler.Rating);

		if (thirdBallPinCount.HasValue)
            AddRole(bowler, frame, 3, (int)thirdBallPinCount);
		
    }

	private static void AddRole(IRatedBowler bowler, int frame, int ballNumber, int pinsKnockedDown)
	{
        bowler.Frames[frame].Roles[ballNumber] = pinsKnockedDown;
	}

	private static Dictionary<int, IFrame> ClearScoreSheet()
	{
		var frames = new Dictionary<int, IFrame>();

		for (var x = 1; x <= 10; x++)
			frames.Add(x, new Frame());

		return frames;
	}
}