using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Enums;
using BowlingGame.Core.Models;
using BowlingGame.Services;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Services;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class PlayerServiceTests
{
    private readonly PlayerService _service;

    public PlayerServiceTests() => _service = new PlayerService();

    [Test]
    public void GenerateBowlers_ReturnsBowlers()
    {
        IEnumerable<IPlayer> players = new List<IPlayer>()
        {
            new Player() { Name = "Test", Rating = BowlerRating.Expert }
        };

        IEnumerable<IBowler> result = _service.GenerateBowlers(players);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(1));
    }
}
