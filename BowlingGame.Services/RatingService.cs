using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Repository.Factories;

namespace BowlingGame.Services;

public class RatingService : IRatingService
{
    private readonly RatingRepositoryResolver _provider;
    public RatingService(RatingRepositoryResolver provider) => _provider = provider;

    public IEnumerable<IBowlerRating> GetRatings() => _provider(DataSource.InMemory).GetRatings();
    public IEnumerable<IBowlerRating> GetRatings(DataSource dataSource) => _provider(dataSource).GetRatings();
}
