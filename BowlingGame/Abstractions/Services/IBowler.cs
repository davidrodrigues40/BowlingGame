namespace BowlingGame.Abstractions.Services;

public interface IBowler
{
	int RollFirstBall();
	int RollSecondBall(int firstBall);
	int RollBall(int pinsRemaining);
}