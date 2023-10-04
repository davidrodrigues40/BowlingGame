using BowlingGame.Core.Abstractions.Models;

namespace BowlingGame.Core.Abstractions.Services;

public interface IGameService
{
    IGame NewGame(IEnumerable<IBowler> bowlers);
    IGame PlayGame(IGame game);
}