using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services;

public interface IGameService<T>
{
    IGame<T> NewGame(IEnumerable<T> bowlers);
    IGame<T> PlayGame(IGame<T> game);
}