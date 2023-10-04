using BowlingGame.Code.Repository;
using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Enums;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Code.Repositories;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class RatingRepositoryTests
{
    private readonly RatingRepository _repository = new();

    [Test]
    public void GetMenuItems_WhenCalled_ReturnsItems()
    {
        // Act
        IEnumerable<IBowlerRating> items = _repository.GetRatings();

        // Assert
        Assert.That(items, Is.Not.Null);
        Assert.That(items.Count(), Is.EqualTo(Enum.GetNames(typeof(BowlerRating)).Length));
    }
}
