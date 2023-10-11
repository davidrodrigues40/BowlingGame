using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Models;
using BowlingGame.Files.Repository;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BowlingGame.UnitTests.Files.Repositories;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class MenuRepositoryTests
{
    private readonly IMenuRepository _repository = new MenuRepository();
    private readonly IFileRepository _fileRepository = new MenuRepository();

    [Test]
    public async Task GetMenuItems_ReturnsMenuItems()
    {
        // Arrange
        var menu = new JsonMenu<MenuItem>();
        var menuItem = new MenuItem() { Value = "Val", Route = "Rte" };
        menu.Items = new List<MenuItem> { menuItem };

        await using (FileStream stream = File.Create(_fileRepository.FileName))
        {
            await JsonSerializer.SerializeAsync(stream, menu);
        }

        // Act
        IEnumerable<IMenuItem> result = _repository.GetMenuItems();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Value, Is.EqualTo(menuItem.Value));
        Assert.That(result.First().Route, Is.EqualTo(menuItem.Route));

        File.Delete(_fileRepository.FileName);
    }

    [Test]
    public void GetMenuItems_WithIncorrectFilename_ReturnsEmptyList()
    {   // Arrange
        if (File.Exists(_fileRepository.FileName)) File.Delete(_fileRepository.FileName);

        // Act
        IEnumerable<IMenuItem> result = _repository.GetMenuItems();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public async Task GetMenuItems_ShouldReturnNull()
    {
        // Arrange
        JsonMenu<MenuItem>? menu = null;
        await using (FileStream stream = File.Create(_fileRepository.FileName))
        {
            await JsonSerializer.SerializeAsync(stream, menu);
        }

        // Act
        IEnumerable<IMenuItem> result = _repository.GetMenuItems();

        // Assert
        Assert.That(result, Is.Empty);
    }
}
