using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;

namespace BowlingGame.Services;

public class BowlService : IBowlService
{
    private readonly Random _random = new();

    public int RollFirstBall(BowlerRating rating) => RollBall(10, rating);

    public int RollSecondBall(int firstBall, BowlerRating rating) => RollBall(10 - firstBall, rating);

    public int RollBall(int pinsRemaining, BowlerRating rating)
    {
        int handycap = (int)rating * 3;

        int pinsKnockedDown = _random.Next(handycap, pinsRemaining + handycap);

        return Math.Min(pinsKnockedDown, pinsRemaining);
    }
}