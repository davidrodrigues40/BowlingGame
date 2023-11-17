using BowlingGame.Core.Abstractions.Models.v2;

namespace BowlingGame.Core.Abstractions.Services.v2;

public interface IGameServiceV2
{
    IGame NewGame(IEnumerable<IBowler> bowlers);

    int RollBall(int pins, int bowlerRating);
}