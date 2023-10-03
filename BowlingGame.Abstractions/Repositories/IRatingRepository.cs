using BowlingGame.Abstractions.Models;

namespace BowlingGame.Abstractions.Repositories;
public interface IRatingRepository
{
    IEnumerable<IBowlerRating> GetRatings();
}
