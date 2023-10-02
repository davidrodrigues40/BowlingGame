using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Dto.Models;

namespace BowlingGame.Services;
public abstract class GameServiceBase
{
    protected readonly IScoreCalculator _scoreCalculator;
    protected IGame<IBowler>? _game;

    public GameServiceBase(IScoreCalculator scoreCalculator) => _scoreCalculator = scoreCalculator;

    public IGame<IBowler> NewGame(IEnumerable<IBowler> bowlers)
    {
        _game = new Game<IBowler>() { Bowlers = bowlers };
        _game.Bowlers = bowlers;

        try
        {
            foreach (IBowler item in _game.Bowlers)
            {
                item.Frames = _scoreCalculator.ClearScoreSheet();
                item.Score = 0;
            }

            return _game;
        }
        catch (Exception)
        {
            // TODO: log exception
            throw;
        }
    }
}
