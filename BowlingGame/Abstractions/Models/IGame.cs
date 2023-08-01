namespace BowlingGame.Abstractions.Models;

public interface IGame
{
	Dictionary<int, IFrame> Frames { get; set; }
	int Score { get; set; }
}