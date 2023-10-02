using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Dto.Models;

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
