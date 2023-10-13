using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;

namespace BowlingGame.Services;

public class RatingService : IRatingService
{
    private readonly IRepositoryFactory _factory;
    public RatingService(IRepositoryFactory factory) => _factory = factory;

    public IEnumerable<IBowlerRating> GetRatings(DataSource dataSource) => _factory.CreateRatingRepository(dataSource)!.GetRatings();
}
