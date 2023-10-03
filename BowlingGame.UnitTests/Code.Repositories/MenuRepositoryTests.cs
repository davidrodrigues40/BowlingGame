using BowlingGame.Abstractions.Models;
using BowlingGame.Code.Repository;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Code.Repositories;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class MenuRepositoryTests
{
    private readonly MenuRepository _repository = new();

    [Test]
    public void GetMenuItems_WhenCalled_ReturnsItems()
    {
        // Arrange
        MenuRepository repository = new();

        // Act
        IEnumerable<IMenuItem> items = repository.GetMenuItems();

        // Assert
        Assert.That(items, Is.Not.Null);
        Assert.That(items.Count(), Is.EqualTo(3));
    }
}
