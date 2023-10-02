using BowlingGame.Abstractions.Models;
using BowlingGame.Core.Enums;
using BowlingGame.Services;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Services;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class RatingServiceTests
{
    private readonly RatingService _service;

    public RatingServiceTests() => _service = new RatingService();

    [Test]
    public void GetRatings_ReturnsRatings()
    {
        IEnumerable<IBowlerRating> result = _service.GetRatings();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(Enum.GetNames(typeof(BowlerRating)).Length));
    }
}
