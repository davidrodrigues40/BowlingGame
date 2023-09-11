using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services;

public interface IGameService
{
	IGame NewGame(IEnumerable<IBowler> bowlers);
	IGame PlayGame(IGame game);
}