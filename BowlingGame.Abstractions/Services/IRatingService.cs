using BowlingGame.Abstractions.Models;
using BowlingGame.Core.Enums;

namespace BowlingGame.Abstractions.Services;

public interface IRatingService
{
    IEnumerable<IBowlerRating> GetRatings();
    IEnumerable<IBowlerRating> GetRatings(DataSource dataSource);
}
