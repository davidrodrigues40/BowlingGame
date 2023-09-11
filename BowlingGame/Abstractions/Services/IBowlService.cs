namespace BowlingGame.Abstractions.Services;

public interface IBowlService
{
	int RollFirstBall();
	int RollSecondBall(int firstBall);
	int RollBall(int pinsRemaining);
}