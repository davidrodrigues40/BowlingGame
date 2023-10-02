using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;

namespace BowlingGame.Services;

public class BowlService : IBowlService
{
    private readonly Random _random = new();

    public int RollFirstBall() => RollBall(10);

    public int RollFirstBall(BowlerRating rating) => RollBall(10, rating);

    public int RollSecondBall(int firstBall) => RollBall(10 - firstBall);

    public int RollSecondBall(int firstBall, BowlerRating rating) => RollBall(10 - firstBall, rating);

    public int RollBall(int pinsRemaining) => Math.Min(_random.Next(0, pinsRemaining + 1), pinsRemaining);

    public int RollBall(int pinsRemaining, BowlerRating rating)
    {
        int handycap = (int)rating * 3;

        int pinsKnockedDown = _random.Next(handycap, pinsRemaining + handycap);

        return Math.Min(pinsKnockedDown, pinsRemaining);
    }
}