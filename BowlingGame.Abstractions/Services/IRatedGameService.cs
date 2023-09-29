using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services
{
    public interface IRatedGameService
    {
        IGame<IRatedBowler> NewGame(IEnumerable<IRatedBowler> bowlers);
        IGame<IRatedBowler> PlayGame(IGame<IRatedBowler> game);
    }
}
