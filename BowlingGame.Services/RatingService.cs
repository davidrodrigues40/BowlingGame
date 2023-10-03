using BowlingGame.Abstractions.Models;
using BowlingGame.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Repository.Factories;

namespace BowlingGame.Services;

public class RatingService : IRatingService
{
    private readonly RatingRepositoryProvider _provider;
    public RatingService(RatingRepositoryProvider provider) => _provider = provider;

    public IEnumerable<IBowlerRating> GetRatings(DataSource dataSource) => _provider(dataSource).GetRatings();
}
