using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Models;

namespace BowlingGame.Services;
public class PlayerService : IPlayerService
{
    public IEnumerable<IBowler> GenerateBowlers(IEnumerable<IPlayer> players)
    {
        foreach (Player player in players.Cast<Player>())
        {
            yield return new Bowler() { Name = player.Name, Rating = player.Rating };
        }
    }
}
