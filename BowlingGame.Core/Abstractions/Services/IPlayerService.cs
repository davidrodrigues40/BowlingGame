using BowlingGame.Core.Abstractions.Models;

namespace BowlingGame.Core.Abstractions.Services;
public interface IPlayerService
{
    IEnumerable<IBowler> GenerateBowlers(IEnumerable<IPlayer> players);
}
