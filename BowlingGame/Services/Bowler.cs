using BowlingGame.Abstractions.Services;

namespace BowlingGame.Services;

public class Bowler : IBowler
{
	private readonly Random _random = new();

	public int RollFirstBall()
	{
		return RollBall(10);
	}

	public int RollSecondBall(int firstBall)
	{
		return RollBall(10 - firstBall);
	}

	public int RollBall(int pinsRemaining)
	{
		try
		{
			return _random.Next(0, pinsRemaining);
		}
		catch (Exception)
		{
			// log/handle exception
		}

		return 0;
	}
}