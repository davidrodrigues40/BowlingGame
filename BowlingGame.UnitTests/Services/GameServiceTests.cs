using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Dto.Models;
using BowlingGame.Services;
using BowlingGame.UnitTests.TestUtilities;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Services;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class GameServiceTests
{
    private readonly GameService _service;
    private readonly Mock<IScoreCalculator> _scoreCalculator = new();
    private readonly Mock<IBowlService> _bowlService = new();
    private readonly Bowler _bowler = new();
    private readonly Game _game = new();

    public GameServiceTests() => _service = new GameService(_scoreCalculator.Object, _bowlService.Object);

    [Test]
    public void NewGame_WhenCalled_ReturnsGame()
    {
        // Arrange
        IEnumerable<IBowler> bowlers = new List<IBowler> { _bowler };

        // Act
        IGame result = _service.NewGame(bowlers);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Bowlers, Is.Not.Null);
        Assert.That(result.Bowlers.Count(), Is.EqualTo(1));
    }

    [Test]
    public void NewGame_WhenCalled_ThrowsException()
    {
        // Arrange
        IEnumerable<IBowler> bowlers = new List<IBowler> { _bowler };
        _ = _scoreCalculator.Setup(x => x.ClearScoreSheet()).Throws(new Exception());

        // Act/Assert
        _ = Assert.Throws<Exception>(() => _service.NewGame(bowlers));
    }

    [Test]
    public void PlayGame_WhenCalled_ReturnsAllStrikes()
    {
        // Arrange
        IGame game = GameUtilities.GeneratePerfectGame();
        _ = _bowlService.Setup(b => b.RollFirstBall(It.IsAny<BowlerRating>()))
            .Returns(10);
        _ = _bowlService.Setup(b => b.RollSecondBall(It.IsAny<int>(), It.IsAny<BowlerRating>()))
            .Returns(10);
        _ = _bowlService.Setup(b => b.RollBall(It.IsAny<int>(), It.IsAny<BowlerRating>()))
            .Returns(10);
        _ = _scoreCalculator.Setup(x => x.CalculateScore(It.IsAny<IGame>()))
               .Callback((IGame game) => { game.Bowlers.ElementAt(0).Score = 300; });

        // Act
        IGame result = _service.PlayGame(game);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Bowlers, Is.Not.Null);
        Assert.That(result.Bowlers.Count(), Is.EqualTo(1));
        Assert.That(result.Bowlers.ElementAt(0).Score, Is.EqualTo(300));
    }

    [Test]
    public void PlayGame_WhenCalled_ReturnNoStrikeOrSpare()
    {
        // Arrange
        IGame game = GameUtilities.GenerateNoMarkGame();
        _ = _scoreCalculator.Setup(x => x.CalculateScore(It.IsAny<IGame>()))
               .Callback((IGame game) => { game.Bowlers.ElementAt(0).Score = 90; });

        // Act
        IGame result = _service.PlayGame(game);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Bowlers, Is.Not.Null);
        Assert.That(result.Bowlers.Count(), Is.EqualTo(1));
        Assert.That(result.Bowlers.ElementAt(0).Score, Is.EqualTo(90));
    }

    [Test]
    public void PlayGame_WhenCalled_ReturnsAllSpares()
    {
        // Arrange
        IGame game = GameUtilities.GenerateAllSpareGame();
        _ = _bowlService.Setup(b => b.RollFirstBall(It.IsAny<BowlerRating>()))
            .Returns(9);
        _ = _bowlService.Setup(b => b.RollSecondBall(It.IsAny<int>(), It.IsAny<BowlerRating>()))
            .Returns(1);
        _ = _bowlService.Setup(b => b.RollBall(It.IsAny<int>(), It.IsAny<BowlerRating>()))
            .Returns(10);
        _ = _scoreCalculator.Setup(x => x.CalculateScore(It.IsAny<IGame>()))
               .Callback((IGame game) => { game.Bowlers.ElementAt(0).Score = 190; });

        // Act
        IGame result = _service.PlayGame(game);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Bowlers, Is.Not.Null);
        Assert.That(result.Bowlers.Count(), Is.EqualTo(1));
        Assert.That(result.Bowlers.ElementAt(0).Score, Is.EqualTo(190));
    }

    [Test]
    public void PlayGame_WhenCalled_ThrowsException()
    {
        // Arrange
        IGame game = GameUtilities.GeneratePerfectGame();
        _ = _scoreCalculator.Setup(x => x.CalculateScore(It.IsAny<IGame>())).Throws(new Exception());

        // Act/Assert
        _ = Assert.Throws<Exception>(() => _service.PlayGame(_game));
    }
}
