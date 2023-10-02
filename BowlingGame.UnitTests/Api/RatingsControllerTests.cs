using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Api.Controllers;
using BowlingGame.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BowlingGame.UnitTests.Api;
internal class RatingsControllerTests
{
    private readonly Mock<IRatingService> _ratingServiceMock = new();
    private readonly RatingsController _controller;

    public RatingsControllerTests() => _controller = new RatingsController(_ratingServiceMock.Object);

    [Test]
    public void GetRatings_WhenCalled_ReturnsRatings()
    {
        // Arrange
        List<IBowlerRating> ratings = new() { new BowlerRatingModel() };
        _ = _ratingServiceMock.Setup(x => x.GetRatings()).Returns((IEnumerable<IBowlerRating>)ratings);

        // Act
        IActionResult result = _controller.GetRatings();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(((OkObjectResult)result).Value, Is.EqualTo(ratings));
    }
}
