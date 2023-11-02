using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Core.Models;
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
    private readonly Mock<IRepositoryFactory> _factory = new();
    private readonly Mock<IRatingRepository> _repository = new();

    public RatingServiceTests() => _service = new RatingService(_factory.Object);

    [Test]
    public void GetRatings_ReturnsRatings()
    {
        // Arrange
        _ = _factory.Setup(f => f.CreateRatingRepository(It.IsAny<DataSource>()))
            .Returns(_repository.Object);
        _ = _repository.Setup(r => r.GetRatings())
            .Returns(new List<IBowlerRating>() { new BowlerRatingModel() });

        IEnumerable<IBowlerRating> result = _service.GetRatings(DataSource.InMemory);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(1));
    }
}
