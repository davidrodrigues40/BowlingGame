using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Repositories;
using BowlingGame.Core.Enums;
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
    private readonly Mock<IRatingRepository> _repository = new();

    public RatingServiceTests() => _service = new RatingService(_repository.Object);

    [Test]
    public void GetRatings_ReturnsRatings()
    {
        IEnumerable<IBowlerRating> result = _service.GetRatings();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(Enum.GetNames(typeof(BowlerRating)).Length));
    }
}
