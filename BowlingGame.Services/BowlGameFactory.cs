using BowlingGame.Abstractions.Services;

namespace BowlingGame.Services;
public class BowlGameFactory<T>
{

    public BowlGameFactory(IScoreCalculator scoreCalculator, IBowlService bowlService)
    {

    }

    public IGameService<T> GetGameService(bool isRatedGame)
    {

    }
}
