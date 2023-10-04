using BowlingGame.Core.Abstractions.Models;
using BowlingGame.Core.Enums;

namespace BowlingGame.Core.Abstractions.Services;

public interface IRatingService
{
    IEnumerable<IBowlerRating> GetRatings(DataSource dataSource);
}
