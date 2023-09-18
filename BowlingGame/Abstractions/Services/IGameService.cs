using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services;

public interface IGameService
{
	IGame<IBowler> NewGame(IEnumerable<IBowler> bowlers);
	IGame<IBowler> PlayGame(IGame<IBowler> game);
}