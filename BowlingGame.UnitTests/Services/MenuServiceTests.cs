using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Repositories;
using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;
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
    private readonly Mock<IRepositoryFactory> _factory = new();
    private readonly Mock<IMenuRepository> _repository = new();

    public MenuServiceTests() => _service = new MenuService(_factory.Object);

    [Test]
    public void GetMenuItems_ReturnsItems()
    {
        // Arrange
        _ = _factory.Setup(f => f.CreateRepository<IMenuRepository>(It.IsAny<DataSource>()))
            .Returns(_repository.Object);
        // Act
        IEnumerable<IMenuItem> items = _service.GetMenuItems();

        // Assert
        Assert.That(items, Is.Not.Null);
        Assert.That(items.Count(), Is.EqualTo(3));
    }
}
