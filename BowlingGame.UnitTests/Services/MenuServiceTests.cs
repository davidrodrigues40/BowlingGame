using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Repositories;
using BowlingGame.Core.Enums;
using BowlingGame.Dto.Models;
using BowlingGame.Repository.Factories;
using BowlingGame.Services;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Services;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class MenuServiceTests
{
    private readonly MenuService _service;
    private readonly Mock<MenuRepositoryProvider> _provider = new();
    private readonly Mock<IMenuRepository> _repository = new();

    public MenuServiceTests() => _service = new MenuService(_provider.Object);

    [Test]
    public void GetMenuItems_ReturnsItems()
    {
        // Arrange
        _ = _provider.Setup(f => f(It.IsAny<DataSource>()))
            .Returns(_repository.Object);
        _ = _repository.Setup(r => r.GetMenuItems())
            .Returns(new List<IMenuItem>() { new MenuItem() });

        // Act
        IEnumerable<IMenuItem> items = _service.GetMenuItems(DataSource.InMemory);

        // Assert
        Assert.That(items, Is.Not.Null);
        Assert.That(items.Count(), Is.EqualTo(1));
    }
}
