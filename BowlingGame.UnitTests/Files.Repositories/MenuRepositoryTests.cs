using BowlingGame.Abstractions.Repositories;
using BowlingGame.Dto.Models;
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
        var menuItem = new MenuItem();
        menu.Items = new List<MenuItem> { menuItem };

        await using (FileStream stream = File.Create(_fileRepository.FileName))
        {
            await JsonSerializer.SerializeAsync(stream, menu);
        }

        // Act
        IEnumerable<Abstractions.Models.IMenuItem> result = _repository.GetMenuItems();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Not.Empty);

        File.Delete(_fileRepository.FileName);
    }

    [Test]
    public void GetMenuItems_WithIncorrectFilename_ReturnsEmptyList()
    {   // Arrange
        if (File.Exists(_fileRepository.FileName)) File.Delete(_fileRepository.FileName);

        // Act
        IEnumerable<Abstractions.Models.IMenuItem> result = _repository.GetMenuItems();

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
        IEnumerable<Abstractions.Models.IMenuItem> result = _repository.GetMenuItems();

        // Assert
        Assert.That(result, Is.Empty);
    }
}
