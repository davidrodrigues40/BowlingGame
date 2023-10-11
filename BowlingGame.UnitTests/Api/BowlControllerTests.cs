using BowlingGame.Api.Controllers;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Api;
[TestFixture]
[ExcludeFromCodeCoverage]
public class BowlControllerTests
{
    private readonly BowlController _controller;
    private readonly Mock<IGameService> _gameService = new();
    private readonly Mock<IPlayerService> _playerService = new();

    public BowlControllerTests() => _controller = new BowlController(_gameService.Object, _playerService.Object);

    [Test]
    public void Bowl_WhenCalled_ReturnsGame()
    {
        // Arrange
        List<Player> players = new() { new Player() };

        // Act
        IActionResult result = _controller.Bowl(players);

        // Assert
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Bowl_WhenCalledWithNoPlayers_ReturnsBadRequest()
    {
        // Arrange
        List<Player> players = new();

        // Act
        IActionResult result = _controller.Bowl(players);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }

    [Test]
    public void Bowl_WhenCalledWithNullPlayers_ReturnsBadRequest()
    {
        // Arrange
        List<Player>? players = null;

        // Act
        IActionResult result = _controller.Bowl(players);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }
}
