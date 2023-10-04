using BowlingGame.Api.Controllers;
using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Api;
[TestFixture]
[ExcludeFromCodeCoverage]
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
        _ = _ratingServiceMock.Setup(x => x.GetRatings(It.IsAny<DataSource>())).Returns((IEnumerable<IBowlerRating>)ratings);

        // Act
        IActionResult result = _controller.GetRatings(DataSource.InMemory);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(((OkObjectResult)result).Value, Is.EqualTo(ratings));
    }
}
