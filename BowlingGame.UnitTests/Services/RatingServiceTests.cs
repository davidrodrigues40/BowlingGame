using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Enums;
using BowlingGame.Core.Models;
using BowlingGame.Repository.Factories;
using BowlingGame.Services;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Services;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class RatingServiceTests
{
    private readonly RatingService _service;
    private readonly Mock<RatingRepository> _provider = new();
    private readonly Mock<IRatingRepository> _repository = new();

    public RatingServiceTests() => _service = new RatingService(_provider.Object);

    [Test]
    public void GetRatings_ReturnsRatings()
    {
        // Arrange
        _ = _provider.Setup(f => f(It.IsAny<DataSource>()))
            .Returns(_repository.Object);
        _ = _repository.Setup(r => r.GetRatings())
            .Returns(new List<IBowlerRating>() { new BowlerRatingModel() });

        IEnumerable<IBowlerRating> result = _service.GetRatings(DataSource.InMemory);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(1));
    }
}
