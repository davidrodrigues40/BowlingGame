using BowlingGame.Abstractions.Services;
using BowlingGame.Dto.Models;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.Services.UnitTests;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class RatedGameServiceTests
{
    private readonly RatedGameService? _service;
    private readonly Mock<IScoreCalculator> _scoreCalculator = new();
    private readonly Mock<IBowlService> _bowlService = new();
    private readonly RatedBowler _bowler = new();
    private readonly Game<RatedBowler> _game = new();

    public RatedGameServiceTests() => _service = new RatedGameService(_scoreCalculator.Object, _bowlService.Object);

}
