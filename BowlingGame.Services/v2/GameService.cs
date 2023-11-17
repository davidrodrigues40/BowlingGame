using BowlingGame.Core.Abstractions.Models.v2;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Abstractions.Services.v2;
using BowlingGame.Core.Enums;
using BowlingGame.Core.Models.v2;

namespace BowlingGame.Services.v2;
public class GameService : IGameServiceV2
{
    private readonly IBowlService _bowlService;
    private readonly IScorecardGenerator _scorecardGenerator;

    public GameService(IBowlService bowlService, IScorecardGenerator scorecardGenerator)
    {
        _bowlService = bowlService;
        _scorecardGenerator = scorecardGenerator;
    }
    public IGame NewGame(IEnumerable<IBowler> bowlers)
    {
        var game = new Game
        {
            Id = Guid.NewGuid(),
            Bowlers = bowlers
        };
        var scorecards = new List<IScorecard>();

        foreach (var bowler in bowlers)
        {
            scorecards.Add(_scorecardGenerator.GenerateScorecard(bowler.Id));
        }

        game.Scorecards = scorecards;

        return game;
    }

    public int RollBall(int pins, int bowlerRating)
    {
        return _bowlService.RollBall(pins, (BowlerRating)bowlerRating);
    }
}
