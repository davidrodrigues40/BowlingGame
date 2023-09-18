using BowlingGame.Abstractions.Services;
using BowlingGame.Enums;

namespace BowlingGame.Services;

public class BowlService : IBowlService
{
	private readonly Random _random = new();

	public int RollFirstBall()
	{
		return RollBall(10);
	}

	public int RollFirstBall(BowlerRating rating)
	{
		return RollBall(10, rating);
	}

	public int RollSecondBall(int firstBall)
	{
		return RollBall(10 - firstBall);
	}

    public int RollSecondBall(int firstBall, BowlerRating rating)
    {
        return RollBall(10 - firstBall, rating);
    }

    public int RollBall(int pinsRemaining)
	{
		try
		{
			return Math.Min(_random.Next(0, pinsRemaining + 1), pinsRemaining);
		}
		catch (Exception)
		{
			// log/handle exception
		}

		return 0;
	}

	public int RollBall(int pinsRemaining, BowlerRating rating)
	{
		var handycap = (int)rating * 3;

		var pinsKnockedDown = _random.Next(handycap, (int)(pinsRemaining + handycap));

        return Math.Min(pinsKnockedDown, pinsRemaining);
	}
}