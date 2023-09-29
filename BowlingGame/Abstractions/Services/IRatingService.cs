using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Services;

public interface IRatingService
{
    IEnumerable<IBowlerRating> GetRatings();
}
