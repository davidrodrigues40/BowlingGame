using BowlingGame.Core.Enums;

namespace BowlingGame.Abstractions.Services;

public interface IBowlService
{
    int RollFirstBall(BowlerRating rating);
    int RollSecondBall(int firstBall, BowlerRating rating);
    int RollBall(int pinsRemating, BowlerRating rating);
}