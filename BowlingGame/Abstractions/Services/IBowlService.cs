using BowlingGame.Enums;

namespace BowlingGame.Abstractions.Services;

public interface IBowlService
{
	int RollFirstBall();
    int RollFirstBall(BowlerRating rating);
    int RollSecondBall(int firstBall);
    int RollSecondBall(int firstBall, BowlerRating rating);
    int RollBall(int pinsRemaining);
    int RollBall(int pinsRemating, BowlerRating rating);
}