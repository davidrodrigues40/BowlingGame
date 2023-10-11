using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Models;
using BowlingGame.Services;
using BowlingGame.UnitTests.TestUtilities;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Services;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class ScoreCalculatorTests
{
    private readonly ScoreCalculator _calculator = new();

    [Test]
    public void CalculateScore_WhenCalled_ReturnsPerfectGame()
    {
        // Arrange
        IGame game = GameUtilities.GeneratePerfectGame();

        // Act
        _calculator.CalculateScore(game);

        // Assert
        Assert.That(game.Bowlers.ElementAt(0).Score, Is.EqualTo(300));
    }

    [Test]
    public void CalculateScore_WhenCalled_ReturnsNoMarkGame()
    {
        // Arrange
        IGame game = GameUtilities.GenerateNoMarkGame();

        // Act
        _calculator.CalculateScore(game);

        // Assert
        Assert.That(game.Bowlers.ElementAt(0).Score, Is.EqualTo(90));
    }

    [Test]
    public void CalculateScore_WhenCalled_ReturnsAllSpareGame()
    {
        // Arrange
        IGame game = GameUtilities.GenerateAllSpareGame();

        // Act
        _calculator.CalculateScore(game);

        // Assert
        Assert.That(game.Bowlers.ElementAt(0).Score, Is.EqualTo(190));
    }

    [Test]
    public void CalculateScore_WhenCalled_ReturnsSpareStrikeGame()
    {
        // Arrange
        IGame game = GameUtilities.GenerateSpareStrikeGame();

        // Act
        _calculator.CalculateScore(game);

        // Assert
        Assert.That(game.Bowlers.ElementAt(0).Score, Is.EqualTo(209));
    }

    [Test]
    public void ClearScoreSheet_WhenCalled_ReturnsDictionary()
    {
        // Arrange
        Dictionary<int, IFrame> frames = _calculator.ClearScoreSheet();

        // Act
        int result = frames.Count;

        // Assert
        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void CalculateWinner_WhenCalled_ReturnsWinner()
    {
        // Arrange
        List<IBowler> bowlers = new()
        {
            GameUtilities.GenerateBowler("Fred", 9, 1, 10),
            GameUtilities.GenerateBowler("Chuck", 10, 10, 10)
        };
        IGame game = new Game() { Bowlers = bowlers };

        // Act
        _calculator.CalculateScore(game);

        // Assert
        Assert.NotNull(game.Winner);
        Assert.That(game.Winner?.Name, Is.EqualTo("Chuck"));
        Assert.That(game.Winner?.Score, Is.EqualTo(300));
    }

    [Test]
    public void CalculateWinner_WhenCalled_ReturnsWinnerWithTie()
    {
        // Arrange
        List<IBowler> bowlers = new()
        {
            GameUtilities.GenerateBowler("Fred", 9, 1, 10),
            GameUtilities.GenerateBowler("Chuck", 10, 10, 10),
            GameUtilities.GenerateBowler("David", 10, 10, 10)
        };
        IGame game = new Game() { Bowlers = bowlers };

        // Act
        _calculator.CalculateScore(game);

        // Assert
        Assert.NotNull(game.Winner);
        Assert.That(game.Winner?.Name, Is.EqualTo("Chuck and David"));
        Assert.That(game.Winner?.Score, Is.EqualTo(300));
    }

    [Test]
    public void CalculateScore_ThrowsException()
    {
        Bowler bowler = new();
        Game game = new() { Bowlers = new List<IBowler>() { bowler } };

        _ = Assert.Throws<KeyNotFoundException>(() => _calculator.CalculateScore(game));
    }
}
