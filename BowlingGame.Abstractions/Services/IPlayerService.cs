using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services;
public interface IPlayerService
{
    IEnumerable<IBowler> GenerateBowlers(IEnumerable<IPlayer> players);
}
