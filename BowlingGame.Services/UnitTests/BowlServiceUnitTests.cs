using BowlingGame.Core.Enums;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.Services.UnitTests;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class BowlServiceUnitTests
{
    private readonly BowlService _service = new();

    [Test]
    public void RollFirstBall_ReturnsValueBetween0And10()
    {
        int result = _service.RollFirstBall();

        Assert.That(result, Is.GreaterThanOrEqualTo(0));
        Assert.That(result, Is.LessThanOrEqualTo(10));
    }

    [Test]
    public void RollFirstBall_WithRating_ReturnsValueBetween0And10()
    {
        int result = _service.RollFirstBall(BowlerRating.Expert);

        Assert.That(result, Is.GreaterThanOrEqualTo(0));
        Assert.That(result, Is.LessThanOrEqualTo(10));
    }

    [Test]
    public void RollSecondBall_ReturnsValueBetween0And10()
    {
        int result = _service.RollSecondBall(5);

        Assert.That(result, Is.GreaterThanOrEqualTo(0));
        Assert.That(result, Is.LessThanOrEqualTo(10));
    }

    [Test]
    public void RollSecondBall_WithRating_ReturnsValueBetween0And10()
    {
        int result = _service.RollSecondBall(5, BowlerRating.Expert);

        Assert.That(result, Is.GreaterThanOrEqualTo(0));
        Assert.That(result, Is.LessThanOrEqualTo(10));
    }
}
