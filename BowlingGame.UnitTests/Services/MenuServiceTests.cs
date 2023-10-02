using BowlingGame.Abstractions.Models;
using BowlingGame.Services;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Services;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class MenuServiceTests
{
    private readonly MenuService _service;

    public MenuServiceTests() => _service = new MenuService();

    [Test]
    public void GetMenuItems_ReturnsItems()
    {
        // Arrange
        // Act
        IEnumerable<IMenuItem> items = _service.GetMenuItems();

        // Assert
        Assert.That(items, Is.Not.Null);
        Assert.That(items.Count(), Is.EqualTo(3));
    }
}
