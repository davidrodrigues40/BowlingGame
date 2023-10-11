using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Repository.Factories;

namespace BowlingGame.Services;

public class RatingService : IRatingService
{
    private readonly RatingRepository _provider;
    public RatingService(RatingRepository provider) => _provider = provider;

    public IEnumerable<IBowlerRating> GetRatings(DataSource dataSource) => _provider(dataSource).GetRatings();
}
