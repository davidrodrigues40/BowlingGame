namespace BowlingGame.Abstractions.Models;

public interface IGame<T>
{
	IEnumerable<T> Bowlers { get; set; }
	IScoreCard? Winner { get; set; }
}