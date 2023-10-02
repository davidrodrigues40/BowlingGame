using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Dto.Models;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.Services.UnitTests;
[TestFixture]
[ExcludeFromCodeCoverage]
public class GameServiceUnitTests
{
    private readonly IGameService _service;
    private readonly Mock<IScoreCalculator> _scoreCalculator = new();
    private readonly Mock<IBowlService> _bowlService = new();
    private readonly Bowler _bowler = new();
    private readonly Game<IBowler> _game = new();

    public GameServiceUnitTests() => _service = new GameService(_scoreCalculator.Object, _bowlService.Object);

    [Test]
    public void NewGame_CreatesNewGame()
    {
        // arrange
        Bowler bowler = _bowler with { Name = "Chuck Norris", Score = 300 };
        IEnumerable<IBowler> bowlers = new List<IBowler>() { bowler };

        // act
        IGame<IBowler> game = _service.NewGame(bowlers);

        // assert
        Assert.IsNotNull(game);
        Assert.AreEqual(0, game.Bowlers.ElementAt(0).Score);
    }

    [Test]
    public void NewGame_ThrowsException()
    {
        // arrange
        IEnumerable<IBowler> bowlers = new List<IBowler>() { _bowler };
        _ = _scoreCalculator.Setup(x => x.ClearScoreSheet()).Throws(new Exception());

        // assert
        _ = Assert.Throws<Exception>(() => _service.NewGame(bowlers));
    }

    [Test]
    public void PlayGame_PlaysPerfectGame()
    {
        // arrange
        Bowler bowler = _bowler with { Name = "Chuck Norris" };
        IFrame frame = new Frame();
        Enumerable.Range(1, 10).ToList().ForEach(x => bowler.Frames.Add(x, new Frame()));
        setupMockServices(10, 10, 10, 310);

        // act
        IGame<IBowler> actual = _service.PlayGame(_game with { Bowlers = new List<IBowler>() { bowler } });

        // assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(310, actual.Bowlers.ElementAt(0).Score);
    }

    [Test]
    public void PlayGame_WithSpares()
    {
        Bowler bowler = _bowler with { Name = "Chuck Norris" };
        _bowler.Frames.Clear();
        Enumerable.Range(1, 10).ToList().ForEach(x => bowler.Frames.Add(x, new Frame()));
        setupMockServices(9, 1, 10, 300);

        // act
        IGame<IBowler> actual = _service.PlayGame(_game with { Bowlers = new List<IBowler>() { bowler } });

        // assert - Chuck Norris never gets below perfect
        Assert.IsNotNull(actual);
        Assert.AreEqual(300, actual.Bowlers.ElementAt(0).Score);
    }

    [Test]
    public void PlayGame_ThrowsException()
    {
        Bowler bowler = _bowler with { Name = "Chuck Norris" };
        _bowler.Frames.Clear();
        Enumerable.Range(1, 10).ToList().ForEach(x => bowler.Frames.Add(x, new Frame()));
        setupMockServices(9, 1, 10, 300);

        _ = _scoreCalculator.Setup(x => x.CalculateScore(It.IsAny<IGame<IBowler>>())).Throws(new Exception());

        // assert
        _ = Assert.Throws<Exception>(() => _service.PlayGame(_game with { Bowlers = new List<IBowler>() { bowler } }));
    }

    private void setupMockServices(int firstBall, int secondBall, int thirdBall, int calculatedScore)
    {
        IFrame frame = new Frame();
        _ = _scoreCalculator.Setup(x => x.CalculateScore(It.IsAny<IGame<IBowler>>()))
            .Callback<IGame<IBowler>>(x => x.Bowlers.ElementAt(0).Score = calculatedScore);
        _ = _scoreCalculator.Setup(x => x.ClearScoreSheet())
            .Returns(Enumerable.Range(1, 10).ToList()
                .Select(key => new { key, frame }).ToDictionary(x => x.key, x => x.frame)
                );
        _ = _bowlService.Setup(x => x.RollFirstBall())
            .Returns(firstBall);
        _ = _bowlService.Setup(x => x.RollSecondBall(It.IsAny<int>()))
            .Returns(secondBall);
        _ = _bowlService.Setup(x => x.RollBall(It.IsAny<int>()))
            .Returns(thirdBall);
    }
}
