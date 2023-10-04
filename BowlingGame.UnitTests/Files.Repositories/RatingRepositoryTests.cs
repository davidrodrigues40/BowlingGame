using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Dto.Models;
using BowlingGame.Files.Repository;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BowlingGame.UnitTests.Files.Repositories;

[TestFixture]
[ExcludeFromCodeCoverage]
internal class RatingRepositoryTests
{
    private readonly IRatingRepository _repository = new RatingRepository();
    private readonly IFileRepository _fileRepository = new RatingRepository();

    [Test]
    public async Task GetMenuItems_ReturnsMenuItems()
    {
        // Arrange
        var menu = new JsonMenu<IBowlerRating>();
        BowlerRatingModel bowler = new();
        menu.Items = new List<IBowlerRating> { bowler };

        await using (FileStream stream = File.Create(_fileRepository.FileName))
        {
            await JsonSerializer.SerializeAsync(stream, menu);
        }

        // Act
        IEnumerable<IBowlerRating> result = _repository.GetRatings();

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
        IEnumerable<IBowlerRating> result = _repository.GetRatings();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
    }
}
