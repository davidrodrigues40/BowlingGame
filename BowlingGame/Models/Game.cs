using BowlingGame.Abstractions.Models;

namespace BowlingGame.Models;

public class Game : IGame
{
	public Dictionary<int, IFrame> Frames { get; set; } = new();
	public int Score { get; set; } = 0;
}