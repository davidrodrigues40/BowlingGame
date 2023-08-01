using BowlingGame.Abstractions.Models;

namespace BowlingGame.Models;

public class Frame : IFrame
{
	public Dictionary<int, int> Roles { get; set; } = new();
	public int Score { get; set; } = 0;
}